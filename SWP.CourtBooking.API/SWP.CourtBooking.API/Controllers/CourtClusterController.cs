﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}