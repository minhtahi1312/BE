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

        [HttpDelete("{id}")]
        public ActionResult DeleteCourts(String id)
        {
            var existedCourtEntity = _unitOfWork.CourtRepository.GetByID(id);
            _unitOfWork.CourtRepository.Delete(existedCourtEntity);
            _unitOfWork.Save();
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetBookingById(string id)
        {
            var responseBooking = _unitOfWork.BookingRepository.GetByID(id);
            return Ok(responseBooking);
        }
    }
}
