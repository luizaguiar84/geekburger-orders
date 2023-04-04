using AutoMapper;
using GeekBurger.Orders.Contract;
using GeekBurger.Orders.Model;
using GeekBurger.Orders.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekBurger.Orders.Controllers
{
    [Route("api/order")]
    public class OrderController : Controller
    {

        private IOrdersRepository _ordersRepository;
        private IMapper _mapper;

        public OrderController(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderToUpsert orderToAdd)
        {
            if (orderToAdd == null)
                return BadRequest();

            var order = _mapper.Map<Order>(orderToAdd);
            if (order.StoreId == Guid.Empty)
                return BadRequest(ModelState);

            _ordersRepository.Add(order);
            _ordersRepository.Save();

            var orderToGet = _mapper.Map<OrderToGet>(order);
            return CreatedAtRoute(new { OrderId = orderToGet.OrderId }, orderToGet);
        }

        [HttpGet]
        public IActionResult GetOrder(Guid OrderId)
        {
            var order = _ordersRepository.GetOrderById(OrderId);
            if (order == null)
                return NotFound();
            
            var orderToGet = _mapper.Map<OrderToGet>(order);
            return Ok(orderToGet);
        }
    }
}