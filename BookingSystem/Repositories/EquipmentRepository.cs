using BookingSystem.Models;

namespace BookingSystem.Repositories
{
    public class EquipmentRepository
    {
        private readonly List<EquipmentItem> _items = new();
        public EquipmentItem? GetItem(string inventoryNumber)
        {
            return _items.FirstOrDefault(item => item.InventoryNumber == inventoryNumber);
        }
        public void AddItem(EquipmentItem item)
        {
            _items.Add(item);
        }
        public void SaveItem(EquipmentItem item)
        {
            // Ändringen finns redan i listan eftersom listan innehåller en referens till samma objekt.
        }
    }
}
