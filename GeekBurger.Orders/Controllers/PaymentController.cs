using GeekBurger.Orders.Contract;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.Orders.Service;

namespace GeekBurger.Orders.Controllers
{
    [Route("api/pay")]
    public class PaymentController : Controller
    {   
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {   
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult Pay([FromBody] PaymentToUpsert paymentToAdd)
        {
            if (paymentToAdd == null)
                return BadRequest();

            _paymentService.Pay(paymentToAdd);
            
            return Ok();
        }
    }
}



