using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.CustomerModel;
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

        [HttpGet("{id}")]
        public ActionResult GetCustomerById(string id)
        {
            var responseCustomer = _unitOfWork.CustomerRepository.GetByID(id);
            return Ok(responseCustomer);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(String id, RequestCreateCustomerModel requestModel)
        {
            var existedCustomer = _unitOfWork.CustomerRepository.GetByID(id);
            if(existedCustomer != null)
            {
                existedCustomer.Name = requestModel.Name;
                existedCustomer.Email = requestModel.Email;
                existedCustomer.Phone = requestModel.Phone;
                existedCustomer.Address = requestModel.Address;
                existedCustomer.Birthday = requestModel.Birthday;
                existedCustomer.Gender = requestModel.Gender;
                existedCustomer.IsActive = requestModel.IsActive;
                existedCustomer.Username = requestModel.Username;
                existedCustomer.Password = requestModel.Password;
            }
            _unitOfWork.CustomerRepository.Update(existedCustomer);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
