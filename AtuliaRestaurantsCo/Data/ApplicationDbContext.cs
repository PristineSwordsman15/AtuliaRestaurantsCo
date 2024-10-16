using AtuliaRestaurantsCo.Models;
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
               new Category { CategoryId = 1, CategoryName = "Appetizer" },
               new Category { CategoryId = 2, CategoryName = "Main" },
               new Category { CategoryId = 3, CategoryName = "Dessert" },
               new Category { CategoryId = 4, CategoryName = "Beverage" }
           );

            builder.Entity<Ingredient>().HasData(
             //add indian restaurant ingredients here
             new Ingredient { IngredientId = 1, IngredientName = "Potato" },
             new Ingredient { IngredientId = 2, IngredientName = "Chicken" },
             new Ingredient { IngredientId = 3, IngredientName = "Fish" },
             new Ingredient { IngredientId = 4, IngredientName = "Naan" },
             new Ingredient { IngredientId = 5, IngredientName = "Spinach" },
             new Ingredient { IngredientId = 6, IngredientName = "Tomato" },
             new Ingredient { IngredientId = 7, IngredientName = "White Rice" },
             new Ingredient { IngredientId = 8, IngredientName = "Peas" },
             new Ingredient { IngredientId = 9, IngredientName = "Coriander" },
             new Ingredient { IngredientId = 10, IngredientName = "Lentils" },
             new Ingredient { IngredientId = 11, IngredientName = "Gulab Jamun" },
             new Ingredient { IngredientId = 12, IngredientName = "Ice Cream" },
             new Ingredient { IngredientId = 13, IngredientName = "Water" },
             new Ingredient { IngredientId = 14, IngredientName = "Mango Lassi" },
             new Ingredient { IngredientId = 15, IngredientName = "Coke" }


         );
            builder.Entity<Product>().HasData(
                //add indian restaurant offering here
                new Product
                {
                    ProductId = 1,
                    ProductName = "Naan",
                    Description = "A fluffy bread popular in North India",
                    Price = 7.99m,
                    Stock = 25,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Fried Rice",
                    Description = "Mild yummy rice with peas",
                    Price = 10.99m,
                    Stock = 40,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Aloo Fry",
                    Description = "Fried Potato Curry served with Naan and Rice",
                    Price = 8.50m,
                    Stock = 10,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Coke",
                    Description = "Chilled Fizzy Beverage",
                    Price = 2.99m,
                    Stock = 50,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Water",
                    Description = "Beverage",
                    Price = 3.99m,
                    Stock = 50,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Mango Lassi",
                    Description = "Cool Mango drink",
                    Price = 5.00m,
                    Stock = 20,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 7,
                    ProductName = "Gulab Jamun",
                    Description = "Indian sweet made with milk powder",
                    Price = 4.99m,
                    Stock = 30,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 8,
                    ProductName = "Ice Cream",
                    Description = "Frozen dessert",
                    Price = 2.99m,
                    Stock = 60,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 9,
                    ProductName = "Butter Chicken",
                    Description = "Chiken flavoured lightly in spices and served with rice",
                    Price = 20.99m,
                    Stock = 30,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 10,
                    ProductName = "Fish Madrasi",
                    Description = "Fish curry served with rice",
                    Price = 19.99m,
                    Stock = 20,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 11,
                    ProductName = "Palak Fritters",
                    Description = "Spinach deepfried coated in batter",
                    Price = 6.99m,
                    Stock = 30,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 12,
                    ProductName = "Chicken Lollipops",
                    Description = "Chicken lightly coated in spices and fried",
                    Price = 8.9m,
                    Stock = 30,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 13,
                    ProductName = "Daal Fry",
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
