namespace EquipmentRental.Models;

public class Laptop : Equipment
{
    public int RamSizeGB { get; set; }
    public string Processor { get; set; }
    public string GraphicsCard { get; set; }
    public string[] Disks { get; set; }
    
    public Laptop(string name, int ramSizeGb, string processor, string graphicsCard, string[] disks) : base(name)
    {
        RamSizeGB = ramSizeGb;
        Processor = processor;
        GraphicsCard = graphicsCard;
        Disks = disks;
    }

    public override string ToString()
    {
        return
            $"{nameof(RamSizeGB)}: {RamSizeGB}, {nameof(Processor)}: {Processor}, {nameof(GraphicsCard)}: {GraphicsCard}, {nameof(Disks)}: {string.Join(", ", Disks)}";
    }
}