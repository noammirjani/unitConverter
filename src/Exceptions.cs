public class TypeConversionWasNotFound : Exception
{
    public TypeConversionWasNotFound(string message)
    : base("Type conversion was not found: " + message)
    {}
}

public class UnitInvalid : Exception
{

    public UnitInvalid()
    : base("Chosen unit conversion is empty")
    {}

    public UnitInvalid(string message)
    : base("Chosen unit conversion is invalid: \n " + message)
    {}

    public UnitInvalid(string current_unit, string target_unit)
    : base("Chosen unit conversion is invalid: " + current_unit + " to " + target_unit)
    {}
}