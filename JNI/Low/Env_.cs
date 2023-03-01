using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.Low;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Env_
{
    private JNINativeInterface* functions;

    public int GetVersion()
    {
        fixed (Env_* env = &this)
        {
            return functions->GetVersion(env);
        }
    }

    public IntPtr DefineClass(byte* name, IntPtr loader, byte* buf, int len)
    {
        fixed (Env_* env = &this)
        {
            return functions->DefineClass(env, name, loader, buf, len);
        }
    }

    public IntPtr FindClass(byte* name)
    {
        fixed (Env_* env = &this)
        {
            return functions->FindClass(env, name);
        }
    }

    public IntPtr FromReflectedMethod(IntPtr method)
    {
        fixed (Env_* env = &this)
        {
            return functions->FromReflectedMethod(env, method);
        }
    }

    public IntPtr FromReflectedField(IntPtr field)
    {
        fixed (Env_* env = &this)
        {
            return functions->FromReflectedField(env, field);
        }
    }

    public IntPtr ToReflectedMethod(IntPtr cls, IntPtr methodID, bool isStatic)
    {
        fixed (Env_* env = &this)
        {
            return functions->ToReflectedMethod(env, cls, methodID, isStatic);
        }
    }

    public IntPtr GetSuperclass(IntPtr sub)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetSuperclass(env, sub);
        }
    }

    public bool IsAssignableFrom(IntPtr sub, IntPtr sup)
    {
        fixed (Env_* env = &this)
        {
            return functions->IsAssignableFrom(env, sub, sup);
        }
    }

    public IntPtr ToReflectedField(IntPtr cls, IntPtr fieldID, bool isStatic)
    {
        fixed (Env_* env = &this)
        {
            return functions->ToReflectedField(env, cls, fieldID, isStatic);
        }
    }

    public int Throw(IntPtr obj)
    {
        fixed (Env_* env = &this)
        {
            return functions->Throw(env, obj);
        }
    }

    public int ThrowNew(IntPtr clazz, byte* msg)
    {
        fixed (Env_* env = &this)
        {
            return functions->ThrowNew(env, clazz, msg);
        }
    }

    public IntPtr ExceptionOccurred()
    {
        fixed (Env_* env = &this)
        {
            return functions->ExceptionOccurred(env);
        }
    }

    public void ExceptionDescribe()
    {
        fixed (Env_* env = &this)
        {
            functions->ExceptionDescribe(env);
        }
    }

    public void ExceptionClear()
    {
        fixed (Env_* env = &this)
        {
            functions->ExceptionClear(env);
        }
    }

    public void FatalError(byte* msg)
    {
        fixed (Env_* env = &this)
        {
            functions->FatalError(env, msg);
        }
    }

    public int PushLocalFrame(int capacity)
    {
        fixed (Env_* env = &this)
        {
            return functions->PushLocalFrame(env, capacity);
        }
    }

    public IntPtr PopLocalFrame(IntPtr result)
    {
        fixed (Env_* env = &this)
        {
            return functions->PopLocalFrame(env, result);
        }
    }

    public IntPtr NewGlobalRef(IntPtr lobj)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewGlobalRef(env, lobj);
        }
    }

    public void DeleteGlobalRef(IntPtr gref)
    {
        fixed (Env_* env = &this)
        {
            functions->DeleteGlobalRef(env, gref);
        }
    }

    public void DeleteLocalRef(IntPtr obj)
    {
        fixed (Env_* env = &this)
        {
            functions->DeleteLocalRef(env, obj);
        }
    }

    public bool IsSameIntPtr(IntPtr obj1, IntPtr obj2)
    {
        fixed (Env_* env = &this)
        {
            return functions->IsSameIntPtr(env, obj1, obj2);
        }
    }

    public IntPtr NewLocalRef(IntPtr @ref)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewLocalRef(env, @ref);
        }
    }

    public int EnsureLocalCapacity(int capacity)
    {
        fixed (Env_* env = &this)
        {
            return functions->EnsureLocalCapacity(env, capacity);
        }
    }

    public IntPtr AllocIntPtr(IntPtr clazz)
    {
        fixed (Env_* env = &this)
        {
            return functions->AllocIntPtr(env, clazz);
        }
    }

    public IntPtr NewIntPtr(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            IntPtr result;
            result = functions->NewIntPtrV(env, clazz, methodID, args);
            return result;
        }
    }

    public IntPtr NewIntPtrV(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewIntPtrV(env, clazz, methodID, args);
        }
    }

    public IntPtr NewIntPtrA(IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewIntPtrA(env, clazz, methodID, args);
        }
    }

    public IntPtr GetIntPtrClass(IntPtr obj)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetIntPtrClass(env, obj);
        }
    }

    public bool IsInstanceOf(IntPtr obj, IntPtr clazz)
    {
        fixed (Env_* env = &this)
        {
            return functions->IsInstanceOf(env, obj, clazz);
        }
    }

    public IntPtr GetMethodID(IntPtr clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetMethodID(env, clazz, name, sig);
        }
    }

    public IntPtr CallIntPtrMethod(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            IntPtr result;
            result = functions->CallIntPtrMethodV(env, obj, methodID, args);
            return result;
        }
    }

    public IntPtr CallIntPtrMethodV(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallIntPtrMethodV(env, obj, methodID, args);
        }
    }

    public IntPtr CallIntPtrMethodA(IntPtr obj, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallIntPtrMethodA(env, obj, methodID, args);
        }
    }

    public bool CallBooleanMethod(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            bool result;
            result = functions->CallBooleanMethodV(env, obj, methodID, args);
            return result;
        }
    }

    public bool CallBooleanMethodV(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallBooleanMethodV(env, obj, methodID, args);
        }
    }

    public bool CallBooleanMethodA(IntPtr obj, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallBooleanMethodA(env, obj, methodID, args);
        }
    }

    public byte CallByteMethod(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            byte result;
            result = functions->CallByteMethodV(env, obj, methodID, args);
            return result;
        }
    }

    public byte CallByteMethodV(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallByteMethodV(env, obj, methodID, args);
        }
    }

    public byte CallByteMethodA(IntPtr obj, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallByteMethodA(env, obj, methodID, args);
        }
    }

    public ushort CallCharMethod(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            ushort result;
            result = functions->CallCharMethodV(env, obj, methodID, args);
            return result;
        }
    }

    public ushort CallCharMethodV(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallCharMethodV(env, obj, methodID, args);
        }
    }

    public ushort CallCharMethodA(IntPtr obj, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallCharMethodA(env, obj, methodID, args);
        }
    }

    public short CallShortMethod(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            short result;
            result = functions->CallShortMethodV(env, obj, methodID, args);
            return result;
        }
    }

    public short CallShortMethodV(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallShortMethodV(env, obj, methodID, args);
        }
    }

    public short CallShortMethodA(IntPtr obj, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallShortMethodA(env, obj, methodID, args);
        }
    }

    public int CallIntMethod(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            int result;
            result = functions->CallIntMethodV(env, obj, methodID, args);
            return result;
        }
    }

    public int CallIntMethodV(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallIntMethodV(env, obj, methodID, args);
        }
    }

    public int CallIntMethodA(IntPtr obj, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallIntMethodA(env, obj, methodID, args);
        }
    }

    public long CallLongMethod(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            long result;
            result = functions->CallLongMethodV(env, obj, methodID, args);
            return result;
        }
    }

    public long CallLongMethodV(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallLongMethodV(env, obj, methodID, args);
        }
    }

    public long CallLongMethodA(IntPtr obj, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallLongMethodA(env, obj, methodID, args);
        }
    }

    public float CallFloatMethod(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            float result;
            result = functions->CallFloatMethodV(env, obj, methodID, args);
            return result;
        }
    }

    public float CallFloatMethodV(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallFloatMethodV(env, obj, methodID, args);
        }
    }

    public float CallFloatMethodA(IntPtr obj, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallFloatMethodA(env, obj, methodID, args);
        }
    }

    public double CallDoubleMethod(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            double result;
            result = functions->CallDoubleMethodV(env, obj, methodID, args);
            return result;
        }
    }

    public double CallDoubleMethodV(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallDoubleMethodV(env, obj, methodID, args);
        }
    }

    public double CallDoubleMethodA(IntPtr obj, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallDoubleMethodA(env, obj, methodID, args);
        }
    }

    public void CallVoidMethod(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            functions->CallVoidMethodV(env, obj, methodID, args);
        }
    }

    public void CallVoidMethodV(IntPtr obj, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            functions->CallVoidMethodV(env, obj, methodID, args);
        }
    }

    public void CallVoidMethodA(IntPtr obj, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            functions->CallVoidMethodA(env, obj, methodID, args);
        }
    }

    public IntPtr CallNonvirtualIntPtrMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            IntPtr result;
            result = functions->CallNonvirtualIntPtrMethodV(env, obj, clazz, methodID, args);
            return result;
        }
    }

    public IntPtr CallNonvirtualIntPtrMethodV(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualIntPtrMethodV(env, obj, clazz, methodID, args);
        }
    }

    public IntPtr CallNonvirtualIntPtrMethodA(IntPtr obj, IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualIntPtrMethodA(env, obj, clazz, methodID, args);
        }
    }

    public bool CallNonvirtualBooleanMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            bool result;
            result = functions->CallNonvirtualBooleanMethodV(env, obj, clazz, methodID, args);
            return result;
        }
    }

    public bool CallNonvirtualBooleanMethodV(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualBooleanMethodV(env, obj, clazz, methodID, args);
        }
    }

    public bool CallNonvirtualBooleanMethodA(IntPtr obj, IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualBooleanMethodA(env, obj, clazz, methodID, args);
        }
    }

    public byte CallNonvirtualByteMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            byte result;
            result = functions->CallNonvirtualByteMethodV(env, obj, clazz, methodID, args);
            return result;
        }
    }

    public byte CallNonvirtualByteMethodV(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualByteMethodV(env, obj, clazz, methodID, args);
        }
    }

    public byte CallNonvirtualByteMethodA(IntPtr obj, IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualByteMethodA(env, obj, clazz, methodID, args);
        }
    }

    public ushort CallNonvirtualCharMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            ushort result;
            result = functions->CallNonvirtualCharMethodV(env, obj, clazz, methodID, args);
            return result;
        }
    }

    public ushort CallNonvirtualCharMethodV(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualCharMethodV(env, obj, clazz, methodID, args);
        }
    }

    public ushort CallNonvirtualCharMethodA(IntPtr obj, IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualCharMethodA(env, obj, clazz, methodID, args);
        }
    }

    public short CallNonvirtualShortMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            short result;
            result = functions->CallNonvirtualShortMethodV(env, obj, clazz, methodID, args);
            return result;
        }
    }

    public short CallNonvirtualShortMethodV(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualShortMethodV(env, obj, clazz, methodID, args);
        }
    }

    public short CallNonvirtualShortMethodA(IntPtr obj, IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualShortMethodA(env, obj, clazz, methodID, args);
        }
    }

    public int CallNonvirtualIntMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            int result;
            result = functions->CallNonvirtualIntMethodV(env, obj, clazz, methodID, args);
            return result;
        }
    }

    public int CallNonvirtualIntMethodV(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualIntMethodV(env, obj, clazz, methodID, args);
        }
    }

    public int CallNonvirtualIntMethodA(IntPtr obj, IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualIntMethodA(env, obj, clazz, methodID, args);
        }
    }

    public long CallNonvirtualLongMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            long result;
            result = functions->CallNonvirtualLongMethodV(env, obj, clazz, methodID, args);
            return result;
        }
    }

    public long CallNonvirtualLongMethodV(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualLongMethodV(env, obj, clazz, methodID, args);
        }
    }

    public long CallNonvirtualLongMethodA(IntPtr obj, IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualLongMethodA(env, obj, clazz, methodID, args);
        }
    }

    public float CallNonvirtualFloatMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            float result;
            result = functions->CallNonvirtualFloatMethodV(env, obj, clazz, methodID, args);
            return result;
        }
    }

    public float CallNonvirtualFloatMethodV(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualFloatMethodV(env, obj, clazz, methodID, args);
        }
    }

    public float CallNonvirtualFloatMethodA(IntPtr obj, IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualFloatMethodA(env, obj, clazz, methodID, args);
        }
    }

    public double CallNonvirtualDoubleMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            double result;
            result = functions->CallNonvirtualDoubleMethodV(env, obj, clazz, methodID, args);
            return result;
        }
    }

    public double CallNonvirtualDoubleMethodV(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualDoubleMethodV(env, obj, clazz, methodID, args);
        }
    }

    public double CallNonvirtualDoubleMethodA(IntPtr obj, IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallNonvirtualDoubleMethodA(env, obj, clazz, methodID, args);
        }
    }

    public void CallNonvirtualVoidMethod(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            functions->CallNonvirtualVoidMethodV(env, obj, clazz, methodID, args);
        }
    }

    public void CallNonvirtualVoidMethodV(IntPtr obj, IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            functions->CallNonvirtualVoidMethodV(env, obj, clazz, methodID, args);
        }
    }

    public void CallNonvirtualVoidMethodA(IntPtr obj, IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            functions->CallNonvirtualVoidMethodA(env, obj, clazz, methodID, args);
        }
    }

    public IntPtr GetFieldID(IntPtr clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetFieldID(env, clazz, name, sig);
        }
    }

    public IntPtr GetIntPtrField(IntPtr obj, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetIntPtrField(env, obj, fieldID);
        }
    }

    public bool GetBooleanField(IntPtr obj, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetBooleanField(env, obj, fieldID);
        }
    }

    public byte GetByteField(IntPtr obj, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetByteField(env, obj, fieldID);
        }
    }

    public ushort GetCharField(IntPtr obj, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetCharField(env, obj, fieldID);
        }
    }

    public short GetShortField(IntPtr obj, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetShortField(env, obj, fieldID);
        }
    }

    public int GetIntField(IntPtr obj, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetIntField(env, obj, fieldID);
        }
    }

    public long GetLongField(IntPtr obj, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetLongField(env, obj, fieldID);
        }
    }

    public float GetFloatField(IntPtr obj, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetFloatField(env, obj, fieldID);
        }
    }

    public double GetDoubleField(IntPtr obj, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetDoubleField(env, obj, fieldID);
        }
    }

    public void SetIntPtrField(IntPtr obj, IntPtr fieldID, IntPtr val)
    {
        fixed (Env_* env = &this)
        {
            functions->SetIntPtrField(env, obj, fieldID, val);
        }
    }

    public void SetBooleanField(IntPtr obj, IntPtr fieldID, bool val)
    {
        fixed (Env_* env = &this)
        {
            functions->SetBooleanField(env, obj, fieldID, val);
        }
    }

    public void SetByteField(IntPtr obj, IntPtr fieldID, byte val)
    {
        fixed (Env_* env = &this)
        {
            functions->SetByteField(env, obj, fieldID, val);
        }
    }

    public void SetCharField(IntPtr obj, IntPtr fieldID, ushort val)
    {
        fixed (Env_* env = &this)
        {
            functions->SetCharField(env, obj, fieldID, val);
        }
    }

    public void SetShortField(IntPtr obj, IntPtr fieldID, short val)
    {
        fixed (Env_* env = &this)
        {
            functions->SetShortField(env, obj, fieldID, val);
        }
    }

    public void SetIntField(IntPtr obj, IntPtr fieldID, int val)
    {
        fixed (Env_* env = &this)
        {
            functions->SetIntField(env, obj, fieldID, val);
        }
    }

    public void SetLongField(IntPtr obj, IntPtr fieldID, long val)
    {
        fixed (Env_* env = &this)
        {
            functions->SetLongField(env, obj, fieldID, val);
        }
    }

    public void SetFloatField(IntPtr obj, IntPtr fieldID, float val)
    {
        fixed (Env_* env = &this)
        {
            functions->SetFloatField(env, obj, fieldID, val);
        }
    }

    public void SetDoubleField(IntPtr obj, IntPtr fieldID, double val)
    {
        fixed (Env_* env = &this)
        {
            functions->SetDoubleField(env, obj, fieldID, val);
        }
    }

    public IntPtr GetStaticMethodID(IntPtr clazz, byte* name, byte* sig) //public IntPtr GetStaticMethodID(IntPtr clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStaticMethodID(env, clazz, name, sig);
        }
    }

    public IntPtr CallStaticIntPtrMethod(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            IntPtr result;
            result = functions->CallStaticIntPtrMethodV(env, clazz, methodID, args);
            return result;
        }
    }

    public IntPtr CallStaticIntPtrMethodV(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticIntPtrMethodV(env, clazz, methodID, args);
        }
    }

    public IntPtr CallStaticIntPtrMethodA(IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticIntPtrMethodA(env, clazz, methodID, args);
        }
    }

    public bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            bool result;
            result = functions->CallStaticBooleanMethodV(env, clazz, methodID, args);
            return result;
        }
    }

    public bool CallStaticBooleanMethodV(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticBooleanMethodV(env, clazz, methodID, args);
        }
    }

    public bool CallStaticBooleanMethodA(IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticBooleanMethodA(env, clazz, methodID, args);
        }
    }

    public byte CallStaticByteMethod(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            byte result;
            result = functions->CallStaticByteMethodV(env, clazz, methodID, args);
            return result;
        }
    }

    public byte CallStaticByteMethodV(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticByteMethodV(env, clazz, methodID, args);
        }
    }

    public byte CallStaticByteMethodA(IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticByteMethodA(env, clazz, methodID, args);
        }
    }

    public ushort CallStaticCharMethod(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            ushort result;
            result = functions->CallStaticCharMethodV(env, clazz, methodID, args);
            return result;
        }
    }

    public ushort CallStaticCharMethodV(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticCharMethodV(env, clazz, methodID, args);
        }
    }

    public ushort CallStaticCharMethodA(IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticCharMethodA(env, clazz, methodID, args);
        }
    }

    public short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            short result;
            result = functions->CallStaticShortMethodV(env, clazz, methodID, args);
            return result;
        }
    }

    public short CallStaticShortMethodV(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticShortMethodV(env, clazz, methodID, args);
        }
    }

    public short CallStaticShortMethodA(IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticShortMethodA(env, clazz, methodID, args);
        }
    }

    public int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            int result;
            result = functions->CallStaticIntMethodV(env, clazz, methodID, args);
            return result;
        }
    }

    public int CallStaticIntMethodV(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticIntMethodV(env, clazz, methodID, args);
        }
    }

    public int CallStaticIntMethodA(IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticIntMethodA(env, clazz, methodID, args);
        }
    }

    public long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            long result;
            result = functions->CallStaticLongMethodV(env, clazz, methodID, args);
            return result;
        }
    }

    public long CallStaticLongMethodV(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticLongMethodV(env, clazz, methodID, args);
        }
    }

    public long CallStaticLongMethodA(IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticLongMethodA(env, clazz, methodID, args);
        }
    }

    public float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            float result;
            result = functions->CallStaticFloatMethodV(env, clazz, methodID, args);
            return result;
        }
    }

    public float CallStaticFloatMethodV(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticFloatMethodV(env, clazz, methodID, args);
        }
    }

    public float CallStaticFloatMethodA(IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticFloatMethodA(env, clazz, methodID, args);
        }
    }

    public double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            double result;
            result = functions->CallStaticDoubleMethodV(env, clazz, methodID, args);
            return result;
        }
    }

    public double CallStaticDoubleMethodV(IntPtr clazz, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticDoubleMethodV(env, clazz, methodID, args);
        }
    }

    public double CallStaticDoubleMethodA(IntPtr clazz, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            return functions->CallStaticDoubleMethodA(env, clazz, methodID, args);
        }
    }

    public void CallStaticVoidMethod(IntPtr cls, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            functions->CallStaticVoidMethodV(env, cls, methodID, args);
        }
    }

    public void CallStaticVoidMethodV(IntPtr cls, IntPtr methodID, ArgIterator args)
    {
        fixed (Env_* env = &this)
        {
            functions->CallStaticVoidMethodV(env, cls, methodID, args);
        }
    }

    public void CallStaticVoidMethodA(IntPtr cls, IntPtr methodID, JValue* args)
    {
        fixed (Env_* env = &this)
        {
            functions->CallStaticVoidMethodA(env, cls, methodID, args);
        }
    }

    public IntPtr GetStaticFieldID(IntPtr clazz, byte* name, byte* sig)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStaticFieldID(env, clazz, name, sig);
        }
    }

    public IntPtr GetStaticIntPtrField(IntPtr clazz, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStaticIntPtrField(env, clazz, fieldID);
        }
    }

    public bool GetStaticBooleanField(IntPtr clazz, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStaticBooleanField(env, clazz, fieldID);
        }
    }

    public byte GetStaticByteField(IntPtr clazz, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStaticByteField(env, clazz, fieldID);
        }
    }

    public ushort GetStaticCharField(IntPtr clazz, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStaticCharField(env, clazz, fieldID);
        }
    }

    public short GetStaticShortField(IntPtr clazz, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStaticShortField(env, clazz, fieldID);
        }
    }

    public int GetStaticIntField(IntPtr clazz, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStaticIntField(env, clazz, fieldID);
        }
    }

    public long GetStaticLongField(IntPtr clazz, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStaticLongField(env, clazz, fieldID);
        }
    }

    public float GetStaticFloatField(IntPtr clazz, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStaticFloatField(env, clazz, fieldID);
        }
    }

    public double GetStaticDoubleField(IntPtr clazz, IntPtr fieldID)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStaticDoubleField(env, clazz, fieldID);
        }
    }

    public void SetStaticIntPtrField(IntPtr clazz, IntPtr fieldID, IntPtr value)
    {
        fixed (Env_* env = &this)
        {
            functions->SetStaticIntPtrField(env, clazz, fieldID, value);
        }
    }

    public void SetStaticBooleanField(IntPtr clazz, IntPtr fieldID, bool value)
    {
        fixed (Env_* env = &this)
        {
            functions->SetStaticBooleanField(env, clazz, fieldID, value);
        }
    }

    public void SetStaticByteField(IntPtr clazz, IntPtr fieldID, byte value)
    {
        fixed (Env_* env = &this)
        {
            functions->SetStaticByteField(env, clazz, fieldID, value);
        }
    }

    public void SetStaticCharField(IntPtr clazz, IntPtr fieldID, ushort value)
    {
        fixed (Env_* env = &this)
        {
            functions->SetStaticCharField(env, clazz, fieldID, value);
        }
    }

    public void SetStaticShortField(IntPtr clazz, IntPtr fieldID, short value)
    {
        fixed (Env_* env = &this)
        {
            functions->SetStaticShortField(env, clazz, fieldID, value);
        }
    }

    public void SetStaticIntField(IntPtr clazz, IntPtr fieldID, int value)
    {
        fixed (Env_* env = &this)
        {
            functions->SetStaticIntField(env, clazz, fieldID, value);
        }
    }

    public void SetStaticLongField(IntPtr clazz, IntPtr fieldID, long value)
    {
        fixed (Env_* env = &this)
        {
            functions->SetStaticLongField(env, clazz, fieldID, value);
        }
    }

    public void SetStaticFloatField(IntPtr clazz, IntPtr fieldID, float value)
    {
        fixed (Env_* env = &this)
        {
            functions->SetStaticFloatField(env, clazz, fieldID, value);
        }
    }

    public void SetStaticDoubleField(IntPtr clazz, IntPtr fieldID, double value)
    {
        fixed (Env_* env = &this)
        {
            functions->SetStaticDoubleField(env, clazz, fieldID, value);
        }
    }

    public IntPtr NewString(ushort* unicode, int len)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewString(env, unicode, len);
        }
    }

    public int GetStringLength(IntPtr str)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStringLength(env, str);
        }
    }

    public ushort* GetStringChars(IntPtr str, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            ushort* val = (ushort*)functions->GetStringChars(env, str, isCopy);
            return val;
        }
    }

    public void ReleaseStringChars(IntPtr str, ushort* chars)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleaseStringChars(env, str, chars);
        }
    }

    public IntPtr NewStringUTF(byte* utf)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewStringUTF(env, utf);
        }
    }

    public int GetStringUTFLength(IntPtr str)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStringUTFLength(env, str);
        }
    }

    public byte* GetStringUTFChars(IntPtr str, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStringUTFChars(env, str, isCopy);
        }
    }

    public void ReleaseStringUTFChars(IntPtr str, byte* chars)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleaseStringUTFChars(env, str, chars);
        }
    }

    public int GetArrayLength(IntPtr array)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetArrayLength(env, array);
        }
    }

    public IntPtr NewIntPtrArray(int len, IntPtr clazz, IntPtr init)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewIntPtrArray(env, len, clazz, init);
        }
    }

    public IntPtr GetIntPtrArrayElement(IntPtr array, int index)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetIntPtrArrayElement(env, array, index);
        }
    }

    public void SetIntPtrArrayElement(IntPtr array, int index, IntPtr val)
    {
        fixed (Env_* env = &this)
        {
            functions->SetIntPtrArrayElement(env, array, index, val);
        }
    }

    public IntPtr NewBooleanArray(int len)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewBooleanArray(env, len);
        }
    }

    public IntPtr NewByteArray(int len)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewByteArray(env, len);
        }
    }

    public IntPtr NewCharArray(int len)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewCharArray(env, len);
        }
    }

    public IntPtr NewShortArray(int len)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewShortArray(env, len);
        }
    }

    public IntPtr NewIntArray(int len)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewIntArray(env, len);
        }
    }

    public IntPtr NewLongArray(int len)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewLongArray(env, len);
        }
    }

    public IntPtr NewFloatArray(int len)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewFloatArray(env, len);
        }
    }

    public IntPtr NewDoubleArray(int len)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewDoubleArray(env, len);
        }
    }

    public bool* GetBooleanArrayElements(IntPtr array, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetBooleanArrayElements(env, array, isCopy);
        }
    }

    public byte* GetByteArrayElements(IntPtr array, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetByteArrayElements(env, array, isCopy);
        }
    }

    public ushort* GetCharArrayElements(IntPtr array, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetCharArrayElements(env, array, isCopy);
        }
    }

    public short* GetShortArrayElements(IntPtr array, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetShortArrayElements(env, array, isCopy);
        }
    }

    public int* GetIntArrayElements(IntPtr array, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetIntArrayElements(env, array, isCopy);
        }
    }

    public long* GetLongArrayElements(IntPtr array, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetLongArrayElements(env, array, isCopy);
        }
    }

    public float* GetFloatArrayElements(IntPtr array, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetFloatArrayElements(env, array, isCopy);
        }
    }

    public double* GetDoubleArrayElements(IntPtr array, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetDoubleArrayElements(env, array, isCopy);
        }
    }

    public void ReleaseBooleanArrayElements(IntPtr array, bool* elems, int mode)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleaseBooleanArrayElements(env, array, elems, mode);
        }
    }

    public void ReleaseByteArrayElements(IntPtr array, byte* elems, int mode)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleaseByteArrayElements(env, array, elems, mode);
        }
    }

    public void ReleaseCharArrayElements(IntPtr array, ushort* elems, int mode)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleaseCharArrayElements(env, array, elems, mode);
        }
    }

    public void ReleaseShortArrayElements(IntPtr array, short* elems, int mode)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleaseShortArrayElements(env, array, elems, mode);
        }
    }

    public void ReleaseIntArrayElements(IntPtr array, int* elems, int mode)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleaseIntArrayElements(env, array, elems, mode);
        }
    }

    public void ReleaseLongArrayElements(IntPtr array, long* elems, int mode)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleaseLongArrayElements(env, array, elems, mode);
        }
    }

    public void ReleaseFloatArrayElements(IntPtr array, float* elems, int mode)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleaseFloatArrayElements(env, array, elems, mode);
        }
    }

    public void ReleaseDoubleArrayElements(IntPtr array, double* elems, int mode)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleaseDoubleArrayElements(env, array, elems, mode);
        }
    }

    public void GetBooleanArrayRegion(IntPtr array, int start, int len, bool* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->GetBooleanArrayRegion(env, array, start, len, buf);
        }
    }

    public void GetByteArrayRegion(IntPtr array, int start, int len, byte* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->GetByteArrayRegion(env, array, start, len, buf);
        }
    }

    public void GetCharArrayRegion(IntPtr array, int start, int len, ushort* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->GetCharArrayRegion(env, array, start, len, buf);
        }
    }

    public void GetShortArrayRegion(IntPtr array, int start, int len, short* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->GetShortArrayRegion(env, array, start, len, buf);
        }
    }

    public void GetIntArrayRegion(IntPtr array, int start, int len, int* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->GetIntArrayRegion(env, array, start, len, buf);
        }
    }

    public void GetLongArrayRegion(IntPtr array, int start, int len, long* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->GetLongArrayRegion(env, array, start, len, buf);
        }
    }

    public void GetFloatArrayRegion(IntPtr array, int start, int len, float* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->GetFloatArrayRegion(env, array, start, len, buf);
        }
    }

    public void GetDoubleArrayRegion(IntPtr array, int start, int len, double* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->GetDoubleArrayRegion(env, array, start, len, buf);
        }
    }

    public void SetBooleanArrayRegion(IntPtr array, int start, int len, bool* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->SetBooleanArrayRegion(env, array, start, len, buf);
        }
    }

    public void SetByteArrayRegion(IntPtr array, int start, int len, byte* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->SetByteArrayRegion(env, array, start, len, buf);
        }
    }

    public void SetCharArrayRegion(IntPtr array, int start, int len, ushort* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->SetCharArrayRegion(env, array, start, len, buf);
        }
    }

    public void SetShortArrayRegion(IntPtr array, int start, int len, short* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->SetShortArrayRegion(env, array, start, len, buf);
        }
    }

    public void SetIntArrayRegion(IntPtr array, int start, int len, int* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->SetIntArrayRegion(env, array, start, len, buf);
        }
    }

    public void SetLongArrayRegion(IntPtr array, int start, int len, long* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->SetLongArrayRegion(env, array, start, len, buf);
        }
    }

    public void SetFloatArrayRegion(IntPtr array, int start, int len, float* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->SetFloatArrayRegion(env, array, start, len, buf);
        }
    }

    public void SetDoubleArrayRegion(IntPtr array, int start, int len, double* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->SetDoubleArrayRegion(env, array, start, len, buf);
        }
    }

    public int RegisterNatives(IntPtr clazz, JNINativeMethod* methods, int nMethods)
    {
        fixed (Env_* env = &this)
        {
            return functions->RegisterNatives(env, clazz, methods, nMethods);
        }
    }

    public int UnregisterNatives(IntPtr clazz)
    {
        fixed (Env_* env = &this)
        {
            return functions->UnregisterNatives(env, clazz);
        }
    }

    public int MonitorEnter(IntPtr obj)
    {
        fixed (Env_* env = &this)
        {
            return functions->MonitorEnter(env, obj);
        }
    }

    public int MonitorExit(IntPtr obj)
    {
        fixed (Env_* env = &this)
        {
            return functions->MonitorExit(env, obj);
        }
    }

    public int GetJavaVM(JVM_** vm)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetJavaVM(env, vm);
        }
    }

    public void GetStringRegion(IntPtr str, int start, int len, ushort* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->GetStringRegion(env, str, start, len, buf);
        }
    }

    public void GetStringUTFRegion(IntPtr str, int start, int len, byte* buf)
    {
        fixed (Env_* env = &this)
        {
            functions->GetStringUTFRegion(env, str, start, len, buf);
        }
    }

    public void* GetPrimitiveArrayCritical(IntPtr array, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetPrimitiveArrayCritical(env, array, isCopy);
        }
    }

    public void ReleasePrimitiveArrayCritical(IntPtr array, void* carray, int mode)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleasePrimitiveArrayCritical(env, array, carray, mode);
        }
    }

    public ushort* GetStringCritical(IntPtr @string, bool* isCopy)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetStringCritical(env, @string, isCopy);
        }
    }

    public void ReleaseStringCritical(IntPtr @string, ushort* cstring)
    {
        fixed (Env_* env = &this)
        {
            functions->ReleaseStringCritical(env, @string, cstring);
        }
    }

    public IntPtr NewWeakGlobalRef(IntPtr obj)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewWeakGlobalRef(env, obj);
        }
    }

    public void DeleteWeakGlobalRef(IntPtr @ref)
    {
        fixed (Env_* env = &this)
        {
            functions->DeleteWeakGlobalRef(env, @ref);
        }
    }

    public bool ExceptionCheck()
    {
        fixed (Env_* env = &this)
        {
            return functions->ExceptionCheck(env);
        }
    }

    public IntPtr NewDirectByteBuffer(void* address, long capacity)
    {
        fixed (Env_* env = &this)
        {
            return functions->NewDirectByteBuffer(env, address, capacity);
        }
    }

    public void* GetDirectBufferAddress(IntPtr buf)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetDirectBufferAddress(env, buf);
        }
    }

    public long GetDirectBufferCapacity(IntPtr buf)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetDirectBufferCapacity(env, buf);
        }
    }

    public JObjectRefType GetIntPtrRefType(IntPtr obj)
    {
        fixed (Env_* env = &this)
        {
            return functions->GetIntPtrRefType(env, obj);
        }
    }
}