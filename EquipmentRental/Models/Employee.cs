using EquipmentRental.Enums;

namespace EquipmentRental.Models;

public class Employee : User
{
    public override int MaxRentals { get; }

    public Employee(string name, string surname, UserType type) : base(name, surname, type)
    {
        MaxRentals = 5;
    }
}