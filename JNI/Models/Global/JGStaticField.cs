using JNI.Models.Local;

namespace JNI.Models.Global;
public unsafe class JGStaticField : IDisposable
{
    public JGStaticField(Env env, ClassHandle clazz, string name, JType type)
    {
        Class = clazz;
        Name = name;
        Type = type;
        field = env.GetStaticFieldID(clazz, name, type);
        objField = env.ToReflectedField(clazz, field, true);
        objField.PutGlobal();
    }

    public ClassHandle Class { get; private set; }
    public string Name { get; private set; }
    public JType Type { get; private set; }

    private JObject objField;
    public JStaticField field;

    public JGObject GetValue(Env env) => new JGObject(env, env.Master->GetStaticObjectField((IntPtr)Class, env.FromReflectedField(objField).Addr));
    public bool GetBool(Env env) => env.Master->GetStaticBooleanField((IntPtr)Class, env.FromReflectedField(objField).Addr);
    public byte GetByte(Env env) => env.Master->GetStaticByteField((IntPtr)Class, env.FromReflectedField(objField).Addr);
    public short GetShort(Env env) => env.Master->GetStaticShortField((IntPtr)Class, env.FromReflectedField(objField).Addr);
    public int GetInt(Env env) => env.Master->GetStaticIntField((IntPtr)Class, env.FromReflectedField(objField).Addr);
    public long GetLong(Env env) => env.Master->GetStaticLongField((IntPtr)Class, env.FromReflectedField(objField).Addr);
    public float GetFloat(Env env) => env.Master->GetStaticFloatField((IntPtr)Class, env.FromReflectedField(objField).Addr);
    public double GetDouble(Env env) => env.Master->GetStaticDoubleField((IntPtr)Class, env.FromReflectedField(objField).Addr);
    public void SetValue(Env env, JObject value) => env.Master->SetStaticObjectField((IntPtr)Class, env.FromReflectedField(objField).Addr, (IntPtr)value);
    public void SetBool(Env env, bool value) => env.Master->SetStaticBooleanField((IntPtr)Class, env.FromReflectedField(objField).Addr, value);
    public void SetByte(Env env, byte value) => env.Master->SetStaticByteField((IntPtr)Class, env.FromReflectedField(objField).Addr, value);
    public void SetShort(Env env, short value) => env.Master->SetStaticShortField((IntPtr)Class, env.FromReflectedField(objField).Addr, value);
    public void SetInt(Env env, int value) => env.Master->SetStaticIntField((IntPtr)Class, env.FromReflectedField(objField).Addr, value);
    public void SetLong(Env env, long value) => env.Master->SetStaticLongField((IntPtr)Class, env.FromReflectedField(objField).Addr, value);
    public void SetFloat(Env env, float value) => env.Master->SetStaticFloatField((IntPtr)Class, env.FromReflectedField(objField).Addr, value);
    public void SetDouble(Env env, double value) => env.Master->SetStaticDoubleField((IntPtr)Class, env.FromReflectedField(objField).Addr, value);

    public void Dispose()
    {
        field.Dispose();
        objField.Dispose();
    }

    public static explicit operator JStaticField(JGStaticField field) => field.field;
}