using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.WalletModel;
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
        public ActionResult GetWalletById(string id)
        {
            var responseWallet = _unitOfWork.WalletRepository.GetByID(id);
            return Ok(responseWallet);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateWallet(String id, RequestCreateWalletModel requestModel)
        {
            var existedWallet = _unitOfWork.WalletRepository.GetByID(id);
            if(existedWallet != null)
            {
                existedWallet.CustomerId = requestModel.CustomerId;
                existedWallet.Amount = requestModel.Amount;
            }
            _unitOfWork.WalletRepository.Update(existedWallet);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
