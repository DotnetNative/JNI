namespace JNI;
public class RuntimeTypeCollection
{
    public RuntimeTypeCollection(Env e)
    {
        BoolArray = new(Bool, 1);
        BoolArray2 = new(Bool, 2);
        ByteArray = new(Byte, 1);
        ByteArray2 = new(Byte, 2);
        CharArray = new(Char, 1);
        CharArray2 = new(Char, 2);
        ShortArray = new(Short, 1);
        ShortArray2 = new(Short, 2);
        IntArray = new(Int, 1);
        IntArray2 = new(Short, 2);
        LongArray = new(Long, 1);
        LongArray2 = new(Long, 2);
        FloatArray = new(Float, 1);
        FloatArray2 = new(Float, 2);
        DoubleArray = new(Double, 1);
        DoubleArray2 = new(Double, 2);
        ObjectArray = new(Object, 1);
        ObjectArray2 = new(Object, 2);
        StringArray = new(String, 1);
        StringArray2 = new(String, 2);
        ClassArray = new(Class, 1);
        ClassArray2 = new(Class, 2);


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
        Void = new("V"),
        Bool = new("Z"), BoolArray, BoolArray2,
        Byte = new("B"), ByteArray, ByteArray2,
        Char = new("C"), CharArray, CharArray2,
        Short = new("S"), ShortArray, ShortArray2,
        Int = new("I"), IntArray, IntArray2,
        Long = new("J"), LongArray, LongArray2,
        Float = new("F"), FloatArray, FloatArray2,
        Double = new("D"), DoubleArray, DoubleArray2,
        Object = new("java.lang.Object"), ObjectArray, ObjectArray2,
        String = new("java.lang.String"), StringArray, StringArray2,
        Class = new("java.lang.Class"), ClassArray, ClassArray2;

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