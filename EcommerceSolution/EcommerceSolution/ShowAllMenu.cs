using EcommerceSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSolution
{
    public class ShowAllMenu
    {
        public static void showInitialUserMenu()
        {
            while (true)
            {
                Console.WriteLine("!---------------------------------!");
                Console.WriteLine("Welcome to the E-Commerce Solution!");
                Console.WriteLine("Press");
                Console.WriteLine(" 1- Customer Login\n 2- Inventory Manager Login \n 3- Exit");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        bool res = true;
                        do
                        {
                            if(CustomerOperations.customerlogin())
                            {
                                showCustomerMenu();
                                res = false;
                            }
                            else
                            {
                                Console.WriteLine("----Please Enter Correct Username Or Password for Customer to Login----\n");
                            }
                        }
                        while (res);
                        break;
                    case "2":
                        bool resm = true;
                        do
                        {
                            if (InventoryManagerOperations.managerlogin())
                            {
                                showInventoryManagerMenu();
                                resm = false;
                            }
                            else
                            {
                                Console.WriteLine("----Please Enter Correct Username Or Password for Manager to Login----\n");
                            }
                        }
                        while (resm);
                        break;
                    case "3":
                        Environment.Exit(1);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void showInventoryManagerMenu()
        {
            Console.WriteLine("Press");
            Console.WriteLine(" 1- Add Category \n 2- Add Product\n 3- Update Product\n 4- Remove Product \n 5- Login as a Customer");
            string inventoryManagerChoice = Console.ReadLine();
            switch (inventoryManagerChoice)
            {
                case "1":                    
                        string addanothercategory;
                        do
                        {
                            Console.WriteLine("Enter Category Name");
                            var categoryName = Console.ReadLine();
                            Console.WriteLine("Enter Short Code");
                            var shortCode = Console.ReadLine();

                            if (shortCode.Length <= 4)
                            {
                                Console.WriteLine("Enter Description");
                                var desc = Console.ReadLine();
                                InventoryManagerOperations.AddCategory(categoryName, shortCode, desc);
                            }
                            else
                            {
                                Console.WriteLine("Short Code should be less than or equal to 4");
                            }
                            Console.WriteLine("Do You want to add another category, yes to continue otherwise no:");
                            addanothercategory = Console.ReadLine();
                        }
                        while (addanothercategory == "yes");
                        Console.WriteLine("Do you want to login as a Customer, yes to continue otherwise no");
                        string gotocustomer = Console.ReadLine();
                        if(gotocustomer == "yes")
                        {
                            showCustomerMenu();
                        }
                        else
                        {
                            Environment.Exit(1);
                        }                  
                    break;

                case "2":
                    string addanotherproduct;
                    do
                    {
                        Console.WriteLine("Enter Product Name");
                        var productName = Console.ReadLine();
                        Console.WriteLine("Enter Short Code");
                        var sc = Console.ReadLine();
                        if (sc.Length <= 4)
                        {
                            Console.WriteLine("Enter Description");
                            var desc = Console.ReadLine();
                            Console.WriteLine("Enter Price");
                            int price = Convert.ToInt32(Console.ReadLine());

                            if (price > 0)
                            {
                                Console.WriteLine("Enter Quantity");
                                int quantity = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Product Manufacturer Name");
                                var manufactureName = Console.ReadLine();
                                InventoryManagerOperations.AddProduct(productName, sc, desc, price, manufactureName, quantity);
                            }
                            else
                            {
                                Console.WriteLine("Price Should be greater than zero!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Short Code should be less than or equal to 4");
                        }
                        Console.WriteLine("Do you want to add another product, yes to add another otherwise no:");
                        Console.WriteLine();
                        addanotherproduct = Console.ReadLine();
                    }
                    while (addanotherproduct == "yes");
                    Console.WriteLine("Do you want to login as a Customer, yes to continue otherwise no");
                    string gotocustomer2 = Console.ReadLine();
                    if (gotocustomer2 == "yes")
                    {
                        showCustomerMenu();
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                    break;
            
                case "3":
                    string updateAnother;
                    do
                    {
                        Console.WriteLine("Enter the product Id you want to update");
                        int update = Convert.ToInt32(Console.ReadLine());
                        var res = Store.products.Single(item => item.Product_ID == update);
                        string updateAgain;
                        do
                        {
                            Console.WriteLine("1- Update Name");
                            Console.WriteLine("2- Update Price");
                            Console.WriteLine("3- Update Manufacturer");
                            Console.WriteLine("4- Update Quantity");
                            Console.WriteLine("5- Update Category");
                            Console.WriteLine("");
                            int option = Convert.ToInt32(Console.ReadLine());
                            if (option == 1)
                            {
                                Console.WriteLine("Enter the new name");
                                string name = Console.ReadLine();
                                res.Name = name;
                            }
                            else if (option == 2)
                            {
                                Console.WriteLine("Enter the new price");
                                int price = Convert.ToInt32(Console.ReadLine());
                                if (price > 0)
                                {
                                    res.SellingPrice = price;
                                }
                                else
                                {
                                    Console.WriteLine("Please Enter Price greater than zero");
                                    break;
                                }
                            }
                            else if (option == 3)
                            {
                                Console.WriteLine("Enter the new manufacturer");
                                string manufacturer = Console.ReadLine();
                                res.ProductManufacturer = manufacturer;
                            }
                            else if (option == 4)
                            {
                                Console.WriteLine("Enter the new Quantity");
                                int quantity = Convert.ToInt32(Console.ReadLine());
                                if (quantity > 0)
                                {
                                    res.QuantityAvailable = quantity;
                                }
                                else
                                {
                                    Console.WriteLine("Please Enter Quantity Greater Than zero");
                                    break;
                                }
                            }
                            else if (option == 5)
                            {
                                res.ProductCategory.Clear();
                                string choice;
                                do
                                {
                                    Console.WriteLine("Select Category by Id");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    res.ProductCategory.Add(Store.categories[id - 1]);
                                    Console.WriteLine("Do you want to add more catagories, yes to continue otherwise no:");
                                    choice = Console.ReadLine();
                                } while (choice == "yes");
                            }
                            Console.WriteLine("Do you want to update this product again, yes to continue otherwise no:");
                            updateAgain = Console.ReadLine();
                        } while (updateAgain == "yes");

                        Console.WriteLine("Do you want to update another product, yes to continue otherwise no:");
                        updateAnother = Console.ReadLine();
                    } while (updateAnother == "yes");
                    break;

                case "4":
                    string deleteanother;
                    do
                    {
                        Console.WriteLine(" 1- Delete by Id \n 2- Delete By Short Code");
                        string choiceForDelete = Console.ReadLine();
                        removeProduct(choiceForDelete);
                        Console.WriteLine("Do you want to delete another product, yes to continue otherwise no:");
                        deleteanother = Console.ReadLine();
                    }
                    while (deleteanother == "yes");
                    Console.WriteLine("Do you want to login as a Customer, yes to continue otherwise no");
                    string gotocustomer3 = Console.ReadLine();
                    if (gotocustomer3 == "yes")
                    {
                        showCustomerMenu();
                    }
                    else
                    {
                        Environment.Exit(1);
                    }
                    break;

                case "5":
                    showCustomerMenu();
                    break;
                default:
                    break;
            }    
            }
        public static void showCustomerMenu()
        {
            Console.WriteLine("Press");
            Console.WriteLine(" 1- List of Available Products \n 2- Buy Product \n");
            string customerChoice = Console.ReadLine();
            switch(customerChoice)
            {
                case "1":
                    Console.WriteLine();
                    Console.WriteLine("Available Products");
                    Console.WriteLine();
                    InventoryManagerOperations.ListOfAllProducts();
                    Console.WriteLine();
                    break;
                case "2":
                    Console.WriteLine();
                    Console.WriteLine("Available Products");
                    Console.WriteLine();
                    CustomerOperations.buyProducts();
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
        }

        public static void removeProduct(string choice)
        {
            switch(choice)
            {
                case "1":
                    InventoryManagerOperations.removeById();
                    break;
                case "2":
                    InventoryManagerOperations.removeByShortCode();
                    break;

            }
        }
    }
}
