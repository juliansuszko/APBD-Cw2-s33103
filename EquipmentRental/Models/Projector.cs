namespace EquipmentRental.Models;

public class Projector : Equipment
{
    public string Resolution { get; private set; }
    public string[] VideoInputs { get; private set; }
    public string[] VideoOutputs { get; private set; }
    public string Matrix { get; private set; }

    public Projector(string name, string resolution, string[] videoInputs, string[] videoOutputs, string matrix) : base(name)
    {
        Resolution = resolution;
        VideoInputs = videoInputs;
        VideoOutputs = videoOutputs;
        Matrix = matrix;
    }
}