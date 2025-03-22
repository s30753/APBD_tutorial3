namespace Tutorial3;

public class RefrigeratedContainer : Container
{
    public Product ProductType { get; set; }
    public double Temperature { get; set; }
    
    public RefrigeratedContainer(double height, double depth, double cargoMass, double tareWeight, double cargoWeight, double maxPayload, Product productType, double temperature) : base(height, depth, cargoMass, tareWeight, cargoWeight, maxPayload)
    {
        SerialNumber = base.SerialNumber.Replace('A', 'C');
        ProductType = productType;
        Temperature = temperature >= productType.MinTemperature ? temperature : productType.MinTemperature;
    }

    public RefrigeratedContainer(double height, double depth, double tareWeight, double maxPayload, Product productType, double temperature) : base(height, depth, tareWeight, maxPayload)
    {
        SerialNumber = base.SerialNumber.Replace('A', 'C');
        ProductType = productType;
        Temperature = temperature >= productType.MinTemperature ? temperature : productType.MinTemperature;
    }
    

    public override void EmptyCargo()
    {
        CargoWeight = 0;
        CargoMass = TareWeight;
    }

    public void LoadContainer(Product product, double weight)
    {
        if (ProductType.Name == product.Name)
        {
            CargoWeight += weight;
            CargoMass += weight;
        }
    }
}