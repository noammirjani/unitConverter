
public class LengthConversion : UnitConversionBase
{
    public LengthConversion() : base(
        new Dictionary<string, Unit>
        {
            { "m", new Unit("meter", "m", x => x, x => x)},
            { "ft", new Unit("feet", "ft", x => x * 3.28084f, x => x / 3.28084f)},
            { "in", new Unit("inch", "in", x => x * 39.3701f, x => x / 39.3701f)},
            { "yd", new Unit("yard", "yd", x => x * 1.09361f, x => x / 1.09361f)},
            { "mi", new Unit("mile", "mi", x => x * 0.000621371f, x => x / 0.000621371f)},
            { "km", new Unit("kilometer", "km", x => x * 0.001f, x => x / 0.001f)},
            { "cm", new Unit("centimeter", "cm", x => x * 100f, x => x / 100f)},
            { "mm", new Unit("millimeter", "mm", x => x * 1000f, x => x / 1000f)},
            { "um", new Unit("micrometer", "um", x => x * 1000000f, x => x / 1000000f)},
            { "nm", new Unit("nanometer", "nm", x => x * 1000000000f, x => x / 1000000000f)},
        })
    { }
}


public class TemperatureConversion : UnitConversionBase
{
    public TemperatureConversion() : base(new Dictionary<string, Unit>
    {
        { "c", new Unit("Celsius", "C", x => x, x => x)},
        { "f", new Unit("Fahrenheit", "F", x => x * 9 / 5 + 32, x => (x - 32) * 5 / 9)},
        { "k", new Unit("Kelvin", "K", x => x + 273.15f, x => x - 273.15f)},
        { "r", new Unit("Rankine", "R", x => x * 9 / 5 + 491.67f, x => (x - 491.67f) * 5 / 9)},
        { "re", new Unit("Reaumur", "Re", x => x * 4 / 5, x => x * 5 / 4)},
    }) { }
}


public class WeightConversion : UnitConversionBase
{
    public WeightConversion() : base(new Dictionary<string, Unit>
    {
        { "g", new Unit("gram", "g", x => x, x => x)},
        { "mg", new Unit("milligram", "mg", x => x * 0.001f, x => x / 0.001f)},
        { "cg", new Unit("centigram", "cg", x => x * 0.01f, x => x / 0.01f)},
        { "dg", new Unit("decigram", "dg", x => x * 0.1f, x => x / 0.1f)},
        { "dag", new Unit("decagram", "dag", x => x * 10f, x => x / 10f)},
        { "hg", new Unit("hectogram", "hg", x => x * 100f, x => x / 100f)},
        { "kg", new Unit("kilogram", "kg", x => x * 1000f, x => x / 1000f)},
        { "Mt", new Unit("metric ton", "Mt", x => x * 1000000f, x => x / 1000000f)},
        { "lb", new Unit("pound", "lb", x => x * 453.59237f, x => x / 453.59237f)},
        { "oz", new Unit("ounce", "oz", x => x * 28.3495f, x => x / 28.3495f)},
        { "st", new Unit("stone", "st", x => x * 6350.29497f, x => x / 6350.29497f)},
        { "ct", new Unit("carat", "ct", x => x * 0.2f, x => x / 0.2f)},
        { "gr", new Unit("grain", "gr", x => x * 0.0648f, x => x / 0.0648f)},
        { "t", new Unit("ton", "t", x => x * 0.00110231f, x => x / 0.00110231f)},
    }) { }
}
