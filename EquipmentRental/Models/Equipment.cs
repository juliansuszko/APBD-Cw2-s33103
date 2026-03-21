using EquipmentRental.Enums;

namespace EquipmentRental.Models;

public abstract class Equipment
{
    protected Equipment(string name)
    {
        Name = name;
        Status = EquipmentStatus.Available;
        ID = idCounter++;
    }

    private static int idCounter = 1;

    public int ID { get; private set; }
    public string Name { get; private set; }
    public EquipmentStatus Status { get; set; }
}