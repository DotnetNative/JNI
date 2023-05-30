using JNI.Internal;
using JNI.Models;
using JNI.Models.Global;
using JNI.Models.Local;
using JNI.Utils;

namespace JNI;
public static unsafe class EnvHelper
{
    public static JField GetField(Env env, ClassHandle clazz, string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return new(env, env.Master->GetFieldID(!clazz, nameCo.Ptr, sigCo.Ptr), name, sig);
    }
    public static JGField GetGlobalField(Env env, GClassHandle clazz, string name, TypeInfo type) => new(env, clazz, name, type);

    public static JStaticField GetStaticField(Env env, ClassHandle clazz, string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return new(env, env.Master->GetFieldID(!clazz, nameCo.Ptr, sigCo.Ptr), name, sig, clazz);
    }
    public static JGStaticField GetGlobalStaticField(Env env, GClassHandle clazz, string name, TypeInfo type) => new(env, clazz, name, type);

    public static JStaticMethod GetStaticMethod(Env env, ClassHandle clazz, string name, TypeInfo type, params Arg[] args) => new(env, name, type, clazz, args);
    public static JGStaticMethod GetGlobalStaticMethod(Env env, ClassHandle clazz, string name, TypeInfo type, params Arg[] args) => new(env, name, type, clazz, args);
    public static JGStaticMethod GetGlobalStaticMethod(Env env, GClassHandle clazz, string name, TypeInfo type, params Arg[] args) => GetGlobalStaticMethod(env, clazz.AsWeak(env), name, type, args);
    
    public static JMethod GetMethod(Env env, ClassHandle clazz, string name, TypeInfo type, params Arg[] args) => new(env, name, type, clazz, args);
    public static JGMethod GetGlobalMethod(Env env, ClassHandle clazz, string name, TypeInfo type, params Arg[] args)
    {
        var meth = new JGMethod(env, name, type, clazz, args);
        return meth;
    }
    public static JGMethod GetGlobalMethod(Env env, GClassHandle clazz, string name, TypeInfo type, params Arg[] args) => GetGlobalMethod(env, clazz.AsWeak(env), name, type, args);
}