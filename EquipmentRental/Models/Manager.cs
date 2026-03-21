using EquipmentRental.Enums;

namespace EquipmentRental.Models;

public class Manager : User
{
    public override int MaxRentals { get; }

    public Manager(string name, string surname, UserType type) : base(name, surname, type)
    {
        MaxRentals = 999;
    }
}