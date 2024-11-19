

class Program
{
    static void Main(string[] args)
    {
        while(true){
            try{
                string type_conversion = Console.ReadLine() ?? "";
                
                if(type_conversion.Equals("exit")){
                    break;
                }

                UnitConversionBase converter = TypeFactory.Instance.createType(type_conversion);
                converter.ReadUnitsFromInput();
                converter.preform_conversion();
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
            }
        }
    }
}