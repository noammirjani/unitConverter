public class TypeConversionWasNotFound : Exception
{
    public TypeConversionWasNotFound(string message)
    : base($"Invalid type of conversion: {message}")
    {}
}

public class ExitException : Exception
{
    public ExitException()
    : base("User has exited the program")
    {}
}

public class UnitInvalid : Exception
{

    public UnitInvalid()
    : base("Chosen unit conversion is empty.") 
    {}

    public UnitInvalid(string message)
    : base($"Chosen unit conversion is invalid: {message}")
    {}

    public UnitInvalid(string currentUnit, string targetUnit)
    : base($"Invalid unit conversion: {currentUnit} to {targetUnit}.")
    {}
}