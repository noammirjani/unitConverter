
class TypeFactory{
    private static TypeFactory? _instance = null;
    private Dictionary<string, Func<UnitConversionBase>> _types = new Dictionary<string, Func<UnitConversionBase>>();

    private TypeFactory(){
        _types.Add("length", () => new Length());
        _types.Add("temperature", () => new Temperature());
        _types.Add("weight", () => new Weight());
    }

    public static TypeFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TypeFactory();
            }
            return _instance;
        }
    }

    public UnitConversionBase createType(string type){
    
        type = type.Trim().ToLower();

        if(!_types.ContainsKey(type)){
            throw new TypeConversionWasNotFound(type);
        }
        return _types[type]();
    }
}