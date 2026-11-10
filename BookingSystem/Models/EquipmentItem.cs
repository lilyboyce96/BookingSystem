namespace BookingSystem.Models
{
    public class EquipmentItem
    {
        public string InventoryNumber { get; }
        public bool IsUnavailable { get; private set; }
        public string? UnavailabilityReason { get; private set; }

        public EquipmentItem (string inventoryNumber)
        {
            InventoryNumber = inventoryNumber;
            IsUnavailable = false;
            UnavailabilityReason = null;
        }
        public void MarkUnavailable(string reason)
        {
            IsUnavailable = true;
            UnavailabilityReason = reason;
        }
    }

}