using System;
using EquipmentRental.Enums;
using EquipmentRental.Models;
using EquipmentRental.Services;

internal class Program
{
    public static void Main(string[] args)
    {
        var dataStore = new DataStore();
        var rentalService = new RentalService(dataStore);
        var display = new DisplayManager(dataStore, rentalService);
        
        Console.WriteLine("--- RENTAL APPLICATION ---");
        
        var laptop = new Laptop("Dell XPS 15", 16, "Intel i7-13700k", "RTX 3050", new[] { "SAMSUNG 512GB SSD" });
        var projector = new Projector("Epson X100", "1920x1080", new[] { "HDMI", "VGA" }, new[] { "Audio Out" }, "3LCD");
        var camera = new Camera("Sony A7 III", true, false, new[] { "SD 64GB", "CFexpress 128GB" });
        camera.Status = EquipmentStatus.Unavailable;
        
        dataStore.AddEquipment(laptop);
        dataStore.AddEquipment(projector);
        dataStore.AddEquipment(camera);
        
        var student = new Student("Jan", "Kowalski", UserType.Student);
        var employee = new Employee("Anna", "Nowak", UserType.Employee);
        var manager = new Manager("Maciej", "Kostka", UserType.Manager);
        dataStore.AddUser(student);
        dataStore.AddUser(employee);
        dataStore.AddUser(manager);
        Console.WriteLine("-----------");
        Console.WriteLine("EQUIPMENT TEST");
        display.DisplayAllEquipment();
        Console.WriteLine("-----------");
        display.DisplayAllAvailableEquipment();
        Console.WriteLine("-----------");

        var rental = rentalService.RentEquipment(student, laptop, 7);
        Console.WriteLine($"{student.Name} rented {laptop.Name}");
        Console.WriteLine("-----------");
        display.DisplayUserRentals(student);
        Console.WriteLine("-----------");
        
        DateTime lateReturnDate = rental.EndDate.AddDays(5);
        int penalty = rentalService.ReturnEquipment(rental, lateReturnDate);
        Console.WriteLine($"{student.Name} returned {rental.RentedEquipment.Name}");
        if (penalty > 0)
        {
            Console.WriteLine($"Penalty for late return: {penalty}");
        }
        rentalService.MarkEquipmentAsBroken(projector);
        display.DisplayLateRentals();
        
        display.DisplaySystemReport();
    }
}
