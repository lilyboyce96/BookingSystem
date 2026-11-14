using BookingSystem.Repositories;
using BookingSystem.Models;

namespace BookingSystem.Services
{
    public class EquipmentService
    {
        private readonly EquipmentRepository _repository;
        public EquipmentService(EquipmentRepository repository)
        {
            _repository = repository;
        }
        public void MarkItemUnavailable(string inventoryNumber, string reason)
        {
            EquipmentItem? item = _repository.GetItem(inventoryNumber);
            
            if (item == null)
            {
                Console.WriteLine("Exemplaret hittades inte.");
                return;

            }
            if (item.IsUnavailable == true)
            {
                Console.WriteLine("Exemplaret är redan otillgängligt");
                return;
            }
            item.MarkUnavailable(reason);
            _repository.SaveItem(item);

            Console.WriteLine("Exemplaret har markerats som otillgängligt.");
            Console.WriteLine("Befintliga bokningar har inte ändrats.");
        }
        
    }
}
