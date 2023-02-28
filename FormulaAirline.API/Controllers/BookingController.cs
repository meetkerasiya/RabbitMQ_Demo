using FormulaAirline.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IMessageProducer _messageProducer;

        public BookingController(ILogger<BookingController> logger,IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }
    }
}
