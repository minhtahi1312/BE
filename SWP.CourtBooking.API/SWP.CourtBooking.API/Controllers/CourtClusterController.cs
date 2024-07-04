using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.CourtClusterModel;
using SWP.CourtBooking.Repository.DTO.Court;
using SWP.CourtBooking.Repository.DTO.CourtCluster;
using SWP.CourtBooking.Repository.Models;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/courtClusters")]
    [ApiController]
    public class CourtClusterController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public CourtClusterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetCourtClusters()
        {
            var courtClusters = _unitOfWork.CourtClusterRepository.Get();
            return Ok(courtClusters);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCourtClusters(String id)
        {
            var existedCourtClusterEntity = _unitOfWork.CourtClusterRepository.GetByID(id);
            _unitOfWork.CourtClusterRepository.Delete(existedCourtClusterEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetCourtClusterById(string id)
        {
            var responseCourtCluster = _unitOfWork.CourtClusterRepository.GetByID(id);
            return Ok(responseCourtCluster);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCourtCluster(String id, RequestCreateCourtClusterModel requestModel)
        {
            var existedCourtCluster = _unitOfWork.CourtClusterRepository.GetByID(id);
            if(existedCourtCluster != null)
            {
                existedCourtCluster.Name = requestModel.Name;
                existedCourtCluster.Price = requestModel.Price;
                existedCourtCluster.Description = requestModel.Description;
                existedCourtCluster.Status = requestModel.Status;
                existedCourtCluster.Location = requestModel.Location;
                existedCourtCluster.Image = requestModel.Image;
                existedCourtCluster.UserId = requestModel.UserId;
            }
            _unitOfWork.CourtClusterRepository.Update(existedCourtCluster);
            _unitOfWork.Save();
            return Ok();
        }


        [HttpPost]
        public IActionResult AddCourtCluster([FromBody] CourtClusterDTO courtCluster)
        {
            if (courtCluster == null)
            {
                return BadRequest("BookingDetail data is null");
            }

            // Validate UserId presence
            if (string.IsNullOrEmpty(courtCluster.UserId))
            {
                return BadRequest("UserId is required for the CourtCluster");
            }

            var addCourtCluster = new CourtCluster
            {
                CourtClusterId = courtCluster.CourtClusterId,
                Name = courtCluster.Name,
                Price = courtCluster.Price,
                Description = courtCluster.Description,
                Status = courtCluster.Status,
                Location = courtCluster.Location,
                Image = courtCluster.Image,
                UserId = courtCluster.UserId
            };

            _unitOfWork.CourtClusterRepository.Insert(addCourtCluster);
            _unitOfWork.Save();

            return Ok(courtCluster);
        }
    }
}
