
using System.Data.Common;

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

    public void convert(string type1, string type2)
    {
        CurrentUnit = type1;
        TargetUnit = type2;
        ValidateUnits();
        preform_conversion();
    }
    public abstract void preform_conversion();
    
    public void ReadUnitsFromInput()
    {
        Console.Write("Enter the current unit: ");
        CurrentUnit = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

        Console.Write("Enter the target unit: ");
        TargetUnit = Console.ReadLine()?.Trim().ToLower()  ?? string.Empty;

        ValidateUnits();
    }

    protected void ValidateUnits()
    {
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
}

class Length : UnitConversionBase
{
    public Length() : base("m", "cm") {}

    public override void preform_conversion()
    {
        Console.WriteLine("Performing length conversion...");
        
        if (CurrentUnit.Equals("m") && TargetUnit.Equals("cm"))
        {
            Console.WriteLine("m to cm");
        }
        else
        {
            Console.WriteLine("cm to m");
        }
    }
}

class Temperature : UnitConversionBase
 {
    public Temperature() : base("c", "f") {}

    public override void preform_conversion()
    {
        Console.WriteLine("Performing temperature conversion...");
        
        if (CurrentUnit.Equals("c") && TargetUnit.Equals("f"))
        {
            Console.WriteLine("c to f");
        }
        else
        {
            Console.WriteLine("f to c");
        }
    }
}

class Weight : UnitConversionBase
{
    public Weight() : base("kg", "g") {}

    public override void preform_conversion()
    {
        Console.WriteLine("Performing weight conversion...");
        
        if (CurrentUnit.Equals("kg") && TargetUnit.Equals("g"))
        {
            Console.WriteLine("kg to g");
        }
        else
        {
            Console.WriteLine("g to kg");
        }
    }
}
