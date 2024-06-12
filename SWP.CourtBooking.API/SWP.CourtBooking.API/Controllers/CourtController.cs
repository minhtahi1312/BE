using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/courts")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public CourtController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetCourts()
        {
            var courts = _unitOfWork.CourtRepository.Get();
            return Ok(courts);
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
