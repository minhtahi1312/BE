using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/wallets")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public WalletController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetWallets()
        {
            var wallets = _unitOfWork.WalletRepository.Get();
            return Ok(wallets);
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
