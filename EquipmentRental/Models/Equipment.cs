namespace EquipmentRental.Models;

public abstract class Equipment
{
    protected Equipment(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}