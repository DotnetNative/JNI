using JNI.Models;
using JNI.Models.Global;

namespace JNI;
public class RuntimeTypeCollection
{
    public RuntimeTypeCollection(Env env)
    {
        Void = new TypeInfo("java/lang/Void", "V");
        Bool = new TypeInfo("java/lang/Boolean", "Z");
        Byte = new TypeInfo("java/lang/Byte", "B");
        Short = new TypeInfo("java/lang/Short", "S");
        Int = new TypeInfo("java/lang/Integer", "I");
        Long = new TypeInfo("java/lang/Long", "J");
        Float = new TypeInfo("java/lang/Float", "F");
        Double = new TypeInfo("java/lang/Double", "D");

        Object = new TypeInfo("java/lang/Object");
        String = new TypeInfo("java/lang/String");

        VoidType = env.GetGlobalType(Void);
        BoolType = env.GetGlobalType(Bool);
        ByteType = env.GetGlobalType(Byte);
        ShortType = env.GetGlobalType(Short);
        IntType = env.GetGlobalType(Int);
        LongType = env.GetGlobalType(Long);
        FloatType = env.GetGlobalType(Float);
        DoubleType = env.GetGlobalType(Double);

        ObjectType = env.GetGlobalType(Object);
        StringType = env.GetGlobalType(String);
    }

    public TypeInfo Void;
    public TypeInfo Bool;
    public TypeInfo Byte;
    public TypeInfo Short;
    public TypeInfo Int;
    public TypeInfo Long;
    public TypeInfo Float;
    public TypeInfo Double;

    public TypeInfo String;
    public TypeInfo Object;


    public JGType VoidType;
    public JGType BoolType;
    public JGType ByteType;
    public JGType ShortType;
    public JGType IntType;
    public JGType LongType;
    public JGType FloatType;
    public JGType DoubleType;

    public JGType StringType;
    public JGType ObjectType;
}