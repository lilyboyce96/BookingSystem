namespace BookingSystem.Models
{
    public class Booking
    {
        public string BookingNumber { get; }
        public string InventoryNumber { get; }
        public DateOnly StartDate { get; }
        public DateOnly EndDate { get; }
        public decimal AgreedTotalPrice { get; }
        

        public Booking(string bookingNumber, string inventoryNumber, DateOnly startDate, DateOnly endDate, decimal agreedTotalPrice)
        {
            BookingNumber = bookingNumber;
            InventoryNumber = inventoryNumber;
            StartDate = startDate;
            EndDate = endDate;
            AgreedTotalPrice = agreedTotalPrice;
        }
    }
}
