namespace EquipmentRental.Models;

public class Camera : Equipment
{
    public bool Stabilized { get; private set; }
    public bool BuiltInLamp { get; private set; }
    public string[] MemoryCards { get; private set; }

    public Camera(string name, bool stabilized, bool builtInLamp, string[] memoryCards) : base(name)
    {
        Stabilized = stabilized;
        BuiltInLamp = builtInLamp;
        MemoryCards = memoryCards;
    }

    public override string ToString()
    {
        return
            $"{nameof(Stabilized)}: {Stabilized}, {nameof(BuiltInLamp)}: {BuiltInLamp}, {nameof(MemoryCards)}: {string.Join(", ", MemoryCards)}";
    }
}