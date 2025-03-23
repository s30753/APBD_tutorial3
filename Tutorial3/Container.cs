namespace Tutorial3;

public abstract class Container
{
    private static int _counter = 1;
    public string SerialNumber { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double CargoMass { get; set; }
    public double TareWeight { get; set; }
    public double CargoWeight { get; set; }
    public double MaxPayload { get; set; }

    protected Container(double height, double depth, double cargoMass, double tareWeight, double cargoWeight, double maxPayload)
    {
        SerialNumber = "KON-A-" + _counter.ToString();
        Height = height;
        Depth = depth;
        CargoMass = cargoMass;
        TareWeight = tareWeight;
        CargoWeight = cargoWeight;
        MaxPayload = maxPayload;
        _counter++;
    }

    protected Container(double height, double depth, double tareWeight, double maxPayload)
    {
        SerialNumber = "KON-A-" + _counter.ToString();
        Height = height;
        Depth = depth;
        CargoMass = tareWeight;
        TareWeight = tareWeight;
        CargoWeight = 0;
        MaxPayload = maxPayload;
        _counter++;
    }

    public abstract void EmptyCargo();

    public virtual void LoadContainer(Cargo cargo, double weight)
    {
        if (CargoWeight + weight > MaxPayload) throw new OverfillException();
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($@"Container {SerialNumber}
Height: {Height}cm
Depth: {Depth}cm
CargoMass: {CargoMass}kg
TareWeight: {TareWeight}kg
CargoWeight: {CargoWeight}kg
MaxPayload: {MaxPayload}kg");
        
    }
}

class OverfillException : Exception
{
    public OverfillException(): base("This operation would result in overfilling") { }
   public OverfillException(string message) : base(message) { }
}