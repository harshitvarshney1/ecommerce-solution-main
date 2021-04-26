using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSolution.Entities
{
    public class Category
    {
        public static int Id = 1;
        public int ID { get; set; }
        public static int GenerateCategoryId()
        {
            return Id++;
        }
        public string Name { get; set; }
        public string ShortCode { get; set; }
        public string Description { get; set; }
    }
}
