using GeekBurger.Orders.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekBurger.Orders.Repository
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderChangedEvent> OrderChangedEvents { get; set; }

    }
}