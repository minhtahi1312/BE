using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/slots")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public SlotController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetSlots()
        {
            var slots = _unitOfWork.SlotRepository.Get();
            return Ok(slots);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var responseCategories = _unitOfWork.BookingRepository.Get();
            return Ok(responseCategories);
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var responseCategories = _unitOfWork.BookingRepository.GetByID(id);
            return Ok(responseCategories);
        }
    }
}
