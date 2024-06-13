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

        [HttpDelete("{id}")]
        public ActionResult DeleteWallets(String id)
        {
            var existedWalletEntity = _unitOfWork.WalletRepository.GetByID(id);
            _unitOfWork.WalletRepository.Delete(existedWalletEntity);
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
