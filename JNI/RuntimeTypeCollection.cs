using System.Collections;

namespace JNI;
public class RuntimeTypeCollection
{
    public RuntimeTypeCollection(Env env)
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
        Bool = new("java.lang.Boolean", "Z"), BoolArray,
        Byte = new("java.lang.Byte", "B"), ByteArray,
        Char = new("java.lang.Character", "C"), CharArray,
        Short = new("java.lang.Short", "S"), ShortArray,
        Int = new("java.lang.Integer", "I"), IntArray,
        Long = new("java.lang.Long", "J"), LongArray,
        Float = new("java.lang.Float", "F"), FloatArray,
        Double = new("java.lang.Double", "D"), DoubleArray,
        Object = new("java.lang.Object"), ObjectArray,
        String = new("java.lang.String"), StringArray;

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