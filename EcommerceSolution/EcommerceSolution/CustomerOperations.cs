using EcommerceSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSolution
{
    public class CustomerOperations : Store
    {
        public static List<Product> productToBePurchased = new List<Product>();
        public static void buyProducts()
        {
            string anotherorder;
            do
            {
                InventoryManagerOperations.ListOfAllProducts();
                string choice;
                do
                {
                    Console.WriteLine("Enter Product Id to buy");
                    int productId = Convert.ToInt32(Console.ReadLine());
                    var data = products.Single((a) => a.Product_ID == productId);
                    if (data != null)
                    {
                       // bool idsearch = productToBePurchased.Any((r) => r.Product_ID == productId);
                        //if (idsearch)
                        //{
                        //var id = productToBePurchased.Single((r) => r.Product_ID == productId);
                        //id.QuantityAvailable = id.QuantityAvailable + 1;
                        //}
                        //else
                        //{
                        //productToBePurchased.Add(data);
                        //}
                        var idreduce = products.Single((a) => a.Product_ID == productId);
                        if (idreduce.QuantityAvailable >= 1)
                        {
                            productToBePurchased.Add(data);
                            idreduce.QuantityAvailable = idreduce.QuantityAvailable - 1;
                        }
                        else
                        {
                            Console.WriteLine("This Product is currently unavailable");

                        }
                    }
                    Console.WriteLine("Do you want to puchase more products, yes to buy more otherwise no:");
                    choice = Console.ReadLine();
                    
                }
                while (choice == "yes");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Below Are the List of Products you purchased");
                Console.WriteLine();
                ListOfAllPurchasedProducts();
                placeOrder();
                Console.WriteLine("Do you want to place another order, yes to more otherwise no:");
                anotherorder = Console.ReadLine();
                if ( anotherorder == "yes")
                {
                    productToBePurchased.Clear();
                }
            }
            while (anotherorder == "yes");
            string changeuserytype;
            Console.WriteLine("Do you want to login as a Manager?");
            changeuserytype = Console.ReadLine();
            if(changeuserytype == "yes")
            {
                ShowAllMenu.showInventoryManagerMenu();
            }
            else
            {
                Environment.Exit(1);
            }
        }

        public static void ListOfAllPurchasedProducts()
        {
            Console.WriteLine("Product Id" + "\t" + "Product Name" + "\t" + "Product Short Code" + "\t" + "Product Description" + "\t\t" + "Product Price"  +"\t\t" + "Categoty" + "\t\t\t" + "Manufacture\n");
            productToBePurchased.ForEach((i) =>
            {
                string s = "";
                i.ProductCategory.ForEach(c =>
                {
                    s += c.Name + ", ";
                });

                Console.WriteLine($" {i.Product_ID} \t\t{i.Name}\t\t {i.ShortCode}\t\t\t  {i.Description}\t\t\t\t {i.SellingPrice}\t\t{s}\t\t\t {i.ProductManufacturer}");
            });
        }

        public static bool customerlogin()
        {
            Console.WriteLine("Enter UserID for Customer");
            string userId = Console.ReadLine();
            Console.WriteLine("Enter Password for Customer");
            string password = Console.ReadLine();
            UserDb user = new UserDb();
            bool result = user.customer.Any(r => r.UserId == userId && r.Password == password);
            return result;
        }
        public static void placeOrder()
        { 
            Order order = new Order(1);
            int price = 0; 
            productToBePurchased.ForEach(c =>
            {
                price = price + c.SellingPrice;
            });
            order.OrderId = Order.GenerateProductId();
            order.TotalAmount = price;
            showReceipt(order);
        }
        public static void showReceipt(Order order)
        {
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-------------");
            Console.WriteLine("Order Reciept");
            Console.WriteLine("-------------");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Order Id \tCustomerId \tPrice");
            Console.WriteLine(order.OrderId + "\t\t" + order.Customer_Id + "\t\t" +order.TotalAmount);
            Console.WriteLine();
            Console.WriteLine("Thanks For Shoping");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }
    }  
}
