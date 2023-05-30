using JNI.Internal;
using JNI.Models.Local;
using JNI.Utils;

namespace JNI.Models.Global;

public unsafe sealed class JGField
{
    public JGField(Env env, GClassHandle clazz, string name, TypeInfo type)
    {
        Name = name;
        using var nameCo = new CoMem(Name);
        using var sigCo = new CoMem(SigGen.Field(type));
        FieldHandle = new(env, env.Master->GetFieldID(!clazz, !nameCo, !sigCo));

        var objF = env.Master->ToReflectedField(!clazz, !FieldHandle, false);
        ObjField = new(env.Master->NewGlobalRef(objF), objF);
    }

    public string Name;

    public JGObject ObjField;
    public LHandle FieldHandle;

    public JGObject GetValue(Env env, JGObject obj)
    {
        var res = env.Master->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Master->NewGlobalRef(res), res);
    }

    public JGString GetString(Env env, JGObject obj, bool isUnicode = true)
    {        
        var res = env.Master->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Master->NewGlobalRef(res), res, isUnicode);
    }

    public bool GetBool(Env env, JGObject obj)
        => env.Master->GetBooleanField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public byte GetByte(Env env, JGObject obj)
        => env.Master->GetByteField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));   

    public short GetShort(Env env, JGObject obj)
        => env.Master->GetShortField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public int GetInt(Env env, JGObject obj)
        => env.Master->GetIntField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public long GetLong(Env env, JGObject obj)
        => env.Master->GetLongField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public float GetFloat(Env env, JGObject obj)
        => env.Master->GetFloatField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public double GetDouble(Env env, JGObject obj)
        => env.Master->GetDoubleField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public void SetValue(Env env, JGObject obj, JObject value)
        => env.Master->SetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), !value);

    public void SetValue(Env env, JGObject obj, JGObject value)
        => env.Master->SetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), !value);

    public void SetBool(Env env, JGObject obj, bool value)
        => env.Master->SetBooleanField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetByte(Env env, JGObject obj, byte value)
        => env.Master->SetByteField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetShort(Env env, JGObject obj, short value)
        => env.Master->SetShortField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetInt(Env env, JGObject obj, int value)
        => env.Master->SetIntField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetLong(Env env, JGObject obj, long value)
        => env.Master->SetLongField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetFloat(Env env, JGObject obj, float value)
        => env.Master->SetFloatField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetDouble(Env env, JGObject obj, double value)
        => env.Master->SetDoubleField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public JGObject GetValue(Env env, JObject obj)
    {        
        var res = env.Master->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Master->NewGlobalRef(res), res);
    }

    public JGString GetString(Env env, JObject obj, bool isUnicode = true)
    {        
        var res = env.Master->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Master->NewGlobalRef(res), res, isUnicode);
    }

    public bool GetBool(Env env, JObject obj)
        => env.Master->GetBooleanField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public byte GetByte(Env env, JObject obj)
        => env.Master->GetByteField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public short GetShort(Env env, JObject obj)
        => env.Master->GetShortField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public int GetInt(Env env, JObject obj)
        => env.Master->GetIntField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public long GetLong(Env env, JObject obj)
        => env.Master->GetLongField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public float GetFloat(Env env, JObject obj)
        => env.Master->GetFloatField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public double GetDouble(Env env, JObject obj)
        => env.Master->GetDoubleField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public void SetValue(Env env, JObject obj, JObject value)
        => env.Master->SetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), !value);

    public void SetBool(Env env, JObject obj, bool value)
        => env.Master->SetBooleanField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetByte(Env env, JObject obj, byte value)
        => env.Master->SetByteField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetShort(Env env, JObject obj, short value)
        => env.Master->SetShortField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetInt(Env env, JObject obj, int value)
        => env.Master->SetIntField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetLong(Env env, JObject obj, long value)
        => env.Master->SetLongField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetFloat(Env env, JObject obj, float value)
        => env.Master->SetFloatField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetDouble(Env env, JObject obj, double value)
        => env.Master->SetDoubleField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public JObject GetLocalValue(Env env, JGObject obj)
        => new(env, env.Master->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env))));

    public JString GetLocalString(Env env, JGObject obj, bool isUnicode = true)
        => new(env, env.Master->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env))), isUnicode);

    public JObject GetLocalValue(Env env, JObject obj)
        => new(env, env.Master->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env))));

    public JString GetLocalString(Env env, JObject obj, bool isUnicode = true)
        => new(env, env.Master->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env))), isUnicode);

    /* Call it only in main thread for real */
    public void Dispose(Env env)
    {
        ObjField.Dispose(env);
        FieldHandle.Dispose();
    }
}