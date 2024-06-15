namespace SWP.CourtBooking.API.Models.SlotModel
{
    public class RequestCreateSlotModel
    {
        public DateOnly Date { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public string CourtId { get; set; } = null!;
    }
}
