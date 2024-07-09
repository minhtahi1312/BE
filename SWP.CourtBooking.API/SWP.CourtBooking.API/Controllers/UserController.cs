using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.UserModel;
using SWP.CourtBooking.Repository.DTO.Transaction;
using SWP.CourtBooking.Repository.DTO.User;
using SWP.CourtBooking.Repository.Models;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _unitOfWork.UserRepository.Get();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUsers(String id)
        {
            var existedUserEntity = _unitOfWork.UserRepository.GetByID(id);
            _unitOfWork.UserRepository.Delete(existedUserEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetUserById(string id)
        {
            var responseUser = _unitOfWork.UserRepository.GetByID(id);
            return Ok(responseUser);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(String id, RequestCreateUserModel requestModel)
        {
            var existedUser = _unitOfWork.UserRepository.GetByID(id);
            if (existedUser != null)
            {
                existedUser.Name = requestModel.Name;
                existedUser.Email = requestModel.Email;
                existedUser.Phone = requestModel.Phone;
                existedUser.Address = requestModel.Address;
                existedUser.Birthday = requestModel.Birthday;
                existedUser.Gender = requestModel.Gender;
                existedUser.IsActive = requestModel.IsActive;
                existedUser.Role = requestModel.Role;
                existedUser.Username = requestModel.Username;
                existedUser.Password = requestModel.Password;
            }
            _unitOfWork.UserRepository.Update(existedUser);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDTO user)
        {
            if (user == null)
            {
                return BadRequest("User data is null");
            }

            var addUser = new User
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                Birthday = user.Birthday,
                Gender = user.Gender,
                IsActive = user.IsActive,
                Role = user.Role,
                Username = user.Username,
                Password = user.Password
            };

            _unitOfWork.UserRepository.Insert(addUser);
            _unitOfWork.Save();

            return Ok(user);
        }
    }
}
