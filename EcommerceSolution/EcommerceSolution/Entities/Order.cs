using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSolution.Entities
{
    public class Order
    {
        public static int Id = 1;
        public int OrderId { get; set; }
        public int Customer_Id { get; set; }
        public static int GenerateProductId()
        {
            return Id++;
        }
        public int TotalAmount { get; set; }

        public Order(int Id)
        {
            this.Customer_Id = Id;
        }
    }
}
