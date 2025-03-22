namespace Tutorial3;

public abstract class Container
{
    private static int counter = 0;
    public string SerialNumber { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double CargoMass { get; set; }
    public double TareWeight { get; set; }
    public double CargoWeight { get; set; }
    public double MaxPayload { get; set; }

    protected Container(double height, double depth, double cargoMass, double tareWeight, double cargoWeight, double maxPayload)
    {
        SerialNumber = "KON-A-" + counter.ToString();
        Height = height;
        Depth = depth;
        CargoMass = cargoMass;
        TareWeight = tareWeight;
        CargoWeight = cargoWeight;
        MaxPayload = maxPayload;
        counter++;
    }

    protected Container(double height, double depth, double tareWeight, double maxPayload)
    {
        SerialNumber = "KON-A-" + counter.ToString();
        Height = height;
        Depth = depth;
        CargoMass = tareWeight;
        TareWeight = tareWeight;
        CargoWeight = 0;
        MaxPayload = maxPayload;
        counter++;
    }

    public abstract void EmptyCargo();

    public virtual void LoadContainer(Cargo cargo, double weight)
    {
        if (weight > MaxPayload) throw new Exception();
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($@"Container: {SerialNumber}
Height: {Height}cm
Depth: {Depth}cm
CargoMass: {CargoMass}kg
TareWeight: {TareWeight}kg
CargoWeight: {CargoWeight}kg
MaxPayload: {MaxPayload}kg");
        
    }
}