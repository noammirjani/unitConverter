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

    public abstract float PerformConversion(float amount);
    
    public void ConvertAndPrintResult()
    {
        float amount = ReadAmount();
        float result = PerformConversion(amount);
        DisplayResult(result);
    }

    public void DisplayResult(float result) => Console.WriteLine($"The result is: {result}{TargetUnit} \n");

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
            throw new UnitInvalid($"Invalid unit(s): {UnitErrorMessage}");
        }

    }
    
    protected abstract string UnitErrorMessage { get; }

    private bool IsValidUnit(string unit)
    {
        return unit.Equals(PossibleUnit1, StringComparison.OrdinalIgnoreCase) || 
            unit.Equals(PossibleUnit2, StringComparison.OrdinalIgnoreCase);
    }

    protected float ReadAmount()
    {
        Console.Write("Enter the amount to convert: ");
        string amount = Read();
        if (!float.TryParse(amount, out float result))
        {
            throw new InvalidDataException("Amount must be a number.");
        }
        return result;
    }
   
    public void ReadUnitsFromInput()
    {
        Console.Write($"Enter the current unit: ({PossibleUnit1} or {PossibleUnit2}) ");
        CurrentUnit = Read();   

        Console.Write($"Enter the target unit: ({PossibleUnit1} or {PossibleUnit2}) ");
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