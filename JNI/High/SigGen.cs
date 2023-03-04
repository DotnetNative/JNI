using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High;
public class SigGen
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

    public static string Arg(JType type) => baseTypes.Contains(type.Name) ? type.Sig : $"L{type.Sig};";
    public static string ArrayArg(JType type, int dim) => baseTypes.Contains(type.Name) ? type.Sig : $"L{type.Sig + new string('[', dim)};";
    public static string Field(FieldData field) => baseTypes.Contains(field.Type.Name) ? field.Type.Sig : $"L{field.Type.Sig};";
    public static string Field(JType type) => baseTypes.Contains(type.Name) ? type.Sig : $"L{type.Sig};";
    public static string Method(MethodData method) => $"({string.Concat(method.Args.Select(a => a.Sig))}){((baseTypes.Contains(method.Type.Name) ? method.Type.Sig : $"L{method.Type.Sig};"))}";
}