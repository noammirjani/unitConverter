

class Program
{
    static void Main(string[] args)
    {
        while(true){
            try{
                Console.WriteLine("\nEnter the type of conversion you would like to preform or type 'exit' to quit. \n Options: length, temperature, weight");
                string type_conversion = Console.ReadLine() ?? "";
                
                if(type_conversion.Equals("exit")){
                    break;
                }

                UnitConversionBase converter = TypeFactory.Instance.createType(type_conversion);

                converter.ReadUnitsFromInput();
                converter.convert();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
            }
        }
    }
}