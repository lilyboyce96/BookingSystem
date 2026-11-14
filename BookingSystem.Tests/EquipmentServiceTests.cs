using BookingSystem.Models;
using BookingSystem.Repositories;
using BookingSystem.Services;
using Xunit;

namespace BookingSystem.Tests;

public class EquipmentServiceTests
{
    [Fact]
    public void MarkItemUnavailable_ShouldPreserveExistingBookings()
    {
        // Arrange - skapa utrustning och en befintlig bokning
        EquipmentRepository equipmentRepository = new();
        BookingRepository bookingRepository = new();

        EquipmentItem item = new("MASKIN-001");
        equipmentRepository.AddItem(item);

        Booking booking = new(
            "BOK-001",
            "MASKIN-001",
            new DateOnly(2026, 11, 20),
            new DateOnly(2026, 11, 22),
            1500m);

        bookingRepository.AddBooking(booking);

        EquipmentService service = new(equipmentRepository);

        // Act - markera utrustningen som otillgänglig
        service.MarkItemUnavailable("MASKIN-001", "Trasig motor");

        // Assert - kontrollera att utrustningen ändrats
        Assert.True(item.IsUnavailable);
        Assert.Equal("Trasig motor", item.UnavailabilityReason);

        // Kontrollera att bokningen är oförändrad
        Booking savedBooking =
            Assert.Single(bookingRepository.GetAllBookings());

        Assert.Same(booking, savedBooking);
        Assert.Equal("BOK-001", savedBooking.BookingNumber);
        Assert.Equal("MASKIN-001", savedBooking.InventoryNumber);
        Assert.Equal(new DateOnly(2026, 11, 20), savedBooking.StartDate);
        Assert.Equal(new DateOnly(2026, 11, 22), savedBooking.EndDate);
        Assert.Equal(1500m, savedBooking.AgreedTotalPrice);
    }

    [Fact]
    public void MarkItemUnavailable_WhenAlreadyUnavailable_ShouldKeepOriginalReason()
    {
        // Arrange
        EquipmentRepository repository = new();
        EquipmentItem item = new("MASKIN-001");
        repository.AddItem(item);

        EquipmentService service = new(repository);

        // Act
        service.MarkItemUnavailable("MASKIN-001", "Trasig motor");
        service.MarkItemUnavailable("MASKIN-001", "Service");

        // Assert
        Assert.True(item.IsUnavailable);
        Assert.Equal("Trasig motor", item.UnavailabilityReason);
    }

    [Fact]
    public void MarkItemUnavailable_WhenItemDoesNotExist_ShouldNotThrow()
    {
        // Arrange
        EquipmentRepository repository = new();
        EquipmentService service = new(repository);

        // Act
        Exception? exception = Record.Exception(() =>
            service.MarkItemUnavailable("SAKNAS", "Trasig"));

        // Assert
        Assert.Null(exception);
        Assert.Null(repository.GetItem("SAKNAS"));
    }
}