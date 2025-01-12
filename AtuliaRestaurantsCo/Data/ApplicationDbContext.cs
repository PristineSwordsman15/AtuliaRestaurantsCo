﻿using AtuliaRestaurantsCo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Reflection.Emit;

namespace AtuliaRestaurantsCo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<ProductIngredient> ProductIngredients { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            builder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            builder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            //Seed Data
            builder.Entity<Category>().HasData(
               new Category { CategoryId = 1, Name = "Appetizer" },
               new Category { CategoryId = 2, Name = "Main" },
               new Category { CategoryId = 3, Name = "Dessert" },
               new Category { CategoryId = 4, Name = "Beverage" }
           );

            builder.Entity<Ingredient>().HasData(
             //add indian restaurant ingredients here
             new Ingredient { IngredientId = 1, Name = "Potato" },
             new Ingredient { IngredientId = 2, Name = "Chicken" },
             new Ingredient { IngredientId = 3, Name = "Fish" },
             new Ingredient { IngredientId = 4, Name = "Naan" },
             new Ingredient { IngredientId = 5, Name = "Spinach" },
             new Ingredient { IngredientId = 6, Name = "Tomato" },
             new Ingredient { IngredientId = 7, Name = "White Rice" },
             new Ingredient { IngredientId = 8, Name = "Peas" },
             new Ingredient { IngredientId = 9, Name = "Coriander" },
             new Ingredient { IngredientId = 10, Name = "Lentils" },
             new Ingredient { IngredientId = 11, Name = "Gulab Jamun" },
             new Ingredient { IngredientId = 12, Name = "Ice Cream" },
             new Ingredient { IngredientId = 13, Name = "Water" },
             new Ingredient { IngredientId = 14, Name = "Mango Lassi" },
             new Ingredient { IngredientId = 15, Name = "Coke" }


         );
            builder.Entity<Product>().HasData(
                //add indian restaurant offering here
                new Product
                {
                    ProductId = 1,
                    Name = "Naan",
                    Description = "A fluffy bread popular in North India",
                    Price = 7.99m,
                    Stock = 25,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Fried Rice",
                    Description = "Mild yummy rice with peas",
                    Price = 10.99m,
                    Stock = 40,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Aloo Fry",
                    Description = "Fried Potato Curry served with Naan and Rice",
                    Price = 8.50m,
                    Stock = 10,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Coke",
                    Description = "Chilled Fizzy Beverage",
                    Price = 2.99m,
                    Stock = 50,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Water",
                    Description = "Beverage",
                    Price = 3.99m,
                    Stock = 50,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Mango Lassi",
                    Description = "Cool Mango drink",
                    Price = 5.00m,
                    Stock = 20,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 7,
                    Name = "Gulab Jamun",
                    Description = "Indian sweet made with milk powder",
                    Price = 4.99m,
                    Stock = 30,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 8,
                    Name = "Ice Cream",
                    Description = "Frozen dessert",
                    Price = 2.99m,
                    Stock = 60,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 9,
                    Name = "Butter Chicken",
                    Description = "Chiken flavoured lightly in spices and served with rice",
                    Price = 20.99m,
                    Stock = 30,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 10,
                    Name = "Fish Madrasi",
                    Description = "Fish curry served with rice",
                    Price = 19.99m,
                    Stock = 20,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 11,
                    Name = "Palak Fritters",
                    Description = "Spinach deepfried coated in batter",
                    Price = 6.99m,
                    Stock = 30,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 12,
                    Name = "Chicken Lollipops",
                    Description = "Chicken lightly coated in spices and fried",
                    Price = 8.9m,
                    Stock = 30,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 13,
                    Name = "Daal Fry",
                    Description = "Lentil cooked with tomato and garnished with coriander.",
                    Price = 7.99m,
                    Stock = 20,
                    CategoryId = 2

                }
                );

            builder.Entity<ProductIngredient>().HasData(
                new { ProductId = 1, IngredientId = 4 },
                new { ProductId = 2, IngredientId = 7 },
                new { ProductId = 2, IngredientId = 8 },
                new { ProductId = 3, IngredientId = 1 },
                new { ProductId = 3, IngredientId = 4 },
                new { ProductId = 3, IngredientId = 7 },
                new { ProductId = 4, IngredientId = 15},
                new { ProductId = 5, IngredientId = 13},
                new { ProductId = 6, IngredientId = 14},
                new { ProductId = 7, IngredientId = 11},
                new { ProductId = 8, IngredientId = 12},
                new { ProductId = 9, IngredientId = 2 },
                new { ProductId = 9, IngredientId = 7 },
                new { ProductId = 10, IngredientId = 3},
                new { ProductId = 10, IngredientId = 7},
                new { ProductId = 11, IngredientId = 5},
                new { ProductId = 12, IngredientId = 2},
                new { ProductId = 13, IngredientId = 10},
                new { ProductId = 13, IngredientId = 9 },
                new { ProductId = 13, IngredientId = 6}
                ); 
        }
    }
}
