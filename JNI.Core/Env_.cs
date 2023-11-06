using Memory;
using System.Runtime.InteropServices;

namespace JNI.Core;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Env_
{
    public JNINativeInterface_* functions;

    [MethImpl(AggressiveInlining)]
    public JVersion GetVersion()
    {
        fixed (Env_* env = &this)
            return functions->GetVersion(env);
    }

    [MethImpl(AggressiveInlining)]
    public nint DefineClass(string name, nint loader, byte* buf, int len)
    {
        using var coName = new CoMem(name);

        fixed (Env_* env = &this)
            return functions->DefineClass(env, (byte*)coName, loader, buf, len);
    }

    [MethImpl(AggressiveInlining)]
    public nint DefineClass(byte* name, nint loader, byte* buf, int len)
    {
        fixed (Env_* env = &this)
            return functions->DefineClass(env, name, loader, buf, len);
    }

    [MethImpl(AggressiveInlining)]
    public nint FindClass(string name)
    {
        using var coName = new CoMem(name);

        fixed (Env_* env = &this)
            return functions->FindClass(env, (byte*)coName);
    }

    [MethImpl(AggressiveInlining)]
    public nint FindClass(byte* name)
    {
        fixed (Env_* env = &this)
            return functions->FindClass(env, name);
    }

    [MethImpl(AggressiveInlining)]
    public nint FromReflectedMethod(nint method)
    {
        fixed (Env_* env = &this)
            return functions->FromReflectedMethod(env, method);
    }

    [MethImpl(AggressiveInlining)]
    public nint FromReflectedField(nint field)
    {
        fixed (Env_* env = &this)
            return functions->FromReflectedField(env, field);
    }

    [MethImpl(AggressiveInlining)]
    public nint ToReflectedMethod(nint cls, nint methodID, bool isStatic)
    {
        fixed (Env_* env = &this)
            return functions->ToReflectedMethod(env, cls, methodID, isStatic);
    }

    [MethImpl(AggressiveInlining)]
    public nint GetSuperclass(nint sub)
    {
        fixed (Env_* env = &this)
            return functions->GetSuperclass(env, sub);
    }

    [MethImpl(AggressiveInlining)]
    public bool IsAssignableFrom(nint sub, nint sup)
    {
        fixed (Env_* env = &this)
            return functions->IsAssignableFrom(env, sub, sup);
    }

    [MethImpl(AggressiveInlining)]
    public nint ToReflectedField(nint cls, nint fieldID, bool isStatic)
    {
        fixed (Env_* env = &this)
            return functions->ToReflectedField(env, cls, fieldID, isStatic);
    }

    [MethImpl(AggressiveInlining)]
    public RetCode Throw(nint obj)
    {
        fixed (Env_* env = &this)
            return functions->Throw(env, obj);
    }

    [MethImpl(AggressiveInlining)]
    public RetCode ThrowNew(nint clazz, string msg)
    {
        using var coMsg = new CoMem(msg);

        fixed (Env_* env = &this)
            return functions->ThrowNew(env, clazz, (byte*)coMsg);
    }

    [MethImpl(AggressiveInlining)]
    public RetCode ThrowNew(nint clazz, byte* msg)
    {
        fixed (Env_* env = &this)
            return functions->ThrowNew(env, clazz, msg);
    }

    [MethImpl(AggressiveInlining)]
    public nint ExceptionOccurred()
    {
        fixed (Env_* env = &this)
            return functions->ExceptionOccurred(env);
    }

    [MethImpl(AggressiveInlining)]
    public void ExceptionDescribe()
    {
        fixed (Env_* env = &this)
            functions->ExceptionDescribe(env);
    }

    [MethImpl(AggressiveInlining)]
    public void ExceptionClear()
    {
        fixed (Env_* env = &this)
            functions->ExceptionClear(env);
    }

    [MethImpl(AggressiveInlining)]
    public void FatalError(byte* msg)
    {
        fixed (Env_* env = &this)
            functions->FatalError(env, msg);
    }

    [MethImpl(AggressiveInlining)]
    public int PushLocalFrame(int capacity)
    {
        fixed (Env_* env = &this)
            return functions->PushLocalFrame(env, capacity);
    }

