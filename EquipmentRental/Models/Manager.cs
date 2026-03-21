using EquipmentRental.Enums;

namespace EquipmentRental.Models;

public class Manager : User
{
    public Manager(string name, string surname, UserType type) : base(name, surname, type)
    {
    }
}