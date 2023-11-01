using JNI.Core.Enums;
using JNI.Core;
using JNI.Internal;
using JNI.Models.Local;
using JNI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JNI.New.Handles;

namespace JNI.New.Models.Class;
public unsafe class ClassHandle : HandleContainer
{
    public ClassHandle(EnvHandle handle) : base(handle) { }

    public JCtor GetCtorA(params Arg[] args) => new(GetMethodA("<init>", Env.Types.Void, args));
    public JCtor GetCtor(params TypeInfo[] types) => new(GetMethod("<init>", Env.Types.Void, types));

    public JField GetField(string name, TypeInfo type) => EnvHelper.GetField(Env, this, name, type);

    public JStaticField GetStaticField(string name, TypeInfo type) => EnvHelper.GetStaticField(Env, this, name, type);

    public JMethod GetMethodA(string name, TypeInfo type, params Arg[] args) => EnvHelper.GetMethod(Env, this, name, type, args);
    public JMethod GetMethod(string name, TypeInfo type, params TypeInfo[] types) => EnvHelper.GetMethod(Env, this, name, type, types.ToArgs());

    public JStaticMethod GetStaticMethodA(string name, TypeInfo type, params Arg[] args) => EnvHelper.GetStaticMethod(Env, this, name, type, args);
    public JStaticMethod GetStaticMethod(string name, TypeInfo type, params TypeInfo[] types) => EnvHelper.GetStaticMethod(Env, this, name, type, types.ToArgs());

    public ClassHandle GetSuperclass() => new ClassHandle(Env, Env.Native->GetSuperclass(Addr));
    public bool AssignableFrom(ClassHandle clazz) => Env.Native->IsAssignableFrom(Addr, clazz);

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