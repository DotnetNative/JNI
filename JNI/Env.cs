namespace JNI;
public sealed unsafe class Env
{
    static bool inited;
    public Env(Env_* e)
    {
        Native = e;

        if (inited)
            return;
        inited = true;

        EnvResolver = new(e);
        OnInit?.Invoke();
        Types = new(this);

        foreach (var init in new[]
        {
            ClassNotion.Init,
            JString.Init,
            EnumNotion.Init
        }) init(this);
    }

    public delegate void OnInitDelegate();
    public static event OnInitDelegate? OnInit;

    [AllowNull] public static RuntimeTypeCollection Types;
    [AllowNull] public static EnvResolver EnvResolver;

    public Env_* Native;

    #region Type
    nint GetClassHandle(string name)
    {
        using var nameCo = new CoMem(name.AsJavaPath());
        return Native->FindClass(nameCo.Ptr);
    }

    public JClass GetClass(string name) => new(HandleImpl.Create(GetClassHandle(name)));

    public JType GetType(string name, string sig, int dim = 0)
    {
        var info = new TypeInfo(name.AsJavaPath(), sig.AsJavaPath(), dim);
        return new(HandleImpl.Create(GetClassHandle(name)), info);
    }
    public JType GetType(string nameAndSig, int dim = 0) => new(HandleImpl.Create(GetClassHandle(nameAndSig)), nameAndSig.AsJavaPath(), dim);
    public JType GetType(TypeInfo info) => new(HandleImpl.Create(GetClassHandle(info.Name)), info);

    public JEnum GetEnum(string name) => new(HandleImpl.Create(GetClassHandle(name)), new(name));
    public JEnum GetEnum(TypeInfo info) => new(HandleImpl.Create(GetClassHandle(info.Name)), info);

    public JClass DefineClass(string name, JObject loader, byte[] bytes)
    {
        fixed (byte* ptr = bytes)
            return new(HandleImpl.Create(Native->DefineClass(name, loader, ptr, bytes.Length)));
    }
    #endregion

    #region Frame
    public JObject PopLocalFrame(JObject result) => JObject.Create(Native->PopLocalFrame(result));
    public int PushLocalFrame(int capacity) => Native->PushLocalFrame(capacity);
    #endregion

    #region Reflect
    public JObject ToReflectedField(JClass clazz, FieldDescriptor field, bool isStatic = false) => JObject.Create(Native->ToReflectedField(clazz, field, isStatic));
    public JObject ToReflectedMethod(JClass clazz, MethodDescriptor method, bool isStatic = false) => JObject.Create(Native->ToReflectedMethod(clazz, method, isStatic));
    public FieldDescriptor FromReflectedField(JObject field) => new(HandleImpl.Create(Native->FromReflectedField(field)));
    public MethodDescriptor FromReflectedMethod(JObject method) => new(HandleImpl.Create(Native->FromReflectedMethod(method)));
    #endregion

    #region Sync
    public RetCode Enter(JObject obj) => Native->MonitorEnter(obj);
    public RetCode Exit(JObject obj) => Native->MonitorExit(obj);
    #endregion

    #region Exception
    public void ExceptionClear() => Native->ExceptionClear();
    public bool ExceptionCheck() => Native->ExceptionCheck();
    public void ExceptionDescribe() => Native->ExceptionDescribe();
    public JObject ExceptionOccurred() => JObject.Create(Native->ExceptionOccurred());
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

    public static Env_* env_ => EnvResolver.Resolve();
    public static Env env => new(env_);
}