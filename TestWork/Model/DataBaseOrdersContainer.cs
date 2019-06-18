using System.Data.Entity;

namespace TestWork.Model
{
    public class DataBaseOrdersContainer : DbContext
    {      
        public DataBaseOrdersContainer() : base("name=DataBaseOrdersContainer")
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}
