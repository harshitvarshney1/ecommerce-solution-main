using EcommerceSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSolution
{   
    public class Store
    {
        public static List<Category> categories = new List<Category>()
        {
            new Category()
            {
              ID = Category.GenerateCategoryId(),
              Name="Stationary",
              ShortCode="Stry",
              Description="Stationary goods"
            },
            new Category()
            {
                ID = Category.GenerateCategoryId(),
                Name="Sports",
                ShortCode="Sprt",
                Description="Sports goods"
            },
            new Category()
            {
                ID = Category.GenerateCategoryId(),
                Name="Food",
                ShortCode="FOOD",
                Description="Food"
            },
            new Category()
            {
                ID = Category.GenerateCategoryId(),
                Name="Home Items",
                ShortCode="HTM",
                Description="Home"
            }
        };

        public static List<Product> products = new List<Product>()
        {
            new Product()
            {
                Product_ID = Product.GenerateProductId(),
                Name = "Bat",
                ShortCode = "BAT",
                Description = "Wooden Bat",
                SellingPrice = 1000,    
                QuantityAvailable = 5,
                ProductCategory = new List<Category>() {categories[1]},
                ProductManufacturer = "Adidas"
            },

            new Product()
            {
                Product_ID = Product.GenerateProductId(),
                Name = "Pen",
                ShortCode = "PEN",
                Description = "Black Color",
                SellingPrice = 50,
                QuantityAvailable = 10,
                ProductCategory = new List<Category>() {categories[0]},
                ProductManufacturer = "Renoylds"
            },

            new Product()
            {
                Product_ID = Product.GenerateProductId(),
                Name = "Buccket",
                ShortCode = "BOCK",
                Description = "12 L",
                SellingPrice = 250,
                QuantityAvailable = 3,
                ProductCategory = new List<Category>() {categories[3]},
                ProductManufacturer = "Cello"
            },

            new Product()
            {
                Product_ID = Product.GenerateProductId(),
                Name = "Banana",
                ShortCode = "Bana",
                Description = "12 Pieces",
                SellingPrice = 80,
                QuantityAvailable = 4,
                ProductCategory = new List<Category>() {categories[2]},
                ProductManufacturer = "Big Bazar"
            },
        };
    }
}
