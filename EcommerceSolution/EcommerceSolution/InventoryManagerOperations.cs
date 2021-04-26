using EcommerceSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSolution
{
    public class InventoryManagerOperations : Store
    {
        public static void AddCategory(string categoryName, string shortCode, string description)
        {
            categories.Add(new Category
            {
                ID = Category.GenerateCategoryId(),
                Name = categoryName,
                ShortCode = shortCode,
                Description = description
            });
             ListOfAllCategories();
        }

        public static void ListOfAllCategories()
        {
            Console.WriteLine("Category Id" + "\t" + "Category Name" + "\t" + "Category Short Code" + "\t" + "Category Description\n");
            categories.ForEach((i) =>
            {
                Console.WriteLine($"{i.ID} \t\t {i.Name}\t\t{i.ShortCode}\t\t{i.Description}");
            });
        }

        public static void AddProduct(string ProductName, string shortCode, string desc, int price, string manufactureName, int quantity)
        {
            categories.ForEach((i) =>
            {
                Console.WriteLine(i.ID + " -" + i.Name);
            });
            List<Category> productCategories = new List<Category>();
            string choice;
            do
            {
                Console.WriteLine("Select Category By Id For Adding a Product");
                int id = Convert.ToInt32(Console.ReadLine());
                var data = categories.Single((a) => a.ID == id);
                if (data != null)
                    productCategories.Add(data);
                Console.WriteLine("Do you want to add more catagories, yes to continue otherwise no:");
                choice = Console.ReadLine();
            } while (choice == "yes");

            products.Add(new Product
            {
                Product_ID = Product.GenerateProductId(),
                Name = ProductName,
                ShortCode = shortCode,
                Description = desc,
                SellingPrice = price,
                QuantityAvailable = quantity,
                ProductCategory = productCategories,
                ProductManufacturer = manufactureName

            });
            ListOfAllProducts();
        }

        public static void ListOfAllProducts()
        {
            Console.WriteLine("Product Id" + "\t" + "Product Name" + "\t" + "Product Short Code" + "\t" + "Product Description" + "\t\t" + "Product Price" + "\t\t" + "Available" +"\t\t" + "Categoty" + "\t\t\t\t" + "Manufacture\n");
            products.ForEach((i) =>
            {
                string s = "";
                i.ProductCategory.ForEach(c => {
                    s += c.Name + ", ";
                });
                Console.WriteLine($" {i.Product_ID} \t\t{i.Name}\t\t {i.ShortCode}\t\t\t  {i.Description}\t\t\t\t {i.SellingPrice}\t\t {i.QuantityAvailable}\t\t{s}\t\t\t\t {i.ProductManufacturer}");
            });
        }

        public static void removeById()
        {
            Console.WriteLine("Enter Id of the product to Remove");
            int id = Convert.ToInt32(Console.ReadLine());
            products.RemoveAt(id - 1);
            Product.ID = Product.ID - 1;
        }

        public static void removeByShortCode()
        {
            Console.WriteLine("Enter Short Code of the product to Remove");
            string sc = Console.ReadLine();
            var categoryToRemove = products.Single(r => r.ShortCode == sc);
            products.Remove(categoryToRemove);
            Product.ID = Product.ID - 1;
        }

        public static bool managerlogin()
        {
            Console.WriteLine("Enter UserID for Manager");
            string userId = Console.ReadLine();
            Console.WriteLine("Enter Password for Manager");
            string password = Console.ReadLine();
            UserDb user = new UserDb();
            bool result = user.manager.Any(r => r.UserId == userId && r.Password == password);
            return result;
        }
    }
}
