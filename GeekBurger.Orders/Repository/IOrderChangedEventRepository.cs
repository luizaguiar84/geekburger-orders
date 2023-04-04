using GeekBurger.Orders.Model;

namespace GeekBurger.Orders.Repository;

public interface IOrderChangedEventRepository
{
    OrderChangedEvent Get(Guid eventId);
    bool Add(OrderChangedEvent productChangedEvent);
    bool Update(OrderChangedEvent productChangedEvent);
    void Save();
}