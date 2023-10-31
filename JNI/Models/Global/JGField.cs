using JNI.Internal;
using JNI.Models.Local;
using JNI.Utils;
using Memory;

namespace JNI.Models.Global;

public unsafe sealed class JGField
{
    public JGField(Env env, GClassHandle clazz, string name, TypeInfo type)
    {
        Name = name;
        using var nameCo = new CoMem(Name);
        using var sigCo = new CoMem(SigGen.Field(type));
        FieldHandle = new(env, env.Native->GetFieldID(!clazz, (byte*)nameCo, (byte*)sigCo));

        var objF = env.Native->ToReflectedField(!clazz, !FieldHandle, false);
        ObjField = new(env.Native->NewGlobalRef(objF), objF);
    }

    public string Name;

    public JGObject ObjField;
    public LHandle FieldHandle;

    public JGObject GetValue(Env env, JGObject obj)
    {
        var res = env.Native->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Native->NewGlobalRef(res), res);
    }

    public JGString GetString(Env env, JGObject obj, bool isUnicode = true)
    {        
        var res = env.Native->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Native->NewGlobalRef(res), res, isUnicode);
    }

    public bool GetBool(Env env, JGObject obj)
        => env.Native->GetBooleanField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public byte GetByte(Env env, JGObject obj)
        => env.Native->GetByteField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));   

    public short GetShort(Env env, JGObject obj)
        => env.Native->GetShortField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public int GetInt(Env env, JGObject obj)
        => env.Native->GetIntField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public long GetLong(Env env, JGObject obj)
        => env.Native->GetLongField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public float GetFloat(Env env, JGObject obj)
        => env.Native->GetFloatField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public double GetDouble(Env env, JGObject obj)
        => env.Native->GetDoubleField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public void SetValue(Env env, JGObject obj, JObject value)
        => env.Native->SetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), !value);

    public void SetValue(Env env, JGObject obj, JGObject value)
        => env.Native->SetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), !value);

    public void SetBool(Env env, JGObject obj, bool value)
        => env.Native->SetBooleanField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetByte(Env env, JGObject obj, byte value)
        => env.Native->SetByteField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetShort(Env env, JGObject obj, short value)
        => env.Native->SetShortField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetInt(Env env, JGObject obj, int value)
        => env.Native->SetIntField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetLong(Env env, JGObject obj, long value)
        => env.Native->SetLongField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetFloat(Env env, JGObject obj, float value)
        => env.Native->SetFloatField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetDouble(Env env, JGObject obj, double value)
        => env.Native->SetDoubleField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public JGObject GetValue(Env env, JObject obj)
    {        
        var res = env.Native->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Native->NewGlobalRef(res), res);
    }

    public JGString GetString(Env env, JObject obj, bool isUnicode = true)
    {        
        var res = env.Native->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Native->NewGlobalRef(res), res, isUnicode);
    }

    public bool GetBool(Env env, JObject obj)
        => env.Native->GetBooleanField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public byte GetByte(Env env, JObject obj)
        => env.Native->GetByteField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public short GetShort(Env env, JObject obj)
        => env.Native->GetShortField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public int GetInt(Env env, JObject obj)
        => env.Native->GetIntField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public long GetLong(Env env, JObject obj)
        => env.Native->GetLongField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public float GetFloat(Env env, JObject obj)
        => env.Native->GetFloatField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public double GetDouble(Env env, JObject obj)
        => env.Native->GetDoubleField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)));

    public void SetValue(Env env, JObject obj, JObject value)
        => env.Native->SetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), !value);

    public void SetBool(Env env, JObject obj, bool value)
        => env.Native->SetBooleanField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetByte(Env env, JObject obj, byte value)
        => env.Native->SetByteField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetShort(Env env, JObject obj, short value)
        => env.Native->SetShortField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetInt(Env env, JObject obj, int value)
        => env.Native->SetIntField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetLong(Env env, JObject obj, long value)
        => env.Native->SetLongField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetFloat(Env env, JObject obj, float value)
        => env.Native->SetFloatField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetDouble(Env env, JObject obj, double value)
        => env.Native->SetDoubleField(!obj, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public JObject GetLocalValue(Env env, JGObject obj)
        => new(env, env.Native->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env))));

    public JString GetLocalString(Env env, JGObject obj, bool isUnicode = true)
        => new(env, env.Native->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env))), isUnicode);

    public JObject GetLocalValue(Env env, JObject obj)
        => new(env, env.Native->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env))));

    public JString GetLocalString(Env env, JObject obj, bool isUnicode = true)
        => new(env, env.Native->GetObjectField(!obj, !env.FromReflectedField(ObjField.AsWeak(env))), isUnicode);

    /* Call it only in main thread for real */
    public void Dispose(Env env)
    {
        ObjField.Dispose(env);
        FieldHandle.Dispose();
    }
}