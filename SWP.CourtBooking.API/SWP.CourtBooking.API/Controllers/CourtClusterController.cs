using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.CourtClusterModel;
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
    }
}
