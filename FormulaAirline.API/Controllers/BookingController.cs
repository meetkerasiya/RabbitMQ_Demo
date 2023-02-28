using FormulaAirline.API.Models;
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

        //In-memory db
        public static readonly List<Booking> _bookings=new();

        public BookingController(ILogger<BookingController> logger,IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking newBooking)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _bookings.Add(newBooking);

            _messageProducer.SendingMessages<Booking>(newBooking);

            return Ok();
        }
    }
}
