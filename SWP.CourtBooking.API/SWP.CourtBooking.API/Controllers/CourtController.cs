using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.CourtModel;
using SWP.CourtBooking.Repository.DTO.BookingDetail;
using SWP.CourtBooking.Repository.DTO.Court;
using SWP.CourtBooking.Repository.Models;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/courts")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public CourtController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetCourts()
        {
            var courts = _unitOfWork.CourtRepository.Get();
            return Ok(courts);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourts(String id)
        {
            var existedCourtEntity = _unitOfWork.CourtRepository.GetByID(id);
            _unitOfWork.CourtRepository.Delete(existedCourtEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetCourtById(string id)
        {
            var responseCourt = _unitOfWork.CourtRepository.GetByID(id);
            return Ok(responseCourt);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCourt(String id, RequestCreateCourtModel requestModel)
        {
            var existedCourt = _unitOfWork.CourtRepository.GetByID(id);
            if(existedCourt != null)
            {
                existedCourt.Name = requestModel.Name;
                existedCourt.Status = requestModel.Status;
                existedCourt.Description = requestModel.Description;
                existedCourt.CourtClusterId = requestModel.CourtClusterId;
            }
            _unitOfWork.CourtRepository.Update(existedCourt);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddCourt([FromBody] CourtDTO court)
        {
            if (court == null)
            {
                return BadRequest("BookingDetail data is null");
            }

            // Validate CourtClusterId presence
            if (string.IsNullOrEmpty(court.CourtClusterId))
            {
                return BadRequest("CourtClusterId is required for the CourtCluster");
            }

            var addCourt = new Court
            {
                CourtId = court.CourtId,
                Name = court.Name,
                Status = court.Status,
                Description = court.Description,
                CourtClusterId = court.CourtClusterId
            };

            _unitOfWork.CourtRepository.Insert(addCourt);
            _unitOfWork.Save();

            return Ok(court);
        }
    }
}
