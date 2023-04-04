using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekBurger.Orders.Model;

public class OrderChangedEvent
{
    [Key] 
    public Guid EventId { get; set; }

    public OrderState State { get; set; }

    [ForeignKey("ProductId")] 
    public Order Order { get; set; }

    public bool MessageSent { get; set; }
}

public enum OrderState
{
    Deleted = 2,
    Modified = 3,
    Added = 4
}