using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult GetBookingById(string id)
        {
            var responseBooking = _unitOfWork.BookingRepository.GetByID(id);
            return Ok(responseBooking);
        }
    }
}
