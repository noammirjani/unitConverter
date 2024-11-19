
class TypeFactory{
    private Dictionary<string, Func<UnitConversionBase>> _types = new Dictionary<string, Func<UnitConversionBase>>();

    // Singleton - thread safe
    private static readonly Lazy<TypeFactory> _instance = new Lazy<TypeFactory>(() => new TypeFactory());
    public static TypeFactory Instance => _instance.Value;

    private TypeFactory(){
        _types.Add("length", () => new Length());
        _types.Add("temperature", () => new Temperature());
        _types.Add("weight", () => new Weight());
    }

    public UnitConversionBase createType(string type){
    
        type = type.Trim().ToLower();

        if(!_types.ContainsKey(type)){
            throw new TypeConversionWasNotFound(type);
        }
        return _types[type]();
    }
}