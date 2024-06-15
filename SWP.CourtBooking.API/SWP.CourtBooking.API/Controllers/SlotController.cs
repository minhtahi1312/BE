using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.SlotModel;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/slots")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public SlotController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetSlots()
        {
            var slots = _unitOfWork.SlotRepository.Get();
            return Ok(slots);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSlots(String id)
        {
            var existedSlotEntity = _unitOfWork.SlotRepository.GetByID(id);
            _unitOfWork.SlotRepository.Delete(existedSlotEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetSlotById(string id)
        {
            var responseSlot = _unitOfWork.SlotRepository.GetByID(id);
            return Ok(responseSlot);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSlot(String id, RequestCreateSlotModel requestModel)
        {
            var existedSlot = _unitOfWork.SlotRepository.GetByID(id);
            if(existedSlot != null)
            {
                existedSlot.Date = requestModel.Date;
                existedSlot.StartTime = requestModel.StartTime;
                existedSlot.EndTime = requestModel.EndTime;
                existedSlot.CourtId = requestModel.CourtId;
            }
            _unitOfWork.SlotRepository.Update(existedSlot);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
