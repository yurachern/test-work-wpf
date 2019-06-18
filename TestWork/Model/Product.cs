using System.Collections.Generic;

namespace TestWork.Model
{
    public class Product
    {
        public Product()
        {
            OrderLines = new List<OrderLine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<OrderLine> OrderLines { get; set; }
    }
}
