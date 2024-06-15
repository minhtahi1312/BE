using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.TransactionModel;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public TransactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetTransactions()
        {
            var transacstions = _unitOfWork.TransactionRepository.Get();
            return Ok(transacstions);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTransactions(String id)
        {
            var existedTransactionEntity = _unitOfWork.TransactionRepository.GetByID(id);
            _unitOfWork.TransactionRepository.Delete(existedTransactionEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetTransactionById(string id)
        {
            var responseTransaction = _unitOfWork.TransactionRepository.GetByID(id);
            return Ok(responseTransaction);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTransaction(String id, RequestCreateTransactionModel requestModel)
        {
            var existedTransaction = _unitOfWork.TransactionRepository.GetByID(id);
            if(existedTransaction != null)
            {
                existedTransaction.TotalSlot = requestModel.TotalSlot;
                existedTransaction.TotalPrice = requestModel.TotalPrice;
                existedTransaction.Status = requestModel.Status;
                existedTransaction.BookingId = requestModel.BookingId;
                existedTransaction.WalletId = requestModel.WalletId;
                existedTransaction.DepositId = requestModel.DepositId;
            }
            _unitOfWork.TransactionRepository.Update(existedTransaction);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
