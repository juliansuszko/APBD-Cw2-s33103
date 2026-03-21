using EquipmentRental.Enums;

namespace EquipmentRental.Models;

public abstract class User
{
    public static int IdCounter = 1;
    
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public UserType Type { get; set; }

    protected User(string name, string surname, UserType type)
    {
        Id = IdCounter++;
        Name = name;
        Surname = surname;
        Type = type;
    }
}