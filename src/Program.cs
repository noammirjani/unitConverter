
class Program
{
    static void Main(string[] args)
    {
        while(true){
            try{
                Console.WriteLine("\nEnter the type of conversion you would like to perform or type 'exit' to quit.\nOptions: length, temperature, weight.");
                string typeConversion = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;
                
                if(typeConversion == "exit"){
                    throw new ExitException();
                }

                TypeFactory.Instance.createType(typeConversion).Run();
            }
            catch (ExitException){
                break;
            }
            catch (TypeConversionWasNotFound e ){
                Console.WriteLine(e.Message);
            }
            catch (UnitInvalid e){
                Console.WriteLine(e.Message);
            }
            catch (InvalidDataException e){
                Console.WriteLine($"Invalid input: {e.Message}");
            }
        }
    }
}