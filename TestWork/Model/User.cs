using System;
using System.Collections.Generic;

namespace TestWork.Model
{
    public class User
    {
        public User()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBird { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
