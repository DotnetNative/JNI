using JNI.Core;
using Memory;
using static JNI.Internal.Interop;

namespace JNI;
public sealed unsafe class Env
{
    public Env(Env_* env)
    {
        Native = env;

        if (!init)
        {
            init = true;

            StaticTypes = new RuntimeTypeCollection(this);

            java.lang.String.Init(this);
            java.lang.Enum.Init(this);
        }

        Types = StaticTypes;
    }

    static bool init;

    public static RuntimeTypeCollection StaticTypes;
    public RuntimeTypeCollection Types;

    public Env_* Native;

    #region Type
    public nint GetClassHandle(string name)
    {
        using var nameCo = new CoMem(name.AsJavaPath());
        return Native->FindClass(nameCo.Ptr);
    }

    public LJClass GetClass(string name) => new(LHandle.Create(GetClassHandle(name)));
    public GJClass GetGClass(string name) => new(GHandle.Create(GetClassHandle(name)));

    public LJType GetType(string name, string sig, int dim = 0)
    {
        var info = new TypeInfo(name.AsJavaPath(), sig.AsJavaPath(), dim);
        return new(LHandle.Create(GetClassHandle(name)), info);
    }
    public LJType GetType(string nameAndSig, int dim = 0) => new(LHandle.Create(GetClassHandle(nameAndSig)), nameAndSig.AsJavaPath(), dim);
    public LJType GetType(TypeInfo info) => new(LHandle.Create(GetClassHandle(info.Name)), info);

    public GJType GetGType(string name, string sig, int dim = 0)
    {
        var info = new TypeInfo(name.AsJavaPath(), sig.AsJavaPath(), dim);
        return new(GHandle.Create(GetClassHandle(name)), info);
    }
    public GJType GetGType(string nameAndSig, int dim = 0) => new(GHandle.Create(GetClassHandle(nameAndSig)), nameAndSig.AsJavaPath(), dim);
    public GJType GetGType(TypeInfo info) => new(GHandle.Create(GetClassHandle(info.Name)), info);

    public LJClass DefineClass(string name, JObject loader, byte[] bytes)
    {
        using var nameCo = new CoMem(name.AsJavaPath());
        fixed (byte* ptr = bytes)
            return new(LHandle.Create(Native->DefineClass(nameCo.Ptr, loader, ptr, bytes.Length)));
    }

    public GJClass DefineGClass(string name, JObject loader, byte[] bytes)
    {
        using var nameCo = new CoMem(name.AsJavaPath());
        fixed (byte* ptr = bytes)
            return new GJClass(GHandle.Create(Native->DefineClass(nameCo.Ptr, loader, ptr, bytes.Length)));
    }
    #endregion

    #region Frame
    public LJObject PopLocalFrame(JObject result) => LJObject.Create(Native->PopLocalFrame(result));
    public int PushLocalFrame(int capacity) => Native->PushLocalFrame(capacity);
    #endregion

    #region Reflect
    public LJObject ToReflectedMethod(JClass clazz, MethodHandle method, bool isStatic = false) => LJObject.Create(Native->ToReflectedMethod(clazz, method, isStatic));
    public LJObject ToReflectedField(JClass clazz, FieldHandle field, bool isStatic = false) => LJObject.Create(Native->ToReflectedField(clazz, field, isStatic));
    public FieldHandle FromReflectedField(JObject field) => new FieldHandle(LHandle.Create(Native->FromReflectedField(field)));
    public MethodHandle FromReflectedMethod(JObject method) => new MethodHandle(LHandle.Create(Native->FromReflectedMethod(method)));

    public GJObject ToGReflectedMethod(JClass clazz, MethodHandle method, bool isStatic = false) => GJObject.Create(Native->ToReflectedMethod(clazz, method, isStatic));
    public GJObject ToGReflectedField(JClass clazz, FieldHandle field, bool isStatic = false) => GJObject.Create(Native->ToReflectedField(clazz, field, isStatic));
    public FieldHandle FromReflectedFieldG(JObject field) => new FieldHandle(GHandle.Create(Native->FromReflectedField(field)));
    public MethodHandle FromReflectedMethodG(JObject method) => new MethodHandle(GHandle.Create(Native->FromReflectedMethod(method)));
    #endregion

    #region Sync
    public RetCode Lock(JObject obj) => Native->MonitorEnter(obj);
    public RetCode Unlock(JObject obj) => Native->MonitorExit(obj);
    #endregion

    #region Exception
    public void ExceptionClear() => Native->ExceptionClear();
    public bool ExceptionCheck() => Native->ExceptionCheck();
    public void ExceptionDescribe() => Native->ExceptionDescribe();
    public LJObject ExceptionOccurred() => LJObject.Create(Native->ExceptionOccurred());
    public RetCode Throw(JObject obj) => Native->Throw(obj);
    public RetCode ThrowNew(JClass clazz, string msg)
    {
        using var msgCo = new CoMem(msg);
        return Native->ThrowNew(clazz, msgCo.Ptr);
    }
    public void FatalError(string msg)
    {
        using var msgCo = new CoMem(msg);
        Native->FatalError(msgCo.Ptr);
    }
    #endregion

    #region Info
    public JVersion Version => Native->GetVersion();
    #endregion

    #region Tls
    public static int TlsIndex = 5;
    public static nint TlsEnvOffset = 0x1F8;

    public static Env_* ThreadNativeEnv
    {
        get
        {
            var tls = (byte*)TlsGetValue(TlsIndex);
            return (Env_*)(tls + TlsEnvOffset);
        }
    }

    public static Env ThreadEnv => new(ThreadNativeEnv);
    #endregion
}