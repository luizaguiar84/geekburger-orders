﻿namespace GeekBurger.Orders.Contract
{
    public class NewOrderMessage
    {
        public Guid OrderId { get; set; }
        public Guid StoreId { get; set; }
        public Decimal Total { get; set; }
        public Guid[] ProductionIds { get; set; }
        public ProductToUpsert[] Products { get; set; }
    }
}
