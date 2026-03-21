using EquipmentRental.Enums;

namespace EquipmentRental.Models;

public class Employee : User
{
    public Employee(string name, string surname, UserType type) : base(name, surname, type)
    {
    }
}