using System.Xml.Linq;

namespace JNI;
public unsafe class JEnum<T> : JType, IDisposable where T : struct, Enum
{
    public JEnum(Handle handle, TypeInfo info) : base(handle, info)
    {
        var valuesField = GetStaticObjectField("$VALUES", new(Info.Signature, 1));
        using var jValuesArray = new JObjectArray(valuesField.Value);

        var values = Enum.GetValues<T>();
        var names = Enum.GetNames<T>();
        var jValues = jValuesArray.ToArray();
        if (values.Length != names.Length || names.Length != jValues.Length)
            throw new MessageBoxException($"Arguments have different sizes between each other or between java enum $VALUES");

        Elements = new JEnumTuple<T>[jValues.Length];

        Count = jValuesArray.Length;
    }

    public int Count;
    public JEnumTuple<T>[] Elements;

    public JEnumTuple<T> this[int ordinal]
    {
        get
        {
            var result = Elements.FirstOrDefault(v => v.Ordinal == ordinal);
            if (result is null)
                throw new MessageBoxException($"JEnum<T>::this[int] result for {result} oridnal is null");
            return result;
        }
    }
    public JEnumTuple<T> this[JObject e]
    {
        get
        {
            var result = Elements.FirstOrDefault(v => v == e);
            if (result is null)
                throw new MessageBoxException($"JEnum<T>::this[JObject] result for {e} object is null");
            return result;
        }
    }
    public JEnumTuple<T> this[T value]
    {
        get
        {
            var result = Elements.FirstOrDefault(e => e.Value.Equals(value));
            if (result is null)
                throw new MessageBoxException($"JEnum<T>::this[T] result for {value} value is null");
            return result;
        }
    }

    public new void Dispose()
    {
        foreach (var value in Elements)
            value.Dispose();

        base.Dispose();
    }
}

public class JEnumTuple<T> : Handle, IDisposable where T : struct, Enum
{
    public JEnumTuple(T value, EnumNotion jValue, int ordinal)
    {
        Value = value;
        JValue = jValue;
        Ordinal = ordinal;
    }

    public readonly T Value;
    public readonly EnumNotion JValue;
    public readonly int Ordinal;

    public override nint LocalAddress => JValue.LocalAddress;
    public override nint Address => JValue.Address;
    public override bool IsDisposed => JValue.IsDisposed;

    public void Dispose() => JValue.Dispose();
    public override void DisposeHandle() => JValue.DisposeHandle(); 
    ~JEnumTuple() => Dispose();

    public static implicit operator EnumNotion(JEnumTuple<T> value) => value.JValue;
    public static implicit operator T(JEnumTuple<T> value) => value.Value;
}