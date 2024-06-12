using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
