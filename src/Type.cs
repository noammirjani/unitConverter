public abstract class UnitConversionBase
{
    protected readonly string PossibleUnit1;
    protected readonly string PossibleUnit2;
    protected string CurrentUnit { get; private set; } = string.Empty;
    protected string TargetUnit { get; private set; } = string.Empty;

    protected UnitConversionBase(string possibleUnit1, string possibleUnit2)
    {
        if (string.IsNullOrWhiteSpace(possibleUnit1) || string.IsNullOrWhiteSpace(possibleUnit2))
        {
            throw new ArgumentException("Possible units cannot be null or empty.");
        }
        PossibleUnit1 = possibleUnit1;
        PossibleUnit2 = possibleUnit2;
    }

    public abstract float preform_conversion(float amount);
    
    public void convert()
    {
        float amount = ReadAmount();
        float result = preform_conversion(amount);
        PrintResult(result);
    }

    public void PrintResult(float result)
    {
        Console.WriteLine($"The result is: {result}{TargetUnit} \n");
    }

    public void ReadUnitsFromInput()
    {
        Console.Write($"Enter the current unit: ({PossibleUnit1} or {PossibleUnit2}) ");
        CurrentUnit = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

        Console.Write($"Enter the current unit: ({PossibleUnit1} or {PossibleUnit2}) ");
        TargetUnit = Console.ReadLine()?.Trim().ToLower()  ?? string.Empty;

        ValidateUnits();
    }

    protected void ValidateUnits()
    {
        CurrentUnit = CurrentUnit.ToLower().Trim(); 
        TargetUnit = TargetUnit.ToLower().Trim();

        //can not be empty
        if (string.IsNullOrWhiteSpace(CurrentUnit) || string.IsNullOrWhiteSpace(TargetUnit))
        {
            throw new UnitInvalid();
        }

        // units can not be the same
        if (CurrentUnit.Equals(TargetUnit))
        {
            throw new UnitInvalid("Current and target units must be different.");
        }

        // units must be in the list of possible units
        if (!IsValidUnit(CurrentUnit) || !IsValidUnit(TargetUnit))
        {
            throw new UnitInvalid($"Invalid unit(s): {CurrentUnit} or {TargetUnit}. Valid units: {PossibleUnit1}, {PossibleUnit2}.");
        }
    }

    private bool IsValidUnit(string unit)
    {
        return unit.Equals(PossibleUnit1) || unit.Equals(PossibleUnit2);
    }

    protected float ReadAmount()
    {
        Console.Write("Enter the amount to convert: ");
        string amount = Console.ReadLine()?.Trim() ?? "0";
        if (!float.TryParse(amount, out float result))
        {
            throw new InvalidDataException("Amount must be a number.");
        }
        return result;
    }
}

class Length : UnitConversionBase
{
    public Length() : base("m", "ft") {} // meters and feet

    public override float preform_conversion(float amount)
    {   
        if (CurrentUnit.Equals("m") && TargetUnit.Equals("ft"))
        {
            return amount * 3.28084f;
        }
        else
        {
            return amount / 3.28084f;
        }
    }

}

class Temperature : UnitConversionBase
 {
    public Temperature() : base("c", "f") {}

    public override float preform_conversion(float amount)
    {        
        if (CurrentUnit.Equals("c") && TargetUnit.Equals("f"))
        {
            return amount * 9 / 5 + 32;
        }
        else
        {
            return (amount - 32) * 5 / 9;
        }
    }
}

class Weight : UnitConversionBase
{
    public Weight() : base("kg", "lb") {} // kilograms and pounds

    public override float preform_conversion(float amount)
    {
        if (CurrentUnit.Equals("kg") && TargetUnit.Equals("lb"))
        {
            return amount * 2.20462f;
        }
        else
        {
            return amount / 2.20462f;
        }
    }
}
