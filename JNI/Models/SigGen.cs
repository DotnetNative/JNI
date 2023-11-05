namespace JNI;
public sealed class SigGen
{
    private static string[] baseTypes = new string[]
    {
        "java/lang/Boolean",
        "java/lang/Byte",
        "java/lang/Short",
        "java/lang/Integer",
        "java/lang/Long",
        "java/lang/Float",
        "java/lang/Double",
        "java/lang/Void",
    };

    public static string Arg(JType type) => Field(type);
    public static string Arg(TypeInfo info) => Field(info);
    public static string Field(JType type) => Field(type);
    public static string Field(TypeInfo info) => baseTypes.Contains(info.Name) ? $"{Dim(info.Dim)}{info.Sig}" : $"{Dim(info.Dim)}L{info.Sig};";
    public static string Field(FieldData field) => field.Signature;
    public static string Method(JType retType, Arg[] args) => Method((TypeInfo)retType, args);
    public static string Method(TypeInfo retType, Arg[] args) =>
        $"({string.Concat(args.Select(a => a.Sig))})" +
        Field(retType);

    public static string Dim(int dim) => new string('[', dim);
    public static string Type(JType type) => Type((TypeInfo)type);
    public static string Type(TypeInfo info) => baseTypes.Contains(info.Name) ? info.Sig : $"L{info.Sig};";
}