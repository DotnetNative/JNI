namespace JNI;
public class RuntimeTypeCollection
{
    public RuntimeTypeCollection(Env e)
    {
        BoolArray = new(Bool, 1);
        ByteArray = new(Byte, 1);
        CharArray = new(Char, 1);
        ShortArray = new(Short, 1);
        IntArray = new(Int, 1);
        LongArray = new(Long, 1);
        FloatArray = new(Float, 1);
        DoubleArray = new(Double, 1);

        ObjectArray = new(Object, 1);
        StringArray = new(String, 1);
        ClassArray = new(Class, 1);

        VoidType = e.GetType(Void);
        BoolType = e.GetType(Bool);
        ByteType = e.GetType(Byte);
        CharType = e.GetType(Char);
        ShortType = e.GetType(Short);
        IntType = e.GetType(Int);
        LongType = e.GetType(Long);
        FloatType = e.GetType(Float);
        DoubleType = e.GetType(Double);

        ObjectType = e.GetType(Object);
        StringType = e.GetType(String);
        ClassType = e.GetType(Class);
    }

    public readonly TypeInfo
        Void = new("java.lang.Void", "V"),
        Bool = new("java.lang.Boolean", "Z"), BoolArray,
        Byte = new("java.lang.Byte", "B"), ByteArray,
        Char = new("java.lang.Character", "C"), CharArray,
        Short = new("java.lang.Short", "S"), ShortArray,
        Int = new("java.lang.Integer", "I"), IntArray,
        Long = new("java.lang.Long", "J"), LongArray,
        Float = new("java.lang.Float", "F"), FloatArray,
        Double = new("java.lang.Double", "D"), DoubleArray,
        Object = new("java.lang.Object"), ObjectArray,
        String = new("java.lang.String"), StringArray,
        Class = new("java.lang.Class"), ClassArray;

    public readonly JType
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
        ObjectType,
        ClassType;
}