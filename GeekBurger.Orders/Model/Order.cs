using System.ComponentModel.DataAnnotations;

namespace GeekBurger.Orders.Model
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid StoreId { get; set; }
        public decimal Total { get; set; }
        public string? State { get; internal set; }
    }
}
