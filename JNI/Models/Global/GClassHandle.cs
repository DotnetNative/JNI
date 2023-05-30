using JNI.Enums;
using JNI.Internal;
using JNI.Low;
using JNI.Models.Weak;

namespace JNI.Models.Global;
public unsafe class GClassHandle : GHandle
{
    public GClassHandle(nint gAddr, nint lAddr) : base(gAddr, lAddr) { }

    public JGCtor GetCtorA(Env env, params Arg[] args) => new JGCtor(GetMethodA(env, "<init>", env.Types.Void, args));
    public JGCtor GetCtor(Env env, params TypeInfo[] types) => new JGCtor(GetMethod(env, "<init>", env.Types.Void, types));

    public JGField GetField(Env env, string name, TypeInfo type) => EnvHelper.GetGlobalField(env, this, name, type);

    public JGStaticField GetStaticField(Env env, string name, TypeInfo type) => EnvHelper.GetGlobalStaticField(env, this, name, type);

    public JGMethod GetMethodA(Env env, string name, TypeInfo type, params Arg[] args) => EnvHelper.GetGlobalMethod(env, this, name, type, args);
    public JGMethod GetMethod(Env env, string name, TypeInfo type, params TypeInfo[] types) => EnvHelper.GetGlobalMethod(env, this, name, type, types.ToArgs());

    public JGStaticMethod GetStaticMethodA(Env env, string name, TypeInfo type, params Arg[] args) => EnvHelper.GetGlobalStaticMethod(env, this, name, type, args);
    public JGStaticMethod GetStaticMethod(Env env, string name, TypeInfo type, params TypeInfo[] types) => EnvHelper.GetGlobalStaticMethod(env, this, name, type, types.ToArgs());
    public WeakClassHandle AsWeak(Env env) => new WeakClassHandle(env, Addr);

    public GClassHandle GetSuperclass(Env env)
    {
        var cls = env.Master->GetSuperclass(Addr);
        return new GClassHandle(env.NewGlobalRef(cls), cls);
    }
    public bool AssignableFrom(Env env, ClassHandle clazz) => env.Master->IsAssignableFrom(Addr, !clazz);

    public RetCode RegisterNatives(Env env, params NativeMethod_[] methods)
    {
        fixed (NativeMethod_* ptr = methods)
            return env.Master->RegisterNatives(Addr, ptr, methods.Length);
    }
    public RetCode RegisterNatives(Env env, params NativeMethod[] methods) => RegisterNatives(env, methods.ToStructs());
    public RetCode UnregisterNatives(Env env) => env.Master->UnregisterNatives(Addr);
}