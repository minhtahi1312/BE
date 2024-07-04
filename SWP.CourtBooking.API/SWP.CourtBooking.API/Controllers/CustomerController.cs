using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.CustomerModel;
using SWP.CourtBooking.Repository.DTO.Court;
using SWP.CourtBooking.Repository.DTO.Customer;
using SWP.CourtBooking.Repository.Models;
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

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerDTO customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is null");
            }

            var addCustomer = new Customer
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                Birthday = customer.Birthday,
                Gender = customer.Gender,
                IsActive = customer.IsActive,
                Username = customer.Username,
                Password = customer.Password
            };

            _unitOfWork.CustomerRepository.Insert(addCustomer);
            _unitOfWork.Save();

            return Ok(customer);
        }
    }
}
