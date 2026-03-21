using EquipmentRental.Enums;

namespace EquipmentRental.Models;

public class Student : User
{
    public Student(string name, string surname, UserType type) : base(name, surname, type)
    {
    }
}