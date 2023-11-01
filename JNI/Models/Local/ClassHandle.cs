using JNI.Core;
using JNI.Core.Enums;
using JNI.Internal;

namespace JNI.Models.Local;
public unsafe class ClassHandle : LHandle
{
    public ClassHandle(Env env, nint handle) : base(env, handle) { }

    public JCtor GetCtorA(params Arg[] args) => new(GetMethodA("<init>", Env.Types.Void, args));
    public JCtor GetCtor(params TypeInfo[] types) => new(GetMethod("<init>", Env.Types.Void, types));

    public JField GetField(string name, TypeInfo type) => EnvHelper.GetField(Env, this, name, type);

    public JStaticField GetStaticField(string name, TypeInfo type) => EnvHelper.GetStaticField(Env, this, name, type);

    public JMethod GetMethodA(string name, TypeInfo type, params Arg[] args) => EnvHelper.GetMethod(Env, this, name, type, args);
    public JMethod GetMethod(string name, TypeInfo type, params TypeInfo[] types) => EnvHelper.GetMethod(Env, this, name, type, types.ToArgs());

    public JStaticMethod GetStaticMethodA(string name, TypeInfo type, params Arg[] args) => EnvHelper.GetStaticMethod(Env, this, name, type, args);
    public JStaticMethod GetStaticMethod(string name, TypeInfo type, params TypeInfo[] types) => EnvHelper.GetStaticMethod(Env, this, name, type, types.ToArgs());

    public ClassHandle GetSuperclass() => new ClassHandle(Env, Env.Native->GetSuperclass(Addr));
    public bool AssignableFrom(ClassHandle clazz) => Env.Native->IsAssignableFrom(Addr, !clazz);

    public JObject AsObject => new(Env, Addr);

    public RetCode RegisterNatives(params NativeMethod_[] methods)
    {
        fixed (NativeMethod_* ptr = methods)
            return Env.Native->RegisterNatives(Addr, ptr, methods.Length);
    }
    public RetCode RegisterNatives(Env env, params NativeMethod[] methods)
    {
        fixed (NativeMethod_* ptr = methods.ToStructs())
            return env.Native->RegisterNatives(Addr, ptr, methods.Length);
    }
    public RetCode UnregisterNatives() => Env.Native->UnregisterNatives(Addr);
}