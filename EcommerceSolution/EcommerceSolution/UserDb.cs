using EcommerceSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSolution
{
    public class UserDb : User
    {
        public  List<User> customer = new List<User>()
        {
            new User()
            {
                UserId= "ha123",
                Password= "password",
                FullName= "Rajat", 
            },
            new User()
            {
                UserId= "gaurav123",
                Password= "password",
                FullName= "Gaurav",
                
            },

            new User()
            {
                UserId ="sachin123",
                Password ="password",
                FullName = "Sachin", 
            }
        };

        public List<User> manager = new List<User>()
        {
            new User()
            {
                UserId = "harsh123",
                Password= "password",
                FullName= "Harsh",
            },

            new User()
            {
                UserId= "rohit123",
                Password= "password",
                FullName= "Rohit",
            },
        };
    }
}
