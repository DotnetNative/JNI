using CSJNI;
using CSJNI.High;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class ClassHandle : HandleEnv
{
    public ClassHandle(Env env, IntPtr handle) : base(env, handle) { }
    
    public JCtor GetCtorA(params Arg[] args) => new JCtor(GetMethodA("<init>", Env.Types.Void, args));
    public JCtor GetCtor(params JType[] types) => new JCtor(GetMethod("<init>", Env.Types.Void, types));
    public JField GetField(string name, JType type) => Env.GetFieldID(this, name, type);
    public JStaticField GetStaticField(string name, JType type) => Env.GetStaticFieldID(this, name, type);
    public JMethod GetMethodA(string name, JType type, params Arg[] args) => Env.GetMethodID(this, name, type, args);
    public JMethod GetMethod(string name, JType type, params JType[] types) => Env.GetMethodID(this, name, type, types.ToArgs());
    public JStaticMethod GetStaticMethodA(string name, JType type, params Arg[] args) => Env.GetStaticMethodID(this, name, type, args);
    public JStaticMethod GetStaticMethod(string name, JType type, params JType[] types) => Env.GetStaticMethodID(this, name, type, types.ToArgs());
}