using JNI.Core;
using JNI.Core.Enums;
using JNI.Internal;
using JNI.Models;
using JNI.Models.Global;
using JNI.Models.Local;
using Memory;

namespace JNI;
public sealed unsafe class Env
{
    static Env()
    {
        fixed (bool* ptr = &trueValue)
            TruePtr = ptr;
        fixed (bool* ptr = &falseValue)
            FalsePtr = ptr;
    }

    public Env(Env_* env)
    {
        Native = env;

        if (!init)
        {
            StaticTypes = new RuntimeTypeCollection(this);
            init = true;
        }

        Types = StaticTypes;
    }

    private static bool init;

    private static bool trueValue = true, falseValue;
    public static bool* TruePtr, FalsePtr;

    public static RuntimeTypeCollection StaticTypes;
    public RuntimeTypeCollection Types;

    public Env_* Native;

    #region Type
    public ClassHandle GetClass(string name) => new(this, GetClassHandle(name));
    public nint GetClassHandle(string name)
    {
        using var nameCo = new CoMem(name.AsJavaPath());
        return Native->FindClass(nameCo.Ptr);
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
            return new(this, Native->DefineClass(nameCo.Ptr, !loader, ptr, bytes.Length));
    }
    #endregion

    #region Frame
    public JObject PopLocalFrame(JObject result) => new(this, Native->PopLocalFrame((nint)result));
    public int PushLocalFrame(int capacity) => Native->PushLocalFrame(capacity);
    #endregion

    #region Reflect
    public JObject ToReflectedMethod(ClassHandle clazz, MethodHandle method, bool isStatic = false) => new(this, Native->ToReflectedMethod(!clazz, !method, isStatic));
    public JObject ToReflectedField(ClassHandle clazz, FieldHandle field, bool isStatic = false) => new(this, Native->ToReflectedField(!clazz, !field, isStatic));
    public FieldHandle FromReflectedField(JObject field) => new(this, Native->FromReflectedField(!field));
    public MethodHandle FromReflectedMethod(JObject method) => new(this, Native->FromReflectedMethod(!method));
    #endregion

    #region Array
    public JArray NewObjectArray(int length, ClassHandle clazz, JObject initElement) => new(this, Native->NewObjectArray(length, (nint)clazz, (nint)initElement));
    #endregion

    #region Ref
    public nint NewGlobalRef(nint obj) => Native->NewGlobalRef(obj);
    public nint NewLocalRef(nint obj) => Native->NewLocalRef(obj);
    public void DeleteGlobalRef(nint link) => Native->DeleteGlobalRef(link);
    public void DeleteLocalRef(nint link) => Native->DeleteLocalRef(link);
    #endregion

    #region String
    public JString NewString(string unicode)
    {
        using var strCo = new CoMem(unicode, CoStrType.Uni);
        return new(this, Native->NewString((ushort*)strCo.Ptr, unicode.Length), true);
    }
    public JString NewStringUTF(string str)
    {
        using var strCo = new CoMem(str);
        return new(this, Native->NewStringUTF(strCo.Ptr), false);
    }
    public int GetStringLength(JObject str) => Native->GetStringLength(!str);
    public int GetStringUTFLength(JObject str) => Native->GetStringUTFLength(!str);
    public string GetStringUTFChars(JObject str) => new JString(this, str.Addr, false).ToString();
    public string GetString(JObject str) => new JString(this, str.Addr, true).ToString();
    public JString CreateString(string text, bool isUnicode = true) => isUnicode ? NewString(text) : NewStringUTF(text);
    public JString CreateString(nint addr, bool isUnicode = true) => new(this, addr, isUnicode);
    public JString CreateString(JObject obj, bool isUnicode = true) => new(this, (nint)obj, isUnicode);
    #endregion

    #region Sync
    public RetCode Lock(JObject obj) => Native->MonitorEnter(!obj);
    public RetCode Unlock(JObject obj) => Native->MonitorExit(!obj);
    #endregion

    #region Exception
    public void ExceptionClear() => Native->ExceptionClear();
    public bool ExceptionCheck() => Native->ExceptionCheck();
    public void ExceptionDescribe() => Native->ExceptionDescribe();
    public JObject ExceptionOccurred() => new(this, Native->ExceptionOccurred());
    public RetCode Throw(JObject obj) => Native->Throw(!obj);
    public RetCode ThrowNew(ClassHandle clazz, string msg)
    {
        using var msgCo = new CoMem(msg);
        return Native->ThrowNew(!clazz, msgCo.Ptr);
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
}