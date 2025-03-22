namespace Tutorial3;

public class Product
{
    public string Name { get; set; }
    public double MinTemperature { get; set; }

    public Product(string name, double minTemperature)
    {
        Name = name;
        MinTemperature = minTemperature;
    }
}