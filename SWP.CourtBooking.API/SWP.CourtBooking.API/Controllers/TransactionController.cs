using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.TransactionModel;
using SWP.CourtBooking.Repository.DTO.Court;
using SWP.CourtBooking.Repository.DTO.Transaction;
using SWP.CourtBooking.Repository.Models;
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

        [HttpPost]
        public IActionResult AddTransaction([FromBody] TransactionDTO transaction)
        {
            if (transaction == null)
            {
                return BadRequest("Transaction data is null");
            }

            // Validate BookingId presence
            if (string.IsNullOrEmpty(transaction.BookingId))
            {
                return BadRequest("BookingId is required for the Transaction");
            }

            // Validate DepositId presence
            if (string.IsNullOrEmpty(transaction.DepositId))
            {
                return BadRequest("DepositId is required for the Transaction");
            }

            // Validate WalletId presence
            if (string.IsNullOrEmpty(transaction.WalletId))
            {
                return BadRequest("WalletId is required for the Transaction");
            }

            var addTransaction = new Transaction
            {
                TransactionId = transaction.TransactionId,
                TotalSlot = transaction.TotalSlot,
                TotalPrice = transaction.TotalPrice,
                Status = transaction.Status,
                BookingId = transaction.BookingId,
                DepositId = transaction.DepositId,
                WalletId = transaction.WalletId
            };

            _unitOfWork.TransactionRepository.Insert(addTransaction);
            _unitOfWork.Save();

            return Ok(transaction);
        }
    }
}
