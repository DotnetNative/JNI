using JNI.Internal;
using JNI.Models.Global;
using JNI.Models.Local;

namespace JNI.Models;
public unsafe class ClassHandle : HandleEnv
{
    public ClassHandle(Env env, IntPtr handle) : base(env, handle) { }

    public JCtor GetCtorA(params Arg[] args) => new JCtor(GetMethodA("<init>", Env.Types.Void, args));
    public JCtor GetCtor(params JType[] types) => new JCtor(GetMethod("<init>", Env.Types.Void, types));
    public JGCtor GetGlobalCtorA(params Arg[] args) => new JGCtor(GetGlobalMethodA("<init>", Env.Types.Void, args));
    public JGCtor GetGlobalCtor(params JType[] types) => new JGCtor(GetGlobalMethod("<init>", Env.Types.Void, types));

    public JField GetField(string name, JType type) => Env.GetFieldID(this, name, type);
    public JGField GetGlobalField(string name, JType type) => new JGField(Env, this, name, type);

    public JStaticField GetStaticField(string name, JType type) => Env.GetStaticFieldID(this, name, type);
    public JGStaticField GetGlobalStaticField(string name, JType type) => new JGStaticField(Env, this, name, type);

    public JMethod GetMethodA(string name, JType type, params Arg[] args) => Env.GetMethodID(this, name, type, args);
    public JMethod GetMethod(string name, JType type, params JType[] types) => Env.GetMethodID(this, name, type, types.ToArgs());
    public JGMethod GetGlobalMethodA(string name, JType type, params Arg[] args) => Env.GetGlobalMethodID(this, name, type, args);
    public JGMethod GetGlobalMethod(string name, JType type, params JType[] types) => Env.GetGlobalMethodID(this, name, type, types.ToArgs());

    public JStaticMethod GetStaticMethodA(string name, JType type, params Arg[] args) => Env.GetStaticMethodID(this, name, type, args);
    public JStaticMethod GetStaticMethod(string name, JType type, params JType[] types) => Env.GetStaticMethodID(this, name, type, types.ToArgs());
    public JGStaticMethod GetGlobalStaticMethodA(string name, JType type, params Arg[] args) => Env.GetGlobalStaticMethodID(this, name, type, args);
    public JGStaticMethod GetGlobalStaticMethod(string name, JType type, params JType[] types) => Env.GetGlobalStaticMethodID(this, name, type, types.ToArgs());
}