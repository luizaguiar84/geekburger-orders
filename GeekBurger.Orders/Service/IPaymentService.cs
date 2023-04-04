using GeekBurger.Orders.Contract;

namespace GeekBurger.Orders.Service
{
    public interface IPaymentService
    {
        void Pay(PaymentToUpsert paymentToUpsert);
    }
}
