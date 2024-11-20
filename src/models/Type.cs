public struct Unit
{
    public Unit(string name, string shortName, Func<float, float> conversionFromBase, Func<float, float> conversionToBase)
    {
        Name = name;
        ShortName = shortName;
        ConversionFromBase = conversionFromBase;
        ConversionToBase = conversionToBase;
    }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public Func<float, float> ConversionFromBase { get; set; }
    public Func<float, float> ConversionToBase { get; set; }
}



public abstract class UnitConversionBase
{
    protected readonly Dictionary<string, Unit> Units;
    protected string CurrentUnit { get; private set; } = string.Empty;
    protected string TargetUnit { get; private set; } = string.Empty;
    protected readonly string ValidUnitsStr;

    protected UnitConversionBase(Dictionary<string, Unit> conversionRates)
    {
        Units = conversionRates ?? throw new ArgumentNullException(nameof(conversionRates));
        ValidUnitsStr = string.Join(", ", Units.Keys);
    }

    public void Run()
    {
        ReadUnitsFromInput();
        float amount = ReadAmount();
        float result = PerformConversion(amount);
        Console.WriteLine($"The result is: {result} {TargetUnit}");
    }
    
    public float PerformConversion(float amount)
    {
        if (!Units.ContainsKey(CurrentUnit) || !Units.ContainsKey(TargetUnit))
            throw new UnitInvalid("Invalid units provided.");
        
        return Units[TargetUnit].ConversionFromBase(Units[CurrentUnit].ConversionToBase(amount));
    }
   
   protected void ValidateUnits()
    {
        //can not be empty
        if (string.IsNullOrWhiteSpace(CurrentUnit) || string.IsNullOrWhiteSpace(TargetUnit))
            throw new UnitInvalid();
        
        // units can not be the same
        if (CurrentUnit.Equals(TargetUnit))
            throw new UnitInvalid("Current and target units must be different.");

        // units must be in the list of possible units
        if (!Units.ContainsKey(CurrentUnit) || !Units.ContainsKey(TargetUnit))
            throw new UnitInvalid($"Invalid unit(s): {CurrentUnit} and/or {TargetUnit}. The possible units are: {ValidUnitsStr}");

    }
   
    private float ReadAmount()
    {
        Console.Write("Enter the amount to convert: ");
        string amount = Read();

        if (!float.TryParse(amount, out float result))
        {
            throw new InvalidDataException("Amount must be a number.");
        }

        if (result <= 0)
        {
            throw new InvalidDataException("Amount must be a positive number.");
        }

        return result;
    }
   
    public void ReadUnitsFromInput()
    {
        Console.Write($"Enter the current unit ({ValidUnitsStr}):");
        CurrentUnit = Read();   

        Console.Write($"Enter the target unit ({ValidUnitsStr}):");
        TargetUnit = Read();

        ValidateUnits();
    }
    
    private string Read()
    {
        string input = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
        if (input.Equals("exit"))
        {
            throw new ExitException();
        }
        return input;
    }
}