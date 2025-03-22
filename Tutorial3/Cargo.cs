namespace Tutorial3;

public class Cargo
{
    public string Name { get; set; }
    public bool IsHazardous { get; set; }

    public Cargo(string name, bool isHazardous)
    {
        Name = name;
        IsHazardous = isHazardous;
    }
}