using CSJNI;
using CSJNI.High.BaseTypes;
using CSJNI.High.Enums;
using CSJNI.High.Hierarchy;
using CSJNI.Low;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High;
public unsafe class Env
{
    public Env(Env_* env)
    {
        Master = env;
        Types = new RuntimeTypeCollection(this);
        Types.InitDefaultTypes();
    }

    public Env_* Master { get; init; }

    public RuntimeTypeCollection Types;

    public JNIVersion Version => (JNIVersion)Master->GetVersion();
    public JStaticField GetStaticFieldID(ClassHandle clazz, string name, JType retType) => new JStaticField(this, Master->GetStaticFieldID((IntPtr)clazz, name.AnsiPtr(), SigGen.Field(retType).AnsiPtr()), name, retType, clazz);
    public JObject CallNonvirtualObjectMethod(JObject obj, ClassHandle clazz, MethodHandle method, Params args) => new JObject(this, Master->CallNonvirtualObjectMethodA((IntPtr)obj, (IntPtr)clazz, (IntPtr)method, args.Ptr));
    public JField GetFieldID(ClassHandle clazz, string name, JType retType) => new JField(this, Master->GetFieldID((IntPtr)clazz, name.AnsiPtr(), SigGen.Field(retType).AnsiPtr()), name, retType);
    public ClassHandle DefineClass(string name, JObject loader, byte[] bytes) => new ClassHandle(this, Master->DefineClass(name.AnsiPtr(), (IntPtr)loader, bytes.Ptr(), bytes.Length));
    public JObject CallStaticObjectMethod(JObject obj, MethodHandle method, Params args) => new JObject(this, Master->CallStaticObjectMethodA((IntPtr)obj, (IntPtr)method, args.Ptr));
    public JObject ToReflectedMethod(ClassHandle clazz, MethodHandle method, bool isStatic) => new JObject(this, Master->ToReflectedMethod((IntPtr)clazz, (IntPtr)method, isStatic));
    public JObject ToReflectedField(ClassHandle clazz, FieldHandle field, bool isStatic) => new JObject(this, Master->ToReflectedField((IntPtr)clazz, (IntPtr)field, isStatic));
    public JObject NewObjectArray(int length, ClassHandle clazz, JObject initElement) => new JObject(this, Master->NewObjectArray(length, (IntPtr)clazz, (IntPtr)initElement));
    public JObject CallObjectMethod(JObject obj, MethodHandle method, Params args) => new JObject(this, Master->CallObjectMethodA((IntPtr)obj, (IntPtr)method, args.Ptr));
    public JObject NewObject(ClassHandle clazz, MethodHandle method, Params args) => new JObject(this, Master->NewObjectA((IntPtr)clazz, (IntPtr)method, args.Ptr));
    public JStaticMethod GetStaticMethodID(ClassHandle clazz, string name, JType retType, params Arg[] args) => new JStaticMethod(this, name, retType, clazz, args);
    public string GetStringCritical(JObject str) => Encoding.Unicode.GetString((byte*)Master->GetStringCritical((IntPtr)str, false.Ptr()), GetStringLength(str));
    public void SetStaticObjectField(JObject obj, FieldHandle field, JObject val) => Master->SetStaticObjectField((IntPtr)obj, (IntPtr)field, (IntPtr)val);
    public string GetStringUTFChars(JObject str) => Encoding.UTF8.GetString(Master->GetStringUTFChars((IntPtr)str, true.Ptr()), GetStringUTFLength(str));
    public string GetString(JObject str) => Encoding.Unicode.GetString((byte*)Master->GetStringChars((IntPtr)str, true.Ptr()), GetStringLength(str) * 2);
    public JObject GetStaticObjectField(ClassHandle clazz, FieldHandle field) => new JObject(this, Master->GetStaticObjectField((IntPtr)clazz, (IntPtr)field));
    public int RegisterNatives(ClassHandle clazz, JNINativeMethod[] methods) => Master->RegisterNatives((IntPtr)clazz, methods.Ptr(), methods.Length);
    public void ReleaseStringUTFChars(JObject str, string chars) => Master->ReleaseStringUTFChars((IntPtr)str, Encoding.UTF8.GetBytes(chars).Ptr());
    public void ReleasePrimitiveArrayCritical(JObject arr, void* carr, int mode) => Master->ReleasePrimitiveArrayCritical((IntPtr)arr, carr, mode);
    public void ReleaseStringCritical(JObject str, string chars) => Master->ReleaseStringCritical((IntPtr)str, (ushort*)chars.ToCharArray().Ptr());
    public JMethod GetMethodID(ClassHandle clazz, string name, JType retType, params Arg[] args) => new JMethod(this, name, retType, args, clazz);
    public JObject NewDirectByteBuffer(IntPtr addr, long capacity) => new JObject(this, Master->NewDirectByteBuffer(addr.ToPointer(), capacity));
    public void SetObjectField(JObject obj, FieldHandle field, JObject val) => Master->SetObjectField((IntPtr)obj, (IntPtr)field, (IntPtr)val);
    public void SetObjectArrayElement(JObject arr, int index, JObject val) => Master->SetObjectArrayElement((IntPtr)arr, index, (IntPtr)val);
    public void ReleaseStringChars(JObject str, string chars) => Master->ReleaseStringChars((IntPtr)str, (ushort*)chars.ToCharArray().Ptr());
    public JString NewString(string unicode) => new JString(this, Master->NewString((ushort*)unicode.UnicodePtr(), unicode.Length), true);
    public JObject GetObjectField(JObject obj, FieldHandle field) => new JObject(this, Master->GetObjectField((IntPtr)obj, (IntPtr)field));
    public JObject GetObjectArrayElement(JObject arr, int index) => new JObject(this, Master->GetObjectArrayElement((IntPtr)arr, index));
    public JObject NewStringObj(string unicode) => new JObject(this, Master->NewString((ushort*)unicode.UnicodePtr(), unicode.Length));
    public bool IsAssignableFrom(ClassHandle clazz1, ClassHandle clazz2) => Master->IsAssignableFrom((IntPtr)clazz1, (IntPtr)clazz2);
    public void* GetPrimitiveArrayCritical(JObject arr, bool isCopy) => Master->GetPrimitiveArrayCritical((IntPtr)arr, isCopy.Ptr());
    public JObject NewDirectByteBuffer(void* link, long capacity) => new JObject(this, Master->NewDirectByteBuffer(link, capacity));
    public MethodHandle FromReflectedMethod(JObject method) => new MethodHandle(this, Master->FromReflectedMethod((IntPtr)method));
    public FieldHandle FromReflectedField(JObject field) => new FieldHandle(this, Master->FromReflectedMethod((IntPtr)field));
    public ClassHandle GetClass(string name) => new ClassHandle(this, Master->FindClass(name.Replace('.', '/').AnsiPtr()));
    public ClassHandle GetSuperclass(ClassHandle clazz) => new ClassHandle(this, Master->GetSuperclass((IntPtr)clazz));
    public bool IsInstanceOf(JObject obj, ClassHandle clazz) => Master->IsInstanceOf((IntPtr)obj, (IntPtr)clazz);
    public JString NewStringUTF(string str) => new JString(this, Master->NewStringUTF(str.AnsiPtr()), false);
    public bool IsSameObject(JObject obj1, JObject obj2) => Master->IsSameObject((IntPtr)obj1, (IntPtr)obj2);
    public JObject PopLocalFrame(JObject result) => new JObject(this, Master->PopLocalFrame((IntPtr)result));
    public JObject NewWeakGlobalRef(JObject obj) => new JObject(this, Master->NewWeakGlobalRef((IntPtr)obj));
    public JObject AllocObject(ClassHandle clazz) => new JObject(this, Master->AllocObject((IntPtr)clazz));
    public int ThrowNew(ClassHandle clazz, string msg) => Master->ThrowNew((IntPtr)clazz, msg.AnsiPtr());
    public JObject NewStringUTFObj(string str) => new JObject(this, Master->NewStringUTF(str.AnsiPtr()));
    public JObject NewLocalRef(JObject refObj) => new JObject(this, Master->NewLocalRef((IntPtr)refObj));
    public ClassHandle GetObjectClass(JObject obj) => (ClassHandle)Master->GetObjectClass((IntPtr)obj);
    public void ReleaseStringUTFChars(JObject str) => Master->ReleaseStringUTFChars((IntPtr)str, null);
    public long GetDirectBufferCapacity(JObject buf) => Master->GetDirectBufferCapacity((IntPtr)buf);
    public JObject NewGlobalRef(JObject obj) => new JObject(this, Master->NewGlobalRef((IntPtr)obj));
    public void* GetDirectBufferAddress(JObject buf) => Master->GetDirectBufferAddress((IntPtr)buf);
    public void DeleteWeakGlobalRef(JObject refObj) => Master->DeleteWeakGlobalRef((IntPtr)refObj);
    public void ReleaseStringChars(JObject str) => Master->ReleaseStringChars((IntPtr)str, null);
    public JObjectRefType GetObjectRefType(JObject obj) => Master->GetObjectRefType((IntPtr)obj);
    public int UnregisterNatives(ClassHandle clazz) => Master->UnregisterNatives((IntPtr)clazz);
    public int GetStringUTFLength(JObject str) => Master->GetStringUTFLength((IntPtr)str);
    public int EnsureLocalCapacity(int capacity) => Master->EnsureLocalCapacity(capacity);
    public JObject ExceptionOccurred() => new JObject(this, Master->ExceptionOccurred());
    public void DeleteGlobalRef(JObject gref) => Master->DeleteGlobalRef((IntPtr)gref);
    public int GetStringLength(JObject str) => Master->GetStringLength((IntPtr)str);
    public void DeleteLocalRef(JObject obj) => Master->DeleteLocalRef((IntPtr)obj);
    public int GetArrayLength(JObject arr) => Master->GetArrayLength((IntPtr)arr);
    public int PushLocalFrame(int capacity) => Master->PushLocalFrame(capacity);
    public bool IsObjectNull(JObject obj) => Master->IsObjectNull((IntPtr)obj);
    public int MonitorEnter(JObject obj) => Master->MonitorEnter((IntPtr)obj);
    public void DeleteLocalRef(IntPtr link) => Master->DeleteLocalRef(link);
    public void FatalError(string msg) => Master->FatalError(msg.AnsiPtr());
    public int MonitorExit(JObject obj) => Master->MonitorExit((IntPtr)obj);
    public void ExceptionDescribe() => Master->ExceptionDescribe();
    public int Throw(JObject obj) => Master->Throw((IntPtr)obj);
    public void ExceptionClear() => Master->ExceptionClear();
    public bool ExceptionCheck() => Master->ExceptionCheck();

    public JString CreateString(string text, bool isUnicode = true) => new JString(this, text, isUnicode);
    public JString CreateString(IntPtr addr, bool isUnicode = true) => new JString(this, addr, isUnicode);
    public JString CreateString(JObject obj, bool isUnicode = true) => new JString(this, (IntPtr)obj, isUnicode);

    public JType GetType(string nameAndSign) => new JType(this, nameAndSign);
    public JType GetType(string name, string sign) => new JType(this, name, sign);
}

public class RuntimeTypeCollection
{
    public RuntimeTypeCollection(Env env)
    {
        this.env = env;
    }
    private Env env;

    public JBVoid Void;
    public JBBool Bool;
    public JBByte Byte;
    public JBShort Short;
    public JBInt Int;
    public JBLong Long;
    public JBFloat Float;
    public JBDouble Double;

    public JBString String;
    public JBObject Object;

    public JBClass Class;
    public JBClassLoader ClassLoader;

    internal void InitDefaultTypes()
    {
        Void = new JBVoid(env);
        Bool = new JBBool(env);
        Byte = new JBByte(env);
        Short = new JBShort(env);
        Int = new JBInt(env);
        Long = new JBLong(env);
        Float = new JBFloat(env);
        Double = new JBDouble(env);

        Object = new JBObject(env);
        String = new JBString(env);

        ClassLoader = new JBClassLoader(env);
        Class = new JBClass(env);
    }

    internal Dictionary<string, ClassHandle> rawTypes = new Dictionary<string, ClassHandle>();
    public ClassHandle this[string name]
    {
        get => rawTypes[name];
        set => rawTypes[name] = value;
    }
    public ClassHandle AddRaw(string name) => rawTypes[name] = env.GetClass(name);

    internal Dictionary<string, JClass> types = new Dictionary<string, JClass>();
    public JClass Get(string name) => types[name];
    public JClass Add(string name, JClass clazz) => types[name] = clazz;
    public JClass Add(string name) => types[name] = new JClass(env, name);
}