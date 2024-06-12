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
