namespace GeekBurger.Orders.Contract
{
    public class OrderChangedMessage
    {   
        public OrderToGet Order{ get; set; }
        public string State { get; set; }
    }
}
