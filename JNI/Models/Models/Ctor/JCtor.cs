using JNI.Models;
using JNI.Models.Handles;
using JNI.Models.Models;
using JNI.Models.Models.Class;
using JNI.Models.Models.Method;
using JNI.Models.Models.Object;
using JNI.Models.Models.Type;

namespace JNI.Models.Models.Ctor;
public unsafe abstract class JCtor : JMethod
{
    public JCtor(EnvHandle handle, string name, Arg[] args, JClass clazz) : base(handle, name, handle.Env.Types.Void, clazz, args) { }
    public JCtor(JMethod method) : base(method.Handle, method.MethodName, method.ReturnType, method.Clazz) { }

    public LJObject NewInstance(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return LJObject.Create(Env.Native->NewObjectA(Clazz, Addr, ptr));
    }

    public GJObject NewGInstance(params JValue[] args)
    {
        fixed (JValue* ptr = args)
            return GJObject.Create(Env.Native->NewObjectA(Clazz, Addr, ptr));
    }
}

public unsafe class LJCtor : JCtor
{
    public LJCtor(LHandle handle, string name, Arg[] args, JClass clazz) : base(handle, name, args, clazz) { }

    public LJCtor(LJVoidMethod method) : base(method) { }
}

public unsafe class GJCtor : JCtor
{
    public GJCtor(GHandle handle, string name, Arg[] args, JClass clazz) : base(handle, name, args, clazz) { }

    public GJCtor(GJVoidMethod method) : base(method) { }
}