using JNI.Enums;
using JNI.Internal;
using JNI.Low;
using JNI.Models;
using JNI.Models.Global;
using JNI.Models.Local;

namespace JNI;
public sealed unsafe class Env
{
    public Env(Env_* env)
    {
        Master = env;

        if (!init)
        {
            STypes = new RuntimeTypeCollection(this);
            init = true;
        }

        Types = STypes;
    }

    static Env()
    {
        fixed (bool* ptr = &trueValue)
            TruePtr = ptr;
        fixed (bool* ptr = &falseValue)
            FalsePtr = ptr;
    }

    private static bool init;

    private static bool trueValue = true, falseValue;
    public static bool* TruePtr, FalsePtr;

    public Env_* Master;

    public static RuntimeTypeCollection STypes;
    public RuntimeTypeCollection Types;

    #region Type
    public ClassHandle GetClass(string name) => new(this, GetClassHandle(name));
    public nint GetClassHandle(string name)
    {
        using var nameCo = new CoMem(name.AsJavaPath());
        return Master->FindClass(nameCo.Ptr);
    }
    public JGType GetGlobalType(TypeInfo info)
    {
        var type = GetType(info);
        return new(NewGlobalRef(type.Addr), type.Addr, info);
    }
    public JGType GetGlobalType(string name, string sig, int dim) => GetGlobalType(new(name.AsJavaPath(), sig.AsJavaPath(), dim));
    public JGType GetGlobalType(string nameAndSig, int dim = 0) => GetGlobalType(nameAndSig, nameAndSig, dim);
    public JType GetType(string name, string sig, int dim = 0)
    {
        var info = new TypeInfo(name.AsJavaPath(), sig.AsJavaPath(), dim);
        return new(this, info);
    }
    public JType GetType(string nameAndSign, int dim = 0) => new(this, nameAndSign.AsJavaPath(), dim);
    public JType GetType(TypeInfo info) => new(this, info);
    public ClassHandle DefineClass(string name, JObject loader, byte[] bytes)
    {
        using var nameCo = new CoMem(name.AsJavaPath());
        fixed (byte* ptr = bytes)
            return new(this, Master->DefineClass(nameCo.Ptr, !loader, ptr, bytes.Length));
    }
    #endregion

    #region Frame
    public JObject PopLocalFrame(JObject result) => new(this, Master->PopLocalFrame((nint)result));
    public int PushLocalFrame(int capacity) => Master->PushLocalFrame(capacity);
    #endregion

    #region Reflect
    public JObject ToReflectedMethod(ClassHandle clazz, MethodHandle method, bool isStatic = false) => new(this, Master->ToReflectedMethod(!clazz, !method, isStatic));
    public JObject ToReflectedField(ClassHandle clazz, FieldHandle field, bool isStatic = false) => new(this, Master->ToReflectedField(!clazz, !field, isStatic));
    public FieldHandle FromReflectedField(JObject field) => new(this, Master->FromReflectedField(!field));
    public MethodHandle FromReflectedMethod(JObject method) => new(this, Master->FromReflectedMethod(!method));
    #endregion

    #region Array
    public JArray NewObjectArray(int length, ClassHandle clazz, JObject initElement) => new(this, Master->NewObjectArray(length, (nint)clazz, (nint)initElement));
    #endregion

    #region Ref
    public nint NewGlobalRef(nint obj) => Master->NewGlobalRef(obj);
    public nint NewLocalRef(nint obj) => Master->NewLocalRef(obj);
    public void DeleteGlobalRef(nint link) => Master->DeleteGlobalRef(link);
    public void DeleteLocalRef(nint link) => Master->DeleteLocalRef(link);
    #endregion

    #region String
    public JString NewString(string unicode)
    {
        using var strCo = new CoMem(unicode, CoStrType.Uni);
        return new(this, Master->NewString((ushort*)strCo.Ptr, unicode.Length), true);
    }
    public JString NewStringUTF(string str)
    {
        using var strCo = new CoMem(str);
        return new(this, Master->NewStringUTF(strCo.Ptr), false);
    }
    public int GetStringLength(JObject str) => Master->GetStringLength(!str);
    public int GetStringUTFLength(JObject str) => Master->GetStringUTFLength(!str);
    public string GetStringUTFChars(JObject str) => new JString(this, str.Addr, false).ToString();
    public string GetString(JObject str) => new JString(this, str.Addr, true).ToString();
    public JString CreateString(string text, bool isUnicode = true) => isUnicode ? NewString(text) : NewStringUTF(text);
    public JString CreateString(nint addr, bool isUnicode = true) => new(this, addr, isUnicode);
    public JString CreateString(JObject obj, bool isUnicode = true) => new(this, (nint)obj, isUnicode);
    #endregion

    #region Sync
    public RetCode Lock(JObject obj) => Master->MonitorEnter(!obj);
    public RetCode Unlock(JObject obj) => Master->MonitorExit(!obj);
    #endregion

    #region Exception
    public void ExceptionClear() => Master->ExceptionClear();
    public bool ExceptionCheck() => Master->ExceptionCheck();
    public void ExceptionDescribe() => Master->ExceptionDescribe();
    public JObject ExceptionOccurred() => new(this, Master->ExceptionOccurred());
    public RetCode Throw(JObject obj) => Master->Throw(!obj);
    public RetCode ThrowNew(ClassHandle clazz, string msg)
    {
        using var msgCo = new CoMem(msg);
        return Master->ThrowNew(!clazz, msgCo.Ptr);
    }
    public void FatalError(string msg)
    {
        using var msgCo = new CoMem(msg);
        Master->FatalError(msgCo.Ptr);
    }
    #endregion

    #region Info
    public JVersion Version => Master->GetVersion();
    #endregion
}