using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSolution.Entities
{
    public class Product : Category
    {
        public static int ID = 1;
        public int Product_ID { get; set; }
        public static int GenerateProductId()
        {
            return ID++;
        }
        public string ProductManufacturer { get; set; }
        public List<Category> ProductCategory { get; set; }
        public int SellingPrice { get; set; }
        public int QuantityAvailable { get; set; }
        public Product()
        {
            this.ProductCategory = new List<Category>();
        }
    }
}

