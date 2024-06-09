namespace JNI;
public sealed class SigGen
{
    public static char[] PrimitiveTypes = ['Z', 'B', 'C', 'S', 'I', 'J', 'F', 'D', 'V'];

    public static string Arg(JType type) => Type(type);
    public static string Arg(TypeInfo info) => Type(info);
    public static string Method(TypeInfo retType, Arg[] args) =>
        $"({string.Concat(args.Select(a => a.Sig))})" +
        Type(retType);

    public static string Dim(int dim) => new string('[', dim);
    public static string Type(TypeInfo info) => info.Signature.Length == 1 && PrimitiveTypes.Contains(info.Signature[0]) ? $"{Dim(info.Dimension)}{info.Signature}" : $"{Dim(info.Dimension)}L{info.Signature};";
}