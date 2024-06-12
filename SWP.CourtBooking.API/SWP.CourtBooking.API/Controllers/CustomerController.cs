using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            var customers = _unitOfWork.CustomerRepository.Get();
            return Ok(customers);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomers(String id)
        {
            var existedCustomerEntity = _unitOfWork.CustomerRepository.GetByID(id);
            _unitOfWork.CustomerRepository.Delete(existedCustomerEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
