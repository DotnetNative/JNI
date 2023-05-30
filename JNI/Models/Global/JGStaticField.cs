using JNI.Internal;
using JNI.Models.Local;
using JNI.Utils;
using System.Security.Claims;

namespace JNI.Models.Global;
public unsafe sealed class JGStaticField
{
    public JGStaticField(Env env, GClassHandle clazz, string name, TypeInfo type)
    {
        Class = clazz;
        Name = name;

        using var nameCo = new CoMem(Name);
        using var sigCo = new CoMem(SigGen.Field(type));
        FieldHandle = new(env, env.Master->GetStaticFieldID(!clazz, !nameCo, !sigCo));

        var objF = env.Master->ToReflectedField(!clazz, !FieldHandle, true);
        ObjField = new(env.Master->NewGlobalRef(objF), objF);
    }

    public GClassHandle Class;
    public string Name;

    public JGObject ObjField;
    public LHandle FieldHandle;

    public JGObject GetValue(Env env)
    {
        var obj = env.Master->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Master->NewGlobalRef(obj), obj);
    }
    public JGString GetString(Env env, bool isUnicode = true)
    {
        var res = env.Master->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
        return new(env.Master->NewGlobalRef(res), res, isUnicode);
    }
    public bool GetBool(Env env) => env.Master->GetStaticBooleanField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public byte GetByte(Env env) => env.Master->GetStaticByteField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public short GetShort(Env env) => env.Master->GetStaticShortField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public int GetInt(Env env) => env.Master->GetStaticIntField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public long GetLong(Env env) => env.Master->GetStaticLongField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public float GetFloat(Env env)  => env.Master->GetStaticFloatField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    public double GetDouble(Env env) => env.Master->GetStaticDoubleField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)));
    
    public void SetValue(Env env, JObject value) 
        => env.Master->SetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), !value);

    public void SetValue(Env env, JGObject value)
        => env.Master->SetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), !value);

    public void SetBool(Env env, bool value)
        => env.Master->SetStaticBooleanField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetByte(Env env, byte value)
        => env.Master->SetStaticByteField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetShort(Env env, short value)
        => env.Master->SetStaticShortField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetInt(Env env, int value)
        => env.Master->SetStaticIntField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetLong(Env env, long value)
        => env.Master->SetStaticLongField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetFloat(Env env, float value)
        => env.Master->SetStaticFloatField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public void SetDouble(Env env, double value) 
        => env.Master->SetStaticDoubleField(!Class, !env.FromReflectedField(ObjField.AsWeak(env)), value);

    public JObject GetLocalValue(Env env, JGObject obj) 
        => new(env, env.Master->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env))));

    public JString GetLocalString(Env env, JGObject obj, bool isUnicode = true) 
        => new(env, env.Master->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env))), isUnicode);

    public JObject GetLocalValue(Env env, JObject obj)
        => new(env, env.Master->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env))));

    public JString GetLocalString(Env env, JObject obj, bool isUnicode = true)
        => new(env, env.Master->GetStaticObjectField(!Class, !env.FromReflectedField(ObjField.AsWeak(env))), isUnicode);

    /* Call it only in main thread for real */
    public void Dispose(Env env)
    {
        ObjField.Dispose(env);
        FieldHandle.Dispose();
    }
}