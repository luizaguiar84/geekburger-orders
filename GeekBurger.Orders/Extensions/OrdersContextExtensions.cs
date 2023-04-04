using GeekBurger.Orders.Repository;

namespace GeekBurger.Orders.Extensions
{
    public static class OrdersContextExtensions
    {
        public static void Seed(this OrdersContext context)
        {
            context.Orders.RemoveRange(context.Orders);
            context.SaveChanges();
        }
    }
}