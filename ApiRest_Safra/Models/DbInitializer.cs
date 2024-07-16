using ApiRest_Safra.Models.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var options = serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();

        using var context = new ApplicationDbContext(options, configuration);
        {
            // Eliminar y volver a crear la base de datos
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Agregar datos de prueba
            var users = new User_DbContext[]
            {
                new User_DbContext{ UsrEmail="user1@example.com", UsrPass="Password1" },
                new User_DbContext{ UsrEmail="user2@example.com", UsrPass="Password2" }
            };

            context.User.AddRange(users);
            context.SaveChanges();

            var clients = new Client_DbContext[]
            {
                new Client_DbContext { Document="1000313300",First_Name="Julian",Last_Name="Fula",Email="fuljulian20@gmail.com", Bill_Id = 1 },
                new Client_DbContext { Document="1000313300",First_Name="Mateo",Last_Name="Contreras",Email="mateo@gmail.com", Bill_Id = 2},
            };

            context.Client.AddRange(clients);
            context.SaveChanges();

            var products = new Product[]
            {
                new Product { Name ="Cortina" },
                new Product { Name ="Luz" },
                new Product { Name ="Bombillo" },
            };

            context.Product.AddRange(products);
            context.SaveChanges();

            var bills = new Bill[]
            {
                new Bill { Client_Id = clients[0].Id, Company_Name = "Company A", Nit = "123456789", Code = "001" },
                new Bill { Client_Id = clients[1].Id, Company_Name = "Company B", Nit = "987654321", Code = "002" }
            };

            context.Bills.AddRange(bills);
            context.SaveChanges();

            var billProducts = new Bill_Product[]
            {
                new Bill_Product { Bill_Id = bills[0].Id, Product_Id = products[0].Id },
                new Bill_Product { Bill_Id = bills[1].Id, Product_Id = products[1].Id }
            };

            context.Bill_Product.AddRange(billProducts);
            context.SaveChanges();
        }
    }
}