using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.DepositModel;
using SWP.CourtBooking.Repository.DTO.Customer;
using SWP.CourtBooking.Repository.DTO.Deposit;
using SWP.CourtBooking.Repository.Models;
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
        public ActionResult GetDepositById(string id)
        {
            var responseDeposit = _unitOfWork.DepositRepository.GetByID(id);
            return Ok(responseDeposit);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateDeposit(String id, RequestCreateDepositModel requestModel)
        {
            var existedDeposit = _unitOfWork.DepositRepository.GetByID(id);
            if(existedDeposit != null)
            {
                existedDeposit.CustomerId = requestModel.CustomerId;
                existedDeposit.Amount = requestModel.Amount;
                existedDeposit.VnpayCode = requestModel.VnpayCode;
                existedDeposit.Time = requestModel.Time;
            }
            _unitOfWork.DepositRepository.Update(existedDeposit);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddDeposit([FromBody] DepositDTO deposit)
        {
            if (deposit == null)
            {
                return BadRequest("Deposit data is null");
            }

            // Validate CustomerId presence
            if (string.IsNullOrEmpty(deposit.CustomerId))
            {
                return BadRequest("CustomerId is required for the Deposit");
            }

            var addDeposit = new Deposit
            {
                DepositId = deposit.DepositId,
                CustomerId = deposit.CustomerId,
                Amount = deposit.Amount,
                VnpayCode = deposit.VnpayCode,
                Time = deposit.Time
            };

            _unitOfWork.DepositRepository.Insert(addDeposit);
            _unitOfWork.Save();

            return Ok(deposit);
        }
    }
}