    [MethImpl(AggressiveInlining)]
    public nint PopLocalFrame(nint result)
    {
        fixed (Env_* env = &this)
            return functions->PopLocalFrame(env, result);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewGlobalRef(nint lobj)
    {
        fixed (Env_* env = &this)
            return functions->NewGlobalRef(env, lobj);
    }

    [MethImpl(AggressiveInlining)]
    public void DeleteGlobalRef(nint gref)
    {
        fixed (Env_* env = &this)
            functions->DeleteGlobalRef(env, gref);
    }

    [MethImpl(AggressiveInlining)]
    public void DeleteLocalRef(nint obj)
    {
        fixed (Env_* env = &this)
            functions->DeleteLocalRef(env, obj);
    }

    [MethImpl(AggressiveInlining)]
    public bool IsSameObject(nint obj1, nint obj2)
    {
        fixed (Env_* env = &this)
            return functions->IsSameObject(env, obj1, obj2);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewLocalRef(nint @ref)
    {
        fixed (Env_* env = &this)
            return functions->NewLocalRef(env, @ref);
    }

    [MethImpl(AggressiveInlining)]
    public int EnsureLocalCapacity(int capacity)
    {
        fixed (Env_* env = &this)
            return functions->EnsureLocalCapacity(env, capacity);
    }

    [MethImpl(AggressiveInlining)]
    public nint AllocObject(nint clazz)
    {
        fixed (Env_* env = &this)
            return functions->AllocObject(env, clazz);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewObject(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->NewObjectV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewObjectV(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->NewObjectV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewObjectA(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->NewObjectA(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint GetObjectClass(nint obj)
    {
        fixed (Env_* env = &this)
            return functions->GetObjectClass(env, obj);
    }

    [MethImpl(AggressiveInlining)]
    public bool IsInstanceOf(nint obj, nint clazz)
    {
        fixed (Env_* env = &this)
            return functions->IsInstanceOf(env, obj, clazz);
    }

    [MethImpl(AggressiveInlining)]
    public nint GetMethodID(nint clazz, string name, string sig)
    {
        using var coName = new CoMem(name);
        using var coSig = new CoMem(name);

        fixed (Env_* env = &this)
            return functions->GetMethodID(env, clazz, (byte*)coName, (byte*)coSig);
    }

    [MethImpl(AggressiveInlining)]
    public nint GetMethodID(nint clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
            return functions->GetMethodID(env, clazz, name, sig);
    }

    [MethImpl(AggressiveInlining)]
    public nint CallObjectMethod(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallObjectMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint CallObjectMethodV(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallObjectMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint CallObjectMethodA(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallObjectMethodA(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public bool CallBooleanMethod(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallBooleanMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public bool CallBooleanMethodV(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallBooleanMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public bool CallBooleanMethodA(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallBooleanMethodA(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public byte CallByteMethod(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallByteMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public byte CallByteMethodV(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallByteMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public byte CallByteMethodA(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallByteMethodA(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public char CallCharMethod(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallCharMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public char CallCharMethodV(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallCharMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public char CallCharMethodA(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallCharMethodA(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public short CallShortMethod(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallShortMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public short CallShortMethodV(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallShortMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public short CallShortMethodA(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallShortMethodA(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public int CallIntMethod(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallIntMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public int CallIntMethodV(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallIntMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public int CallIntMethodA(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallIntMethodA(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public long CallLongMethod(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallLongMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public long CallLongMethodV(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallLongMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public long CallLongMethodA(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallLongMethodA(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public float CallFloatMethod(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallFloatMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public float CallFloatMethodV(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallFloatMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public float CallFloatMethodA(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallFloatMethodA(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public double CallDoubleMethod(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallDoubleMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public double CallDoubleMethodV(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallDoubleMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public double CallDoubleMethodA(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallDoubleMethodA(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public void CallVoidMethod(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            functions->CallVoidMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public void CallVoidMethodV(nint obj, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            functions->CallVoidMethodV(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public void CallVoidMethodA(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            functions->CallVoidMethodA(env, obj, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint CallNonvirtualObjectMethod(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualObjectMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint CallNonvirtualObjectMethodV(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualObjectMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint CallNonvirtualObjectMethodA(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualObjectMethodA(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public bool CallNonvirtualBooleanMethod(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualBooleanMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public bool CallNonvirtualBooleanMethodV(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualBooleanMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public bool CallNonvirtualBooleanMethodA(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualBooleanMethodA(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public byte CallNonvirtualByteMethod(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualByteMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public byte CallNonvirtualByteMethodV(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualByteMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public byte CallNonvirtualByteMethodA(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualByteMethodA(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public char CallNonvirtualCharMethod(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualCharMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public char CallNonvirtualCharMethodV(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualCharMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public char CallNonvirtualCharMethodA(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualCharMethodA(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public short CallNonvirtualShortMethod(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualShortMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public short CallNonvirtualShortMethodV(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualShortMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public short CallNonvirtualShortMethodA(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualShortMethodA(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public int CallNonvirtualIntMethod(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualIntMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public int CallNonvirtualIntMethodV(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualIntMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public int CallNonvirtualIntMethodA(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualIntMethodA(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public long CallNonvirtualLongMethod(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualLongMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public long CallNonvirtualLongMethodV(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualLongMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public long CallNonvirtualLongMethodA(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualLongMethodA(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public float CallNonvirtualFloatMethod(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualFloatMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public float CallNonvirtualFloatMethodV(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualFloatMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public float CallNonvirtualFloatMethodA(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualFloatMethodA(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public double CallNonvirtualDoubleMethod(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualDoubleMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public double CallNonvirtualDoubleMethodV(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualDoubleMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public double CallNonvirtualDoubleMethodA(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualDoubleMethodA(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public void CallNonvirtualVoidMethod(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            functions->CallNonvirtualVoidMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public void CallNonvirtualVoidMethodV(nint obj, nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            functions->CallNonvirtualVoidMethodV(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public void CallNonvirtualVoidMethodA(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            functions->CallNonvirtualVoidMethodA(env, obj, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint GetFieldID(nint clazz, string name, string sig)
    {
        using var nameCo = new CoMem(name);
        using var sigCo = new CoMem(sig);

        fixed (Env_* env = &this)
            return functions->GetFieldID(env, clazz, (byte*)nameCo, (byte*)sigCo);
    }

    [MethImpl(AggressiveInlining)]
    public nint GetFieldID(nint clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
            return functions->GetFieldID(env, clazz, name, sig);
    }

    [MethImpl(AggressiveInlining)]
    public nint GetObjectField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetObjectField(env, obj, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public bool GetBooleanField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetBooleanField(env, obj, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public byte GetByteField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetByteField(env, obj, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public char GetCharField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetCharField(env, obj, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public short GetShortField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetShortField(env, obj, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public int GetIntField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetIntField(env, obj, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public long GetLongField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetLongField(env, obj, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public float GetFloatField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetFloatField(env, obj, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public double GetDoubleField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetDoubleField(env, obj, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public void SetObjectField(nint obj, nint fieldID, nint val)
    {
        fixed (Env_* env = &this)
            functions->SetObjectField(env, obj, fieldID, val);
    }

    [MethImpl(AggressiveInlining)]
    public void SetBooleanField(nint obj, nint fieldID, bool val)
    {
        fixed (Env_* env = &this)
            functions->SetBooleanField(env, obj, fieldID, val);
    }

    [MethImpl(AggressiveInlining)]
    public void SetByteField(nint obj, nint fieldID, byte val)
    {
        fixed (Env_* env = &this)
            functions->SetByteField(env, obj, fieldID, val);
    }

    [MethImpl(AggressiveInlining)]
    public void SetCharField(nint obj, nint fieldID, char val)
    {
        fixed (Env_* env = &this)
            functions->SetCharField(env, obj, fieldID, val);
    }

    [MethImpl(AggressiveInlining)]
    public void SetShortField(nint obj, nint fieldID, short val)
    {
        fixed (Env_* env = &this)
            functions->SetShortField(env, obj, fieldID, val);
    }

    [MethImpl(AggressiveInlining)]
    public void SetIntField(nint obj, nint fieldID, int val)
    {
        fixed (Env_* env = &this)
            functions->SetIntField(env, obj, fieldID, val);
    }

    [MethImpl(AggressiveInlining)]
    public void SetLongField(nint obj, nint fieldID, long val)
    {
        fixed (Env_* env = &this)
            functions->SetLongField(env, obj, fieldID, val);
    }

    [MethImpl(AggressiveInlining)]
    public void SetFloatField(nint obj, nint fieldID, float val)
    {
        fixed (Env_* env = &this)
            functions->SetFloatField(env, obj, fieldID, val);
    }

    [MethImpl(AggressiveInlining)]
    public void SetDoubleField(nint obj, nint fieldID, double val)
    {
        fixed (Env_* env = &this)
            functions->SetDoubleField(env, obj, fieldID, val);
    }

    [MethImpl(AggressiveInlining)]
    public nint GetStaticMethodID(nint clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticMethodID(env, clazz, name, sig);
    }

    [MethImpl(AggressiveInlining)]
    public nint CallStaticObjectMethod(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticObjectMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint CallStaticObjectMethodV(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticObjectMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint CallStaticObjectMethodA(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticObjectMethodA(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public bool CallStaticBooleanMethod(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticBooleanMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public bool CallStaticBooleanMethodV(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticBooleanMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public bool CallStaticBooleanMethodA(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticBooleanMethodA(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public byte CallStaticByteMethod(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticByteMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public byte CallStaticByteMethodV(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticByteMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public byte CallStaticByteMethodA(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticByteMethodA(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public char CallStaticCharMethod(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticCharMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public char CallStaticCharMethodV(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticCharMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public char CallStaticCharMethodA(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticCharMethodA(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public short CallStaticShortMethod(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticShortMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public short CallStaticShortMethodV(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticShortMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public short CallStaticShortMethodA(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticShortMethodA(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public int CallStaticIntMethod(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticIntMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public int CallStaticIntMethodV(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticIntMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public int CallStaticIntMethodA(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticIntMethodA(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public long CallStaticLongMethod(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticLongMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public long CallStaticLongMethodV(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticLongMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public long CallStaticLongMethodA(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticLongMethodA(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public float CallStaticFloatMethod(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticFloatMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public float CallStaticFloatMethodV(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticFloatMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public float CallStaticFloatMethodA(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticFloatMethodA(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public double CallStaticDoubleMethod(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticDoubleMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public double CallStaticDoubleMethodV(nint clazz, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticDoubleMethodV(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public double CallStaticDoubleMethodA(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticDoubleMethodA(env, clazz, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public void CallStaticVoidMethod(nint cls, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            functions->CallStaticVoidMethodV(env, cls, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public void CallStaticVoidMethodV(nint cls, nint methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
            functions->CallStaticVoidMethodV(env, cls, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public void CallStaticVoidMethodA(nint cls, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            functions->CallStaticVoidMethodA(env, cls, methodID, args);
    }

    [MethImpl(AggressiveInlining)]
    public nint GetStaticFieldID(nint clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticFieldID(env, clazz, name, sig);
    }

    [MethImpl(AggressiveInlining)]
    public nint GetStaticObjectField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticObjectField(env, clazz, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public bool GetStaticBooleanField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticBooleanField(env, clazz, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public byte GetStaticByteField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticByteField(env, clazz, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public char GetStaticCharField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticCharField(env, clazz, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public short GetStaticShortField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticShortField(env, clazz, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public int GetStaticIntField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticIntField(env, clazz, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public long GetStaticLongField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticLongField(env, clazz, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public float GetStaticFloatField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticFloatField(env, clazz, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public double GetStaticDoubleField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticDoubleField(env, clazz, fieldID);
    }

    [MethImpl(AggressiveInlining)]
    public void SetStaticObjectField(nint clazz, nint fieldID, nint value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticObjectField(env, clazz, fieldID, value);
    }

    [MethImpl(AggressiveInlining)]
    public void SetStaticBooleanField(nint clazz, nint fieldID, bool value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticBooleanField(env, clazz, fieldID, value);
    }

    [MethImpl(AggressiveInlining)]
    public void SetStaticByteField(nint clazz, nint fieldID, byte value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticByteField(env, clazz, fieldID, value);
    }

    [MethImpl(AggressiveInlining)]
    public void SetStaticCharField(nint clazz, nint fieldID, char value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticCharField(env, clazz, fieldID, value);
    }

    [MethImpl(AggressiveInlining)]
    public void SetStaticShortField(nint clazz, nint fieldID, short value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticShortField(env, clazz, fieldID, value);
    }

    [MethImpl(AggressiveInlining)]
    public void SetStaticIntField(nint clazz, nint fieldID, int value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticIntField(env, clazz, fieldID, value);
    }

    [MethImpl(AggressiveInlining)]
    public void SetStaticLongField(nint clazz, nint fieldID, long value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticLongField(env, clazz, fieldID, value);
    }

    [MethImpl(AggressiveInlining)]
    public void SetStaticFloatField(nint clazz, nint fieldID, float value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticFloatField(env, clazz, fieldID, value);
    }

    [MethImpl(AggressiveInlining)]
    public void SetStaticDoubleField(nint clazz, nint fieldID, double value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticDoubleField(env, clazz, fieldID, value);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewString(string unicode, int len)
    {
        using var coUnicode = new CoMem(unicode, CoStrType.Uni);

        fixed (Env_* env = &this)
            return functions->NewString(env, (char*)coUnicode, len);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewString(char* unicode, int len)
    {
        fixed (Env_* env = &this)
            return functions->NewString(env, unicode, len);
    }

    [MethImpl(AggressiveInlining)]
    public int GetStringLength(nint str)
    {
        fixed (Env_* env = &this)
            return functions->GetStringLength(env, str);
    }

    [MethImpl(AggressiveInlining)]
    public char* GetStringChars(nint str, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetStringChars(env, str, &isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public char* GetStringChars(nint str, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetStringChars(env, str, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleaseStringChars(nint str, char* chars)
    {
        fixed (Env_* env = &this)
            functions->ReleaseStringChars(env, str, chars);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewStringUTF(string utf)
    {
        using var coUtf = new CoMem(utf);

        fixed (Env_* env = &this)
            return functions->NewStringUTF(env, (byte*)coUtf);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewStringUTF(byte* utf)
    {
        fixed (Env_* env = &this)
            return functions->NewStringUTF(env, utf);
    }

    [MethImpl(AggressiveInlining)]
    public int GetStringUTFLength(nint str)
    {
        fixed (Env_* env = &this)
            return functions->GetStringUTFLength(env, str);
    }

    [MethImpl(AggressiveInlining)]
    public byte* GetStringUTFChars(nint str, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetStringUTFChars(env, str, &isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public byte* GetStringUTFChars(nint str, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetStringUTFChars(env, str, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleaseStringUTFChars(nint str, byte* chars)
    {
        fixed (Env_* env = &this)
            functions->ReleaseStringUTFChars(env, str, chars);
    }

    [MethImpl(AggressiveInlining)]
    public int GetArrayLength(nint array)
    {
        fixed (Env_* env = &this)
            return functions->GetArrayLength(env, array);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewObjectArray(int len, nint clazz, nint init)
    {
        fixed (Env_* env = &this)
            return functions->NewObjectArray(env, len, clazz, init);
    }

    [MethImpl(AggressiveInlining)]
    public nint GetObjectArrayElement(nint array, int index)
    {
        fixed (Env_* env = &this)
            return functions->GetObjectArrayElement(env, array, index);
    }

    [MethImpl(AggressiveInlining)]
    public void SetObjectArrayElement(nint array, int index, nint val)
    {
        fixed (Env_* env = &this)
            functions->SetObjectArrayElement(env, array, index, val);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewBooleanArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewBooleanArray(env, len);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewByteArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewByteArray(env, len);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewCharArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewCharArray(env, len);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewShortArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewShortArray(env, len);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewIntArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewIntArray(env, len);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewLongArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewLongArray(env, len);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewFloatArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewFloatArray(env, len);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewDoubleArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewDoubleArray(env, len);
    }


    [MethImpl(AggressiveInlining)]
    public bool* GetBooleanArrayElements(nint array, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetBooleanArrayElements(env, array, &isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public byte* GetByteArrayElements(nint array, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetByteArrayElements(env, array, &isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public char* GetCharArrayElements(nint array, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetCharArrayElements(env, array, &isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public short* GetShortArrayElements(nint array, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetShortArrayElements(env, array, &isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public int* GetIntArrayElements(nint array, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetIntArrayElements(env, array, &isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public long* GetLongArrayElements(nint array, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetLongArrayElements(env, array, &isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public float* GetFloatArrayElements(nint array, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetFloatArrayElements(env, array, &isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public double* GetDoubleArrayElements(nint array, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetDoubleArrayElements(env, array, &isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public bool* GetBooleanArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetBooleanArrayElements(env, array, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public byte* GetByteArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetByteArrayElements(env, array, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public char* GetCharArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetCharArrayElements(env, array, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public short* GetShortArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetShortArrayElements(env, array, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public int* GetIntArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetIntArrayElements(env, array, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public long* GetLongArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetLongArrayElements(env, array, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public float* GetFloatArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetFloatArrayElements(env, array, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public double* GetDoubleArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetDoubleArrayElements(env, array, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleaseBooleanArrayElements(nint array, bool* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseBooleanArrayElements(env, array, elems, mode);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleaseByteArrayElements(nint array, byte* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseByteArrayElements(env, array, elems, mode);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleaseCharArrayElements(nint array, char* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseCharArrayElements(env, array, elems, mode);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleaseShortArrayElements(nint array, short* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseShortArrayElements(env, array, elems, mode);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleaseIntArrayElements(nint array, int* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseIntArrayElements(env, array, elems, mode);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleaseLongArrayElements(nint array, long* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseLongArrayElements(env, array, elems, mode);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleaseFloatArrayElements(nint array, float* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseFloatArrayElements(env, array, elems, mode);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleaseDoubleArrayElements(nint array, double* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseDoubleArrayElements(env, array, elems, mode);
    }

    [MethImpl(AggressiveInlining)]
    public void GetBooleanArrayRegion(nint array, int start, int len, bool* buf)
    {
        fixed (Env_* env = &this)
            functions->GetBooleanArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void GetByteArrayRegion(nint array, int start, int len, byte* buf)
    {
        fixed (Env_* env = &this)
            functions->GetByteArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void GetCharArrayRegion(nint array, int start, int len, char* buf)
    {
        fixed (Env_* env = &this)
            functions->GetCharArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void GetShortArrayRegion(nint array, int start, int len, short* buf)
    {
        fixed (Env_* env = &this)
            functions->GetShortArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void GetIntArrayRegion(nint array, int start, int len, int* buf)
    {
        fixed (Env_* env = &this)
            functions->GetIntArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void GetLongArrayRegion(nint array, int start, int len, long* buf)
    {
        fixed (Env_* env = &this)
            functions->GetLongArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void GetFloatArrayRegion(nint array, int start, int len, float* buf)
    {
        fixed (Env_* env = &this)
            functions->GetFloatArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void GetDoubleArrayRegion(nint array, int start, int len, double* buf)
    {
        fixed (Env_* env = &this)
            functions->GetDoubleArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void SetBooleanArrayRegion(nint array, int start, int len, bool* buf)
    {
        fixed (Env_* env = &this)
            functions->SetBooleanArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void SetByteArrayRegion(nint array, int start, int len, byte* buf)
    {
        fixed (Env_* env = &this)
            functions->SetByteArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void SetCharArrayRegion(nint array, int start, int len, char* buf)
    {
        fixed (Env_* env = &this)
            functions->SetCharArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void SetShortArrayRegion(nint array, int start, int len, short* buf)
    {
        fixed (Env_* env = &this)
            functions->SetShortArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void SetIntArrayRegion(nint array, int start, int len, int* buf)
    {
        fixed (Env_* env = &this)
            functions->SetIntArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void SetLongArrayRegion(nint array, int start, int len, long* buf)
    {
        fixed (Env_* env = &this)
            functions->SetLongArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void SetFloatArrayRegion(nint array, int start, int len, float* buf)
    {
        fixed (Env_* env = &this)
            functions->SetFloatArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void SetDoubleArrayRegion(nint array, int start, int len, double* buf)
    {
        fixed (Env_* env = &this)
            functions->SetDoubleArrayRegion(env, array, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public RetCode RegisterNatives(nint clazz, NativeMethod_* methods, int nMethods)
    {
        fixed (Env_* env = &this)
            return functions->RegisterNatives(env, clazz, methods, nMethods);
    }

    [MethImpl(AggressiveInlining)]
    public RetCode UnregisterNatives(nint clazz)
    {
        fixed (Env_* env = &this)
            return functions->UnregisterNatives(env, clazz);
    }

    [MethImpl(AggressiveInlining)]
    public RetCode MonitorEnter(nint obj)
    {
        fixed (Env_* env = &this)
            return functions->MonitorEnter(env, obj);
    }

    [MethImpl(AggressiveInlining)]
    public RetCode MonitorExit(nint obj)
    {
        fixed (Env_* env = &this)
            return functions->MonitorExit(env, obj);
    }

    [MethImpl(AggressiveInlining)]
    public int GetJavaVM(JVM_** vm)
    {
        fixed (Env_* env = &this)
            return functions->GetJavaVM(env, vm);
    }

    [MethImpl(AggressiveInlining)]
    public void GetStringRegion(nint str, int start, int len, char* buf)
    {
        fixed (Env_* env = &this)
            functions->GetStringRegion(env, str, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void GetStringUTFRegion(nint str, int start, int len, byte* buf)
    {
        fixed (Env_* env = &this)
            functions->GetStringUTFRegion(env, str, start, len, buf);
    }

    [MethImpl(AggressiveInlining)]
    public void* GetPrimitiveArrayCritical(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetPrimitiveArrayCritical(env, array, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleasePrimitiveArrayCritical(nint array, void* carray, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleasePrimitiveArrayCritical(env, array, carray, mode);
    }

    [MethImpl(AggressiveInlining)]
    public char* GetStringCritical(nint @string, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetStringCritical(env, @string, isCopy);
    }

    [MethImpl(AggressiveInlining)]
    public void ReleaseStringCritical(nint @string, char* cstring)
    {
        fixed (Env_* env = &this)
            functions->ReleaseStringCritical(env, @string, cstring);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewWeakGlobalRef(nint obj)
    {
        fixed (Env_* env = &this)
            return functions->NewWeakGlobalRef(env, obj);
    }

    [MethImpl(AggressiveInlining)]
    public void DeleteWeakGlobalRef(nint @ref)
    {
        fixed (Env_* env = &this)
            functions->DeleteWeakGlobalRef(env, @ref);
    }

    [MethImpl(AggressiveInlining)]
    public bool ExceptionCheck()
    {
        fixed (Env_* env = &this)
            return functions->ExceptionCheck(env);
    }

    [MethImpl(AggressiveInlining)]
    public nint NewDirectByteBuffer(void* address, long capacity)
    {
        fixed (Env_* env = &this)
            return functions->NewDirectByteBuffer(env, address, capacity);
    }

    [MethImpl(AggressiveInlining)]
    public void* GetDirectBufferAddress(nint buf)
    {
        fixed (Env_* env = &this)
            return functions->GetDirectBufferAddress(env, buf);
    }

    [MethImpl(AggressiveInlining)]
    public long GetDirectBufferCapacity(nint buf)
    {
        fixed (Env_* env = &this)
            return functions->GetDirectBufferCapacity(env, buf);
    }

    [MethImpl(AggressiveInlining)]
    public JObjRefType GetObjectRefType(nint obj)
    {
        fixed (Env_* env = &this)
            return functions->GetObjectRefType(env, obj);
    }
}