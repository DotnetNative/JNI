﻿using Memory;

namespace JNI.Core;
public unsafe struct Env_
{
    public JNINativeInterface_* functions;

    public JVersion GetVersion()
    {
        fixed (Env_* env = &this)
            return functions->GetVersion(env);
    }

    public nint DefineClass(string name, nint loader, byte[] buf, int len)
    {
        using var coName = new CoMem(name);

        fixed (byte* ptr = buf)
        fixed (Env_* env = &this)
            return functions->DefineClass(env, (byte*)coName, loader, ptr, len);
    }

    public nint DefineClass(byte* name, nint loader, byte[] buf, int len)
    {
        fixed (byte* ptr = buf)
        fixed (Env_* env = &this)
            return functions->DefineClass(env, name, loader, ptr, len);
    }

    public nint DefineClass(string name, nint loader, byte* buf, int len)
    {
        using var coName = new CoMem(name);

        fixed (Env_* env = &this)
            return functions->DefineClass(env, (byte*)coName, loader, buf, len);
    }

    public nint DefineClass(byte* name, nint loader, byte* buf, int len)
    {
        fixed (Env_* env = &this)
            return functions->DefineClass(env, name, loader, buf, len);
    }

    public nint FindClass(string name)
    {
        using var coName = new CoMem(name);

        fixed (Env_* env = &this)
            return functions->FindClass(env, (byte*)coName);
    }

    public nint FindClass(byte* name)
    {
        fixed (Env_* env = &this)
            return functions->FindClass(env, name);
    }

    public nint FromReflectedMethod(nint method)
    {
        fixed (Env_* env = &this)
            return functions->FromReflectedMethod(env, method);
    }

    public nint FromReflectedField(nint field)
    {
        fixed (Env_* env = &this)
            return functions->FromReflectedField(env, field);
    }

    public nint ToReflectedMethod(nint cls, nint methodID, bool isStatic)
    {
        fixed (Env_* env = &this)
            return functions->ToReflectedMethod(env, cls, methodID, isStatic);
    }

    public nint GetSuperclass(nint sub)
    {
        fixed (Env_* env = &this)
            return functions->GetSuperclass(env, sub);
    }

    public bool IsAssignableFrom(nint sub, nint sup)
    {
        fixed (Env_* env = &this)
            return functions->IsAssignableFrom(env, sub, sup);
    }

    public nint ToReflectedField(nint cls, nint fieldID, bool isStatic)
    {
        fixed (Env_* env = &this)
            return functions->ToReflectedField(env, cls, fieldID, isStatic);
    }

    public RetCode Throw(nint obj)
    {
        fixed (Env_* env = &this)
            return functions->Throw(env, obj);
    }

    public RetCode ThrowNew(nint clazz, string msg)
    {
        using var coMsg = new CoMem(msg);

        fixed (Env_* env = &this)
            return functions->ThrowNew(env, clazz, (byte*)coMsg);
    }

    public RetCode ThrowNew(nint clazz, byte* msg)
    {
        fixed (Env_* env = &this)
            return functions->ThrowNew(env, clazz, msg);
    }

    public nint ExceptionOccurred()
    {
        fixed (Env_* env = &this)
            return functions->ExceptionOccurred(env);
    }

    public void ExceptionDescribe()
    {
        fixed (Env_* env = &this)
            functions->ExceptionDescribe(env);
    }

    public void ExceptionClear()
    {
        fixed (Env_* env = &this)
            functions->ExceptionClear(env);
    }

    public void FatalError(byte* msg)
    {
        fixed (Env_* env = &this)
            functions->FatalError(env, msg);
    }

    public int PushLocalFrame(int capacity)
    {
        fixed (Env_* env = &this)
            return functions->PushLocalFrame(env, capacity);
    }

    public nint PopLocalFrame(nint result)
    {
        fixed (Env_* env = &this)
            return functions->PopLocalFrame(env, result);
    }

    public nint NewGlobalRef(nint lobj)
    {
        fixed (Env_* env = &this)
            return functions->NewGlobalRef(env, lobj);
    }

    public void DeleteGlobalRef(nint gref)
    {
        fixed (Env_* env = &this)
            functions->DeleteGlobalRef(env, gref);
    }

    public void DeleteLocalRef(nint obj)
    {
        fixed (Env_* env = &this)
            functions->DeleteLocalRef(env, obj);
    }

    public bool IsSameObject(nint obj1, nint obj2)
    {
        fixed (Env_* env = &this)
            return functions->IsSameObject(env, obj1, obj2);
    }

    public nint NewLocalRef(nint @ref)
    {
        fixed (Env_* env = &this)
            return functions->NewLocalRef(env, @ref);
    }

    public int EnsureLocalCapacity(int capacity)
    {
        fixed (Env_* env = &this)
            return functions->EnsureLocalCapacity(env, capacity);
    }

    public nint AllocObject(nint clazz)
    {
        fixed (Env_* env = &this)
            return functions->AllocObject(env, clazz);
    }

    public nint NewObject(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->NewObjectA(env, clazz, methodID, args);
    }

    public nint GetObjectClass(nint obj)
    {
        fixed (Env_* env = &this)
            return functions->GetObjectClass(env, obj);
    }

    public bool IsInstanceOf(nint obj, nint clazz)
    {
        fixed (Env_* env = &this)
            return functions->IsInstanceOf(env, obj, clazz);
    }

    public nint GetMethodID(nint clazz, string name, string sig)
    {
        using var coName = new CoMem(name);
        using var coSig = new CoMem(name);
        fixed (Env_* env = &this)
            return functions->GetMethodID(env, clazz, (byte*)coName, (byte*)coSig);
    }

    public nint GetMethodID(nint clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
            return functions->GetMethodID(env, clazz, name, sig);
    }

    public nint CallObjectMethod(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallObjectMethodA(env, obj, methodID, args);
    }

    public bool CallBooleanMethod(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallBooleanMethodA(env, obj, methodID, args);
    }

    public byte CallByteMethod(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallByteMethodA(env, obj, methodID, args);
    }

    public char CallCharMethod(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallCharMethodA(env, obj, methodID, args);
    }

    public short CallShortMethod(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallShortMethodA(env, obj, methodID, args);
    }

    public int CallIntMethod(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallIntMethodA(env, obj, methodID, args);
    }

    public long CallLongMethod(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallLongMethodA(env, obj, methodID, args);
    }

    public float CallFloatMethod(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallFloatMethodA(env, obj, methodID, args);
    }

    public double CallDoubleMethod(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallDoubleMethodA(env, obj, methodID, args);
    }

    public void CallVoidMethod(nint obj, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            functions->CallVoidMethodA(env, obj, methodID, args);
    }

    public nint CallNonvirtualObjectMethod(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualObjectMethodA(env, obj, clazz, methodID, args);
    }

    public bool CallNonvirtualBooleanMethod(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualBooleanMethodA(env, obj, clazz, methodID, args);
    }

    public byte CallNonvirtualByteMethod(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualByteMethodA(env, obj, clazz, methodID, args);
    }

    public char CallNonvirtualCharMethod(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualCharMethodA(env, obj, clazz, methodID, args);
    }

    public short CallNonvirtualShortMethod(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualShortMethodA(env, obj, clazz, methodID, args);
    }

    public int CallNonvirtualIntMethod(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualIntMethodA(env, obj, clazz, methodID, args);
    }

    public long CallNonvirtualLongMethod(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualLongMethodA(env, obj, clazz, methodID, args);
    }
    public float CallNonvirtualFloatMethod(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualFloatMethodA(env, obj, clazz, methodID, args);
    }

    public double CallNonvirtualDoubleMethod(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallNonvirtualDoubleMethodA(env, obj, clazz, methodID, args);
    }

    public void CallNonvirtualVoidMethod(nint obj, nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            functions->CallNonvirtualVoidMethodA(env, obj, clazz, methodID, args);
    }

    public nint GetFieldID(nint clazz, string name, string sig)
    {
        using var nameCo = new CoMem(name);
        using var sigCo = new CoMem(sig);

        fixed (Env_* env = &this)
            return functions->GetFieldID(env, clazz, (byte*)nameCo, (byte*)sigCo);
    }

    public nint GetFieldID(nint clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
            return functions->GetFieldID(env, clazz, name, sig);
    }

    public nint GetObjectField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetObjectField(env, obj, fieldID);
    }

    public bool GetBooleanField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetBooleanField(env, obj, fieldID);
    }

    public byte GetByteField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetByteField(env, obj, fieldID);
    }

    public char GetCharField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetCharField(env, obj, fieldID);
    }

    public short GetShortField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetShortField(env, obj, fieldID);
    }

    public int GetIntField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetIntField(env, obj, fieldID);
    }

    public long GetLongField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetLongField(env, obj, fieldID);
    }

    public float GetFloatField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetFloatField(env, obj, fieldID);
    }

    public double GetDoubleField(nint obj, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetDoubleField(env, obj, fieldID);
    }

    public void SetObjectField(nint obj, nint fieldID, nint val)
    {
        fixed (Env_* env = &this)
            functions->SetObjectField(env, obj, fieldID, val);
    }

    public void SetBooleanField(nint obj, nint fieldID, bool val)
    {
        fixed (Env_* env = &this)
            functions->SetBooleanField(env, obj, fieldID, val);
    }

    public void SetByteField(nint obj, nint fieldID, byte val)
    {
        fixed (Env_* env = &this)
            functions->SetByteField(env, obj, fieldID, val);
    }

    public void SetCharField(nint obj, nint fieldID, char val)
    {
        fixed (Env_* env = &this)
            functions->SetCharField(env, obj, fieldID, val);
    }

    public void SetShortField(nint obj, nint fieldID, short val)
    {
        fixed (Env_* env = &this)
            functions->SetShortField(env, obj, fieldID, val);
    }

    public void SetIntField(nint obj, nint fieldID, int val)
    {
        fixed (Env_* env = &this)
            functions->SetIntField(env, obj, fieldID, val);
    }

    public void SetLongField(nint obj, nint fieldID, long val)
    {
        fixed (Env_* env = &this)
            functions->SetLongField(env, obj, fieldID, val);
    }

    public void SetFloatField(nint obj, nint fieldID, float val)
    {
        fixed (Env_* env = &this)
            functions->SetFloatField(env, obj, fieldID, val);
    }

    public void SetDoubleField(nint obj, nint fieldID, double val)
    {
        fixed (Env_* env = &this)
            functions->SetDoubleField(env, obj, fieldID, val);
    }

    public nint GetStaticMethodID(nint clazz, string name, string sig)
    {
        using var nameCo = new CoMem(name);
        using var sigCo = new CoMem(sig);

        fixed (Env_* env = &this)
            return functions->GetStaticMethodID(env, clazz, (byte*)nameCo, (byte*)sigCo);
    }

    public nint GetStaticMethodID(nint clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticMethodID(env, clazz, name, sig);
    }

    public nint CallStaticObjectMethod(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticObjectMethodA(env, clazz, methodID, args);
    }

    public bool CallStaticBooleanMethod(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticBooleanMethodA(env, clazz, methodID, args);
    }

    public byte CallStaticByteMethod(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticByteMethodA(env, clazz, methodID, args);
    }

    public char CallStaticCharMethod(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticCharMethodA(env, clazz, methodID, args);
    }

    public short CallStaticShortMethod(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticShortMethodA(env, clazz, methodID, args);
    }

    public int CallStaticIntMethod(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticIntMethodA(env, clazz, methodID, args);
    }

    public long CallStaticLongMethod(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticLongMethodA(env, clazz, methodID, args);
    }

    public float CallStaticFloatMethod(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticFloatMethodA(env, clazz, methodID, args);
    }

    public double CallStaticDoubleMethod(nint clazz, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            return functions->CallStaticDoubleMethodA(env, clazz, methodID, args);
    }

    public void CallStaticVoidMethod(nint cls, nint methodID, void* args)
    {
        fixed (Env_* env = &this)
            functions->CallStaticVoidMethodA(env, cls, methodID, args);
    }

    public nint GetStaticFieldID(nint clazz, string name, string sig)
    {
        using var nameCo = new CoMem(name);
        using var sigCo = new CoMem(sig);

        fixed (Env_* env = &this)
            return functions->GetStaticFieldID(env, clazz, (byte*)nameCo, (byte*)sigCo);
    }

    public nint GetStaticFieldID(nint clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticFieldID(env, clazz, name, sig);
    }

    public nint GetStaticObjectField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticObjectField(env, clazz, fieldID);
    }

    public bool GetStaticBooleanField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticBooleanField(env, clazz, fieldID);
    }

    public byte GetStaticByteField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticByteField(env, clazz, fieldID);
    }

    public char GetStaticCharField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticCharField(env, clazz, fieldID);
    }

    public short GetStaticShortField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticShortField(env, clazz, fieldID);
    }

    public int GetStaticIntField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticIntField(env, clazz, fieldID);
    }

    public long GetStaticLongField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticLongField(env, clazz, fieldID);
    }

    public float GetStaticFloatField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticFloatField(env, clazz, fieldID);
    }

    public double GetStaticDoubleField(nint clazz, nint fieldID)
    {
        fixed (Env_* env = &this)
            return functions->GetStaticDoubleField(env, clazz, fieldID);
    }

    public void SetStaticObjectField(nint clazz, nint fieldID, nint value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticObjectField(env, clazz, fieldID, value);
    }

    public void SetStaticBooleanField(nint clazz, nint fieldID, bool value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticBooleanField(env, clazz, fieldID, value);
    }

    public void SetStaticByteField(nint clazz, nint fieldID, byte value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticByteField(env, clazz, fieldID, value);
    }

    public void SetStaticCharField(nint clazz, nint fieldID, char value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticCharField(env, clazz, fieldID, value);
    }

    public void SetStaticShortField(nint clazz, nint fieldID, short value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticShortField(env, clazz, fieldID, value);
    }

    public void SetStaticIntField(nint clazz, nint fieldID, int value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticIntField(env, clazz, fieldID, value);
    }

    public void SetStaticLongField(nint clazz, nint fieldID, long value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticLongField(env, clazz, fieldID, value);
    }

    public void SetStaticFloatField(nint clazz, nint fieldID, float value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticFloatField(env, clazz, fieldID, value);
    }

    public void SetStaticDoubleField(nint clazz, nint fieldID, double value)
    {
        fixed (Env_* env = &this)
            functions->SetStaticDoubleField(env, clazz, fieldID, value);
    }

    public nint NewString(string unicode)
    {
        using var coUnicode = new CoMem(unicode, CoStrType.Uni);

        fixed (Env_* env = &this)
            return functions->NewString(env, (char*)coUnicode, unicode.Length);
    }

    public nint NewString(string unicode, int len)
    {
        using var coUnicode = new CoMem(unicode, CoStrType.Uni);

        fixed (Env_* env = &this)
            return functions->NewString(env, (char*)coUnicode, len);
    }

    public nint NewString(char* unicode, int len)
    {
        fixed (Env_* env = &this)
            return functions->NewString(env, unicode, len);
    }

    public int GetStringLength(nint str)
    {
        fixed (Env_* env = &this)
            return functions->GetStringLength(env, str);
    }

    public char* GetStringChars(nint str, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetStringChars(env, str, &isCopy);
    }

    public char* GetStringChars(nint str, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetStringChars(env, str, isCopy);
    }

    public void ReleaseStringChars(nint str, char* chars)
    {
        fixed (Env_* env = &this)
            functions->ReleaseStringChars(env, str, chars);
    }

    public nint NewStringUTF(string utf)
    {
        using var coUtf = new CoMem(utf);

        fixed (Env_* env = &this)
            return functions->NewStringUTF(env, (byte*)coUtf);
    }

    public nint NewStringUTF(byte* utf)
    {
        fixed (Env_* env = &this)
            return functions->NewStringUTF(env, utf);
    }

    public int GetStringUTFLength(nint str)
    {
        fixed (Env_* env = &this)
            return functions->GetStringUTFLength(env, str);
    }

    public byte* GetStringUTFChars(nint str, bool isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetStringUTFChars(env, str, &isCopy);
    }

    public byte* GetStringUTFChars(nint str, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetStringUTFChars(env, str, isCopy);
    }

    public void ReleaseStringUTFChars(nint str, byte* chars)
    {
        fixed (Env_* env = &this)
            functions->ReleaseStringUTFChars(env, str, chars);
    }

    public int GetArrayLength(nint array)
    {
        fixed (Env_* env = &this)
            return functions->GetArrayLength(env, array);
    }

    public nint NewObjectArray(int len, nint clazz, nint init)
    {
        fixed (Env_* env = &this)
            return functions->NewObjectArray(env, len, clazz, init);
    }

    public nint GetObjectArrayElement(nint array, int index)
    {
        fixed (Env_* env = &this)
            return functions->GetObjectArrayElement(env, array, index);
    }

    public void SetObjectArrayElement(nint array, int index, nint val)
    {
        fixed (Env_* env = &this)
            functions->SetObjectArrayElement(env, array, index, val);
    }

    public nint NewBooleanArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewBooleanArray(env, len);
    }

    public nint NewByteArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewByteArray(env, len);
    }

    public nint NewCharArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewCharArray(env, len);
    }

    public nint NewShortArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewShortArray(env, len);
    }

    public nint NewIntArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewIntArray(env, len);
    }

    public nint NewLongArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewLongArray(env, len);
    }

    public nint NewFloatArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewFloatArray(env, len);
    }

    public nint NewDoubleArray(int len)
    {
        fixed (Env_* env = &this)
            return functions->NewDoubleArray(env, len);
    }


    public bool* GetBooleanArrayElements(nint array, bool isCopy = false)
    {
        fixed (Env_* env = &this)
            return functions->GetBooleanArrayElements(env, array, &isCopy);
    }

    public byte* GetByteArrayElements(nint array, bool isCopy = false)
    {
        fixed (Env_* env = &this)
            return functions->GetByteArrayElements(env, array, &isCopy);
    }

    public char* GetCharArrayElements(nint array, bool isCopy = false)
    {
        fixed (Env_* env = &this)
            return functions->GetCharArrayElements(env, array, &isCopy);
    }

    public short* GetShortArrayElements(nint array, bool isCopy = false)
    {
        fixed (Env_* env = &this)
            return functions->GetShortArrayElements(env, array, &isCopy);
    }

    public int* GetIntArrayElements(nint array, bool isCopy = false)
    {
        fixed (Env_* env = &this)
            return functions->GetIntArrayElements(env, array, &isCopy);
    }

    public long* GetLongArrayElements(nint array, bool isCopy = false)
    {
        fixed (Env_* env = &this)
            return functions->GetLongArrayElements(env, array, &isCopy);
    }

    public float* GetFloatArrayElements(nint array, bool isCopy = false)
    {
        fixed (Env_* env = &this)
            return functions->GetFloatArrayElements(env, array, &isCopy);
    }

    public double* GetDoubleArrayElements(nint array, bool isCopy = false)
    {
        fixed (Env_* env = &this)
            return functions->GetDoubleArrayElements(env, array, &isCopy);
    }

    public bool* GetBooleanArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetBooleanArrayElements(env, array, isCopy);
    }

    public byte* GetByteArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetByteArrayElements(env, array, isCopy);
    }

    public char* GetCharArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetCharArrayElements(env, array, isCopy);
    }

    public short* GetShortArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetShortArrayElements(env, array, isCopy);
    }

    public int* GetIntArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetIntArrayElements(env, array, isCopy);
    }

    public long* GetLongArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetLongArrayElements(env, array, isCopy);
    }

    public float* GetFloatArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetFloatArrayElements(env, array, isCopy);
    }

    public double* GetDoubleArrayElements(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetDoubleArrayElements(env, array, isCopy);
    }

    public void ReleaseBooleanArrayElements(nint array, bool* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseBooleanArrayElements(env, array, elems, mode);
    }

    public void ReleaseByteArrayElements(nint array, byte* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseByteArrayElements(env, array, elems, mode);
    }

    public void ReleaseCharArrayElements(nint array, char* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseCharArrayElements(env, array, elems, mode);
    }

    public void ReleaseShortArrayElements(nint array, short* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseShortArrayElements(env, array, elems, mode);
    }

    public void ReleaseIntArrayElements(nint array, int* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseIntArrayElements(env, array, elems, mode);
    }

    public void ReleaseLongArrayElements(nint array, long* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseLongArrayElements(env, array, elems, mode);
    }

    public void ReleaseFloatArrayElements(nint array, float* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseFloatArrayElements(env, array, elems, mode);
    }

    public void ReleaseDoubleArrayElements(nint array, double* elems, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleaseDoubleArrayElements(env, array, elems, mode);
    }

    public void GetBooleanArrayRegion(nint array, int start, int len, bool* buf)
    {
        fixed (Env_* env = &this)
            functions->GetBooleanArrayRegion(env, array, start, len, buf);
    }

    public void GetByteArrayRegion(nint array, int start, int len, byte* buf)
    {
        fixed (Env_* env = &this)
            functions->GetByteArrayRegion(env, array, start, len, buf);
    }

    public void GetCharArrayRegion(nint array, int start, int len, char* buf)
    {
        fixed (Env_* env = &this)
            functions->GetCharArrayRegion(env, array, start, len, buf);
    }

    public void GetShortArrayRegion(nint array, int start, int len, short* buf)
    {
        fixed (Env_* env = &this)
            functions->GetShortArrayRegion(env, array, start, len, buf);
    }

    public void GetIntArrayRegion(nint array, int start, int len, int* buf)
    {
        fixed (Env_* env = &this)
            functions->GetIntArrayRegion(env, array, start, len, buf);
    }

    public void GetLongArrayRegion(nint array, int start, int len, long* buf)
    {
        fixed (Env_* env = &this)
            functions->GetLongArrayRegion(env, array, start, len, buf);
    }

    public void GetFloatArrayRegion(nint array, int start, int len, float* buf)
    {
        fixed (Env_* env = &this)
            functions->GetFloatArrayRegion(env, array, start, len, buf);
    }

    public void GetDoubleArrayRegion(nint array, int start, int len, double* buf)
    {
        fixed (Env_* env = &this)
            functions->GetDoubleArrayRegion(env, array, start, len, buf);
    }

    public void SetBooleanArrayRegion(nint array, int start, int len, bool* buf)
    {
        fixed (Env_* env = &this)
            functions->SetBooleanArrayRegion(env, array, start, len, buf);
    }

    public void SetByteArrayRegion(nint array, int start, int len, byte* buf)
    {
        fixed (Env_* env = &this)
            functions->SetByteArrayRegion(env, array, start, len, buf);
    }

    public void SetCharArrayRegion(nint array, int start, int len, char* buf)
    {
        fixed (Env_* env = &this)
            functions->SetCharArrayRegion(env, array, start, len, buf);
    }

    public void SetShortArrayRegion(nint array, int start, int len, short* buf)
    {
        fixed (Env_* env = &this)
            functions->SetShortArrayRegion(env, array, start, len, buf);
    }

    public void SetIntArrayRegion(nint array, int start, int len, int* buf)
    {
        fixed (Env_* env = &this)
            functions->SetIntArrayRegion(env, array, start, len, buf);
    }

    public void SetLongArrayRegion(nint array, int start, int len, long* buf)
    {
        fixed (Env_* env = &this)
            functions->SetLongArrayRegion(env, array, start, len, buf);
    }

    public void SetFloatArrayRegion(nint array, int start, int len, float* buf)
    {
        fixed (Env_* env = &this)
            functions->SetFloatArrayRegion(env, array, start, len, buf);
    }

    public void SetDoubleArrayRegion(nint array, int start, int len, double* buf)
    {
        fixed (Env_* env = &this)
            functions->SetDoubleArrayRegion(env, array, start, len, buf);
    }

    public RetCode RegisterNatives(nint clazz, NativeMethod_* methods, int nMethods)
    {
        fixed (Env_* env = &this)
            return functions->RegisterNatives(env, clazz, methods, nMethods);
    }

    public RetCode UnregisterNatives(nint clazz)
    {
        fixed (Env_* env = &this)
            return functions->UnregisterNatives(env, clazz);
    }

    public RetCode MonitorEnter(nint obj)
    {
        fixed (Env_* env = &this)
            return functions->MonitorEnter(env, obj);
    }

    public RetCode MonitorExit(nint obj)
    {
        fixed (Env_* env = &this)
            return functions->MonitorExit(env, obj);
    }

    public int GetJavaVM(JVM_** vm)
    {
        fixed (Env_* env = &this)
            return functions->GetJavaVM(env, vm);
    }

    public void GetStringRegion(nint str, int start, int len, char* buf)
    {
        fixed (Env_* env = &this)
            functions->GetStringRegion(env, str, start, len, buf);
    }

    public void GetStringUTFRegion(nint str, int start, int len, byte* buf)
    {
        fixed (Env_* env = &this)
            functions->GetStringUTFRegion(env, str, start, len, buf);
    }

    public void* GetPrimitiveArrayCritical(nint array, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetPrimitiveArrayCritical(env, array, isCopy);
    }

    public void ReleasePrimitiveArrayCritical(nint array, void* carray, int mode)
    {
        fixed (Env_* env = &this)
            functions->ReleasePrimitiveArrayCritical(env, array, carray, mode);
    }

    public char* GetStringCritical(nint @string, bool* isCopy)
    {
        fixed (Env_* env = &this)
            return functions->GetStringCritical(env, @string, isCopy);
    }

    public void ReleaseStringCritical(nint @string, char* cstring)
    {
        fixed (Env_* env = &this)
            functions->ReleaseStringCritical(env, @string, cstring);
    }

    public nint NewWeakGlobalRef(nint obj)
    {
        fixed (Env_* env = &this)
            return functions->NewWeakGlobalRef(env, obj);
    }

    public void DeleteWeakGlobalRef(nint @ref)
    {
        fixed (Env_* env = &this)
            functions->DeleteWeakGlobalRef(env, @ref);
    }

    public bool ExceptionCheck()
    {
        fixed (Env_* env = &this)
            return functions->ExceptionCheck(env);
    }

    public nint NewDirectByteBuffer(void* address, long capacity)
    {
        fixed (Env_* env = &this)
            return functions->NewDirectByteBuffer(env, address, capacity);
    }

    public void* GetDirectBufferAddress(nint buf)
    {
        fixed (Env_* env = &this)
            return functions->GetDirectBufferAddress(env, buf);
    }

    public long GetDirectBufferCapacity(nint buf)
    {
        fixed (Env_* env = &this)
            return functions->GetDirectBufferCapacity(env, buf);
    }

    public JObjRefType GetObjectRefType(nint obj)
    {   
        fixed (Env_* env = &this)
            return functions->GetObjectRefType(env, obj);
    }
}