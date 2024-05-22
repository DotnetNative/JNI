namespace JNI;
public unsafe class JEnum : JType, IDisposable
{
    public JEnum(Handle handle, TypeInfo info) : base(handle, info)
    {
        var valuesField = GetStaticObjectField("$VALUES", new(Info.Signature, 1));
        using var jValuesArray = new JObjectArray(valuesField.Value);

        var jValues = jValuesArray.ToArray();
        Elements = new JEnumTuple[jValues.Length];
        for (var i = 0; i < jValues.Length; i++)
        {
            var notion = new EnumNotion(jValues[i]);
            var name = notion.Name;
            var ordinal = notion.Ordinal;
            Elements[i] = new(notion, name, ordinal);
        }

        Count = jValuesArray.Length;
    }

    public int Count;
    public JEnumTuple[] Elements;

    public JEnumTuple this[int ordinal]
    {
        get
        {
            var result = Elements.FirstOrDefault(v => v.Ordinal == ordinal);
            if (result is null)
                throw new MessageBoxException($"JEnum::this[int] result for {result} oridnal is null");
            return result;
        }
    }

    public JEnumTuple this[JObject e]
    {
        get
        {
            var result = Elements.FirstOrDefault(v => v == e);
            if (result is null)
                throw new MessageBoxException($"JEnum::this[JObject] result for {e} object is null");
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

public class JEnumTuple : Handle, IDisposable
{
    public JEnumTuple(EnumNotion value, string name, int ordinal)
    {
        Value = value;
        Name = name;
        Ordinal = ordinal;
    }

    public readonly EnumNotion Value;
    public readonly string Name;
    public readonly int Ordinal;

    public override nint LocalAddress => Value.LocalAddress;
    public override nint Address => Value.Address;
    public override bool IsDisposed => Value.IsDisposed;

    public void Dispose() => Value.Dispose();
    public override void DisposeHandle() => Value.DisposeHandle(); 
    ~JEnumTuple() => Dispose();

    public static implicit operator EnumNotion(JEnumTuple value) => value.Value;
}