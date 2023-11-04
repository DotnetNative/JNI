using JNI.Models;
using JNI.Models.Models.Type;

namespace JNI;
public class RuntimeTypeCollection
{
    public RuntimeTypeCollection(Env env)
    {
        Void = new TypeInfo("java/lang/Void", "V");
        Bool = new TypeInfo("java/lang/Boolean", "Z");
        Byte = new TypeInfo("java/lang/Byte", "B");
        Char = new TypeInfo("java/lang/Character", "C");
        Short = new TypeInfo("java/lang/Short", "S");
        Int = new TypeInfo("java/lang/Integer", "I");
        Long = new TypeInfo("java/lang/Long", "J");
        Float = new TypeInfo("java/lang/Float", "F");
        Double = new TypeInfo("java/lang/Double", "D");

        Object = new TypeInfo("java/lang/Object");
        String = new TypeInfo("java/lang/String");


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

    public TypeInfo Void;
    public TypeInfo Bool;
    public TypeInfo Byte;
    public TypeInfo Char;
    public TypeInfo Short;
    public TypeInfo Int;
    public TypeInfo Long;
    public TypeInfo Float;
    public TypeInfo Double;

    public TypeInfo String;
    public TypeInfo Object;


    public GJType VoidType;
    public GJType BoolType;
    public GJType ByteType;
    public GJType CharType;
    public GJType ShortType;
    public GJType IntType;
    public GJType LongType;
    public GJType FloatType;
    public GJType DoubleType;

    public GJType StringType;
    public GJType ObjectType;
}