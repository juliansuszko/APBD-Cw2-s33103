using System.Reflection.PortableExecutable;
using EquipmentRental.Enums;
using EquipmentRental.Models;

namespace EquipmentRental.Services;

public class RentalService
{
    private DataStore  _dataStore;
    private int penalty = 5;
    
    public RentalService(DataStore dataStore)
    {
        _dataStore = dataStore;
    }

    public Rental RentEquipment(User user, Equipment equipment, int days)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            throw new InvalidOperationException($"{equipment.Name} is not available.");
        }

        int rentalsCount = 0;
        int maxRentalsCount = user.MaxRentals;
        
        foreach (Rental rental in _dataStore.Rentals)
        {
            if (rental.RentingUser == user && rental.ReturnDate == null)
            {
                rentalsCount++;
            }
        }

        if (rentalsCount >= maxRentalsCount)
        {
            throw new InvalidOperationException($"{user.Name} cannot have more than {maxRentalsCount} rentals.");
        }
        
        var newRental = new Rental(user, equipment, days);
        _dataStore.Rentals.Add(newRental);
        return newRental;
    }

    public int ReturnEquipment(Rental rental, DateTime returnDate)
    {
        if (rental.ReturnDate != null)
        {
            throw new InvalidOperationException("This rental is already returned");
        }
        
        rental.EndRental(returnDate);

        if (rental.IsReturnLate())
        {
            int delay = (returnDate - rental.EndDate).Days;
            return delay * penalty;
        }

        return 0;
    }

    public void MarkEquipmentAsBroken(Equipment equipment)
    {
        if (equipment.Status != EquipmentStatus.Rented)
        {
            throw new InvalidOperationException($"{equipment.Name} is rented.");
        }
        
        equipment.Status = EquipmentStatus.Unavailable;
    }
}