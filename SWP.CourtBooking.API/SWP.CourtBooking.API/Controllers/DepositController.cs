using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/deposits")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public DepositController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetDeposits()
        {
            var deposits = _unitOfWork.DepositRepository.Get();
            return Ok(deposits);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDeposits(String id)
        {
            var existedDepositEntity = _unitOfWork.DepositRepository.GetByID(id);
            _unitOfWork.DepositRepository.Delete(existedDepositEntity);
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
