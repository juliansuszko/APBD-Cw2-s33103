using EquipmentRental.Enums;

namespace EquipmentRental.Models;

public class Student : User
{
    public override int MaxRentals { get; }

    public Student(string name, string surname, UserType type) : base(name, surname, type)
    {
        MaxRentals = 2;
    }
}