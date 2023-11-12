using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI;
public unsafe abstract class JEnum<T> : JType, IDisposable where T : struct, Enum
{
    public JEnum(EnvHandle handle, TypeInfo info) : base(handle, info)
    {
        InitEnum();
        InitJavaEnum(EnumNames);
    }

    public JEnum(EnvHandle handle, List<string> names, TypeInfo info) : base(handle, info) 
    {
        InitEnum();
        InitJavaEnum(names);
    }

    void InitEnum()
    {
        EnumValues = Enum.GetValues<T>().ToList();
        EnumNames = Enum.GetNames<T>().ToList();
    }

    void InitJavaEnum(List<string> names)
    {
        Count = names.Count;

        Names = names;
        Values = new List<GJObject>();
        foreach (var name in names)
        {
            using var field = this.GetStaticObjectField(name, this);
            var value = field.GValue;
            Values.Add(value);
        }
    }

    public int Count;

    public List<T> EnumValues;
    public List<string> EnumNames;

    public List<GJObject> Values;
    public List<string> Names;

    public new void Dispose()
    {
        foreach (var value in Values)
            value.Dispose();

        base.Dispose();
    }
}

public class LJEnum<T> : JEnum<T> where T : struct, Enum
{
    public LJEnum(LHandle handle, TypeInfo info) : base(handle, info) { }
    public LJEnum(LHandle handle, List<string> names, TypeInfo info) : base(handle, names, info) { }
}

public class GJEnum<T> : JEnum<T> where T : struct, Enum
{
    public GJEnum(GHandle handle, TypeInfo info) : base(handle, info) { }
    public GJEnum(GHandle handle, List<string> names, TypeInfo info) : base(handle, names, info) { }
}