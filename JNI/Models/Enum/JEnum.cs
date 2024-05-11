namespace JNI;
public unsafe class JEnum<T> : JType, IDisposable where T : struct, Enum
{
    public JEnum(EnvHandle handle, TypeInfo info) : base(handle, info)
    {
        EnumValues = Enum.GetValues<T>().ToList();
        EnumNames = Enum.GetNames<T>().ToList();

        using var valuesField = GetStaticObjectField("$VALUES", new(Info.Signature, 1));
        using var values = new LJObjectArray(valuesField.Value.Handle);

        Count = values.Length;

        Values = new();
        for (int i = 0; i < Count; i++)
            Values.Add(new java.lang.Enum<T>(values.GetG(i), EnumValues[i]));
    }

    public int Count;

    public List<T> EnumValues;
    public List<string> EnumNames;
    public List<java.lang.Enum<T>> Values;

    public T this[java.lang.Enum<T> e] => e.Value;
    public java.lang.Enum<T> this[JObject e] => Values[Values.FindIndex(v => v == e)];
    public java.lang.Enum<T> this[T value] => Values[EnumValues.IndexOf(value)];

    public new void Dispose()
    {
        foreach (var value in Values)
            value.Dispose();

        base.Dispose();
    }
}

public class GJEnum<T>(GHandle handle, TypeInfo info) : JEnum<T>(handle, info) where T : struct, Enum;