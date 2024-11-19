
public class LengthConversion : UnitConversionBase
{
    public LengthConversion() : base("m", "ft") { }

    protected override string UnitErrorMessage => "For length, please choose between 'm' (meters) or 'ft' (feet)";

    public override float PerformConversion(float amount)
    {
        if (CurrentUnit.Equals("m", StringComparison.OrdinalIgnoreCase) && 
            TargetUnit.Equals("ft", StringComparison.OrdinalIgnoreCase))
        {
            return amount * 3.28084f;
        }
        else
        {
            return amount / 3.28084f;
        }
    }
}


public class TemperatureConversion : UnitConversionBase
{
    public TemperatureConversion() : base("c", "f") { }

    protected override string UnitErrorMessage => "For temperature, please choose between 'c' (Celsius) or 'f' (Fahrenheit)";

    public override float PerformConversion(float amount)
    {
        if (CurrentUnit.Equals("c", StringComparison.OrdinalIgnoreCase) && TargetUnit.Equals("f", StringComparison.OrdinalIgnoreCase))
        {
            return amount * 9 / 5 + 32;
        }
        else
        {
            return (amount - 32) * 5 / 9;
        }
    }
}


public class WeightConversion : UnitConversionBase
{
    public WeightConversion() : base("kg", "lb") { }

    protected override string UnitErrorMessage => "For weight, please choose between 'kg' (kilograms) or 'lb' (pounds)";

    public override float PerformConversion(float amount)
    {
        if (CurrentUnit.Equals("kg", StringComparison.OrdinalIgnoreCase) && TargetUnit.Equals("lb", StringComparison.OrdinalIgnoreCase))
        {
            return amount * 2.20462f;
        }
        else
        {
            return amount / 2.20462f;
        }
    }
}
