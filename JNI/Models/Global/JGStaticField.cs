using JNI.Internal;
using JNI.Models.Local;
using JNI.Utils;
using Memory;

namespace JNI.Models.Global;
public unsafe sealed class JGStaticField
{
    public JGStaticField(Env env, GClassHandle clazz, string name, TypeInfo type)
    {
        Class = clazz;
        Name = name;

        using var nameCo = new CoMem(Name);
        using var sigCo = new CoMem(SigGen.Field(type));
        FieldHandle = new(env, env.Native->GetStaticFieldID(!clazz, (byte*)nameCo, (byte*)sigCo));

        var objF = env.Native->ToReflectedField(!clazz, !FieldHandle, true);
        ObjField = new(env.Native->NewGlobalRef(objF), objF);
    }

    public GClassHandle Class;
    public string Name;

    public JGObject ObjField;
    public LHandle FieldHandle;

    public JGObject GetValue(Env env)
    {
        var obj = env.Native->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Native->NewGlobalRef(obj), obj);
    }
    public JGString GetString(Env env, bool isUnicode = true)
    {
        var res = env.Native->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Native->NewGlobalRef(res), res, isUnicode);
    }
    public bool GetBool(Env env) => env.Native->GetStaticBooleanField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public byte GetByte(Env env) => env.Native->GetStaticByteField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public short GetShort(Env env) => env.Native->GetStaticShortField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public int GetInt(Env env) => env.Native->GetStaticIntField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public long GetLong(Env env) => env.Native->GetStaticLongField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public float GetFloat(Env env)  => env.Native->GetStaticFloatField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public double GetDouble(Env env) => env.Native->GetStaticDoubleField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    
    public void SetValue(Env env, JObject value) 
        => env.Native->SetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), !value);

    public void SetValue(Env env, JGObject value)
        => env.Native->SetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), !value);

    public void SetBool(Env env, bool value)
        => env.Native->SetStaticBooleanField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetByte(Env env, byte value)
        => env.Native->SetStaticByteField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetShort(Env env, short value)
        => env.Native->SetStaticShortField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetInt(Env env, int value)
        => env.Native->SetStaticIntField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetLong(Env env, long value)
        => env.Native->SetStaticLongField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetFloat(Env env, float value)
        => env.Native->SetStaticFloatField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetDouble(Env env, double value) 
        => env.Native->SetStaticDoubleField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public JObject GetLocalValue(Env env, JGObject obj) 
        => new(env, env.Native->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env))));

    public JString GetLocalString(Env env, JGObject obj, bool isUnicode = true) 
        => new(env, env.Native->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env))), isUnicode);

    public JObject GetLocalValue(Env env, JObject obj)
        => new(env, env.Native->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env))));

    public JString GetLocalString(Env env, JObject obj, bool isUnicode = true)
        => new(env, env.Native->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env))), isUnicode);

    /* Call it only in main thread for real */
    public void Dispose(Env env)
    {
        ObjField.Dispose(env);
        FieldHandle.Dispose();
    }
}