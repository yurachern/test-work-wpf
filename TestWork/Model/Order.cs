using System;
using System.Collections.Generic;

namespace TestWork.Model
{
    public class Order
    {
        public Order()
        {
            OrderLines = new List<OrderLine>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual User User { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }
}
