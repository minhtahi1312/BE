using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.BookingDetailModel;
using SWP.CourtBooking.Repository.DTO.Booking;
using SWP.CourtBooking.Repository.DTO.BookingDetail;
using SWP.CourtBooking.Repository.Models;
using SWP.CourtBooking.Repository.UnitOfWork;

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/bookingDetails")]
    [ApiController]
    public class BookingDetailController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public BookingDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetBookingDetails()
        {
            var bookingDetails = _unitOfWork.BookingDetailRepository.Get();
            return Ok(bookingDetails);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBookingDetails(String id)
        {
            var existedBookingDetailEntity = _unitOfWork.BookingDetailRepository.GetByID(id);
            _unitOfWork.BookingDetailRepository.Delete(existedBookingDetailEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetBookingById(string id)
        {
            var responseBookingDetail = _unitOfWork.BookingDetailRepository.GetByID(id);
            return Ok(responseBookingDetail);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBookingDetail(String id, RequestCreateBookingDetailModel requestModel)
        {
            var existedBookingDetail = _unitOfWork.BookingDetailRepository.GetByID(id);
            if(existedBookingDetail != null)
            {
                existedBookingDetail.BookingId = requestModel.BookingId;
                existedBookingDetail.SlotId = requestModel.SlotId;
                existedBookingDetail.Price = requestModel.Price;
            }
            _unitOfWork.BookingDetailRepository.Update(existedBookingDetail);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddBookingDetail([FromBody] BookingDetailDTO bookingDetail)
        {
            if (bookingDetail == null)
            {
                return BadRequest("BookingDetail data is null");
            }

            // Validate BookingId presence
            if (string.IsNullOrEmpty(bookingDetail.BookingId))
            {
                return BadRequest("BookingId is required for the BookingDetail");
            }

            // Validate SlotId presence
            if (bookingDetail.SlotId == 0)
            {
                return BadRequest("SlotId is required for the BookingDetail");
            }

            var addBookingDetail = new BookingDetail
            {
                BookingDetailId = bookingDetail.BookingDetailId,
                BookingId = bookingDetail.BookingId,
                SlotId = bookingDetail.SlotId,
                Price = bookingDetail.Price
            };

            _unitOfWork.BookingDetailRepository.Insert(addBookingDetail);
            _unitOfWork.Save();

            return Ok(bookingDetail);
        }
    }
}
