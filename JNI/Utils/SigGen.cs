using JNI.Models;
using JNI.Models.Local;
using System.Data;

namespace JNI.Utils;
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

    public static string Arg(JType type) => Dim(type.Dim) + Hand(type);
    public static string Field(JType type) => Dim(type.Dim) + Hand(type);
    public static string Field(FieldData field) => Field(field.Type);
    public static string Method(MethodData method) => Method(method.Type, method.Args);
    public static string Method(JType retType, Arg[] args) =>
        $"({string.Concat(args.Select(a => a.Sig))})" +
        Field(retType);

    private static string Dim(int dim) => new string('[', dim);
    private static string Hand(JType type) => baseTypes.Contains(type.Name) ? type.Sig : $"L{type.Sig};";
}