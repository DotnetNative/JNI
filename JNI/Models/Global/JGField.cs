using JNI.Models.Local;

namespace JNI.Models.Global;
public unsafe class JGField : IDisposable
{
    public JGField(Env env, ClassHandle clazz, string name, JType type)
    {
        Class = clazz;
        Name = name;
        Type = type;
        field = env.GetFieldID(clazz, name, type);
        objField = env.ToReflectedField(clazz, field, false);
        objField.PutGlobal();
    }

    public JGField(Env env, ClassHandle clazz, JField field, string name, JType type)
    {
        Class = clazz;
        Name = name;
        Type = type;
        this.field = field;
        objField = env.ToReflectedField(clazz, field, false);
        objField.PutGlobal();
    }

    public ClassHandle Class { get; private set; }
    public string Name { get; private set; }
    public JType Type { get; private set; }

    private JObject objField;
    public JField field;

    public JGObject GetValue(Env env, JObject obj) => new JGObject(env, env.Master->GetObjectField((IntPtr)obj, env.FromReflectedField(objField).Addr));
    public bool GetBool(Env env, JObject obj) => env.Master->GetBooleanField((IntPtr)obj, env.FromReflectedField(objField).Addr);
    public byte GetByte(Env env, JObject obj) => env.Master->GetByteField((IntPtr)obj, env.FromReflectedField(objField).Addr);
    public short GetShort(Env env, JObject obj) => env.Master->GetShortField((IntPtr)obj, env.FromReflectedField(objField).Addr);
    public int GetInt(Env env, JObject obj) => env.Master->GetIntField((IntPtr)obj, env.FromReflectedField(objField).Addr);
    public long GetLong(Env env, JObject obj) => env.Master->GetLongField((IntPtr)obj, env.FromReflectedField(objField).Addr);
    public float GetFloat(Env env, JObject obj) => env.Master->GetFloatField((IntPtr)obj, env.FromReflectedField(objField).Addr);
    public double GetDouble(Env env, JObject obj) => env.Master->GetDoubleField((IntPtr)obj, env.FromReflectedField(objField).Addr);
    public void SetValue(Env env, JObject obj, JObject value) => env.Master->SetObjectField((IntPtr)obj, env.FromReflectedField(objField).Addr, (IntPtr)value);
    public void SetBool(Env env, JObject obj, bool value) => env.Master->SetBooleanField((IntPtr)obj, env.FromReflectedField(objField).Addr, value);
    public void SetByte(Env env, JObject obj, byte value) => env.Master->SetByteField((IntPtr)obj, env.FromReflectedField(objField).Addr, value);
    public void SetShort(Env env, JObject obj, short value) => env.Master->SetShortField((IntPtr)obj, env.FromReflectedField(objField).Addr, value);
    public void SetInt(Env env, JObject obj, int value) => env.Master->SetIntField((IntPtr)obj, env.FromReflectedField(objField).Addr, value);
    public void SetLong(Env env, JObject obj, long value) => env.Master->SetLongField((IntPtr)obj, env.FromReflectedField(objField).Addr, value);
    public void SetFloat(Env env, JObject obj, float value) => env.Master->SetFloatField((IntPtr)obj, env.FromReflectedField(objField).Addr, value);
    public void SetDouble(Env env, JObject obj, double value) => env.Master->SetDoubleField((IntPtr)obj, env.FromReflectedField(objField).Addr, value);

    public void Dispose()
    {
        field.Dispose();
        objField.Dispose();
    }

    public static explicit operator JField(JGField field) => field.field;
}