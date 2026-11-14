using BookingSystem.Models;
using BookingSystem.Repositories;
using BookingSystem.Services;


Console.WriteLine("Booking System har startat!");

EquipmentRepository equipmentRepository = new EquipmentRepository();

EquipmentItem machine = new EquipmentItem("MASKIN-001");

equipmentRepository.AddItem(machine);

BookingRepository bookingRepository = new BookingRepository();

Booking booking = new Booking(
    "BOK-001",
    "MASKIN-001",
    new DateOnly(2026, 11, 20),
    new DateOnly(2026, 11, 22),
    1500m
);

bookingRepository.AddBooking(booking);

EquipmentService equipmentService = new EquipmentService(equipmentRepository);

Console.WriteLine("\nBokningar före ändringen:");
foreach (Booking b in bookingRepository.GetAllBookings())
{
    Console.WriteLine($"{b.BookingNumber} - {b.InventoryNumber}");
}

equipmentService.MarkItemUnavailable("MASKIN-001", "Trasig motor");

Console.WriteLine("\nBokningar efter ändringen:");
foreach (Booking b in bookingRepository.GetAllBookings())
{
    Console.WriteLine($"{b.BookingNumber} - {b.InventoryNumber}");
}