namespace JNI;
public class RuntimeTypeCollection
{
    public RuntimeTypeCollection(Env env)
    {
        VoidType = env.GetGType(Void);
        BoolType = env.GetGType(Bool);
        ByteType = env.GetGType(Byte);
        CharType = env.GetGType(Char);
        ShortType = env.GetGType(Short);
        IntType = env.GetGType(Int);
        LongType = env.GetGType(Long);
        FloatType = env.GetGType(Float);
        DoubleType = env.GetGType(Double);

        ObjectType = env.GetGType(Object);
        StringType = env.GetGType(String);
    }

    public readonly TypeInfo
        Void = new("java.lang.Void", "V"),
        Bool = new("java.lang.Boolean", "Z"),
        Byte = new("java.lang.Byte", "B"),
        Char = new("java.lang.Character", "C"),
        Short = new("java.lang.Short", "S"),
        Int = new("java.lang.Integer", "I"),
        Long = new("java.lang.Long", "J"),
        Float = new("java.lang.Float", "F"),
        Double = new("java.lang.Double", "D"),
        Object = new("java.lang.Object"),
        String = new("java.lang.String");

    public readonly GJType
        VoidType,
        BoolType,
        ByteType,
        CharType,
        ShortType,
        IntType,
        LongType,
        FloatType,
        DoubleType,
        StringType,
        ObjectType;
}