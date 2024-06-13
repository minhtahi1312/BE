using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _unitOfWork.UserRepository.Get();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUsers(String id)
        {
            var existedUserEntity = _unitOfWork.UserRepository.GetByID(id);
            _unitOfWork.UserRepository.Delete(existedUserEntity);
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
