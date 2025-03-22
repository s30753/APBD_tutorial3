namespace Tutorial3;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }
    public bool StoresHazardousCargo { get; set; }

    public override void EmptyCargo()
    {
        CargoWeight *= 0.05;
        CargoMass = TareWeight + CargoWeight;
    }
    
    public GasContainer(double height, double depth, double cargoMass, double tareWeight, double cargoWeight, double maxPayload, double pressure) : base(height, depth, cargoMass, tareWeight, cargoWeight, maxPayload)
    {
        StoresHazardousCargo = false;
        Pressure = pressure;
        SerialNumber = base.SerialNumber.Replace('A', 'G');
    }

    public GasContainer(double height, double depth, double tareWeight, double maxPayload, double pressure) : base(height, depth, tareWeight, maxPayload)
    {
        StoresHazardousCargo = false;
        Pressure = pressure;
        SerialNumber = base.SerialNumber.Replace('A', 'G');
    }
    
    public override void LoadContainer(Cargo cargo, double weight)
    {
        base.LoadContainer(cargo, weight);
        if (cargo.IsHazardous)
        {
            StoresHazardousCargo = true;
            notify();
        }
        CargoWeight += weight;
        CargoMass += weight;
    }

    public void notify()
    {
        // to be implemented
    }
}