using System;
using EquipmentRental.Enums;
using EquipmentRental.Models;

namespace EquipmentRental.Services;

public class DisplayManager
{
    private DataStore _dataStore;
    private RentalService _rentalService;
    
    
    public DisplayManager(DataStore dataStore, RentalService rentalService)
    {
        _dataStore = dataStore;
        _rentalService = rentalService;
    }

    public void DisplayAllEquipment()
    {
        Console.WriteLine("All equipment:");
        foreach (Equipment equipment in _dataStore.EquipmentList)
        {
            Console.WriteLine(equipment.Name + equipment.Status);
        }
    }

    public void DisplayAllAvailableEquipment()
    {
        Console.WriteLine("All available equipment:");
        foreach (Equipment equipment in _dataStore.EquipmentList)
        {
            if (equipment.Status == EquipmentStatus.Available)
            {
                Console.WriteLine(equipment.Name);
            }
        }
    }

    public void DisplayUserRentals(User user)
    {
        Console.WriteLine($"User {user.Name} {user.Surname} rentals:");
        foreach (Rental rental in _dataStore.Rentals)
        {
            if (rental.RentingUser == user && rental.ReturnDate == null)
            {
                Console.WriteLine(rental.RentedEquipment.Name);
            }
        }
    }

    public void DisplayLateRentals()
    {
        Console.WriteLine("Late rentals:");
        foreach (Rental rental in _dataStore.Rentals)
        {
            if (rental.IsReturnLate())
            {
                Console.WriteLine(rental);
            }
        }
    }

    public void DisplaySystemReport()
    {
        Console.WriteLine("System Report:");
        Console.WriteLine(" ");
        Console.WriteLine($"Users count - {_dataStore.Users.Count}");
        Console.WriteLine($"Equipment count - {_dataStore.EquipmentList.Count}");
        Console.WriteLine($"Rental count - {_dataStore.Rentals.Count}");
        int lateRentals = 0;
        foreach (Rental rental in _dataStore.Rentals)
        {
            if (rental.IsReturnLate()) lateRentals++;
        }
        
        Console.WriteLine($"Late rentals - {lateRentals}");
    }
    
    
}