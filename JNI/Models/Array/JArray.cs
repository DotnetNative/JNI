using Memory;
using System.Collections;

namespace JNI;
public unsafe abstract class JArray : HandleContainer
{
    public JArray(EnvHandle handle) : base(handle) => Length = Env.Native->GetArrayLength(Addr);

    public readonly int Length;
}

public unsafe abstract class JStringArray : JArray
{
    public JStringArray(EnvHandle handle) : base(handle) { }

    public java.lang.String this[int index] { get => new(Get(index)); set => Native->SetObjectArrayElement(Addr, index, value); }
    public java.lang.String Get(int index) => new(LJObject.Create(Native->GetObjectArrayElement(Addr, index)));
    public java.lang.String GetG(int index) => new(GJObject.Create(Native->GetObjectArrayElement(Addr, index)));

    public bool Contains(java.lang.String item) => IndexOf(item) != -1;

    public int IndexOf(java.lang.String item)
    {
        int count = Length;
        for (int i = 0; i < count; i++)
        {
            using var obj = Get(i);
            if (obj == item)
                return i;
        }
        return -1;
    }
}

public unsafe class LJStringArray : JStringArray
{
    public LJStringArray(LHandle handle) : base(handle) { }
    public LJStringArray(int length) : base(LHandle.Create(Env.ThreadNativeEnv->NewObjectArray(length, Env.StaticTypes.StringType, 0))) { }
}
public unsafe class GJStringArray : JStringArray
{
    public GJStringArray(GHandle handle) : base(handle) { }
    public GJStringArray(int length, JType type) : base(GHandle.Create(Env.ThreadNativeEnv->NewObjectArray(length, Env.StaticTypes.StringType, 0))) { }
}

public unsafe abstract class JObjectArray : JArray
{
    public JObjectArray(EnvHandle handle) : base(handle) { }

    public LJObject this[int index] { get => Get(index); set => Native->SetObjectArrayElement(Addr, index, value); }
    public LJObject Get(int index) => LJObject.Create(Native->GetObjectArrayElement(Addr, index));
    public GJObject GetG(int index) => GJObject.Create(Native->GetObjectArrayElement(Addr, index));

    public bool Contains(JObject item) => IndexOf(item) != -1;

    public int IndexOf(JObject item)
    {
        int count = Length;
        for (int i = 0; i < count; i++)
        {
            using var obj = Get(i);
            if (obj == item)
                return i;
        }
        return -1;
    }
}

public unsafe class LJObjectArray : JObjectArray
{ 
    public LJObjectArray(LHandle handle) : base(handle) { }
    public LJObjectArray(int length, JType type) : base(LHandle.Create(type.Native->NewObjectArray(length, type, 0))) { }
}
public unsafe class GJObjectArray : JObjectArray 
{ 
    public GJObjectArray(GHandle handle) : base(handle) { }
    public GJObjectArray(int length, JType type) : base(GHandle.Create(type.Native->NewObjectArray(length, type, 0))) { }
}

public unsafe abstract class JPrimitiveArray<T> : JArray where T : unmanaged
{
    public JPrimitiveArray(EnvHandle handle) : base(handle) => Ptr = GetElements();

    public T* Ptr;
    public abstract T* GetElements();

    public T this[int index] { get => Ptr[index]; set => Ptr[index] = value; }

    public bool Contains(T item) => MemEx.Contains(Ptr, Length, item);

    public int IndexOf(T item) => MemEx.IndexOf(Ptr, Length, item);
}

public unsafe abstract class JBoolArray : JPrimitiveArray<bool>
{
    public JBoolArray(EnvHandle handle) : base(handle) { }

    public override unsafe bool* GetElements() => Native->GetBooleanArrayElements(Addr, false);
}

public unsafe class LJBoolArray : JBoolArray
{
    public LJBoolArray(LHandle handle) : base(handle) { }
    public LJBoolArray(int length) : base(LHandle.Create(Env.ThreadNativeEnv->NewBooleanArray(length))) { }
}

public unsafe class GJBoolArray : JBoolArray
{
    public GJBoolArray(GHandle handle) : base(handle) { }
    public GJBoolArray(int length) : base(GHandle.Create(Env.ThreadNativeEnv->NewBooleanArray(length))) { }
}

public unsafe abstract class JByteArray : JPrimitiveArray<byte>
{
    public JByteArray(EnvHandle handle) : base(handle) { }

    public override unsafe byte* GetElements() => Native->GetByteArrayElements(Addr, false);
}

public unsafe class LJByteArray : JByteArray
{
    public LJByteArray(LHandle handle) : base(handle) { }
    public LJByteArray(int length) : base(LHandle.Create(Env.ThreadNativeEnv->NewByteArray(length))) { }
}

public unsafe class GJByteArray : JByteArray
{
    public GJByteArray(GHandle handle) : base(handle) { }
    public GJByteArray(int length) : base(GHandle.Create(Env.ThreadNativeEnv->NewByteArray(length))) { }
}

public unsafe abstract class JCharArray : JPrimitiveArray<char>
{
    public JCharArray(EnvHandle handle) : base(handle) { }

    public override unsafe char* GetElements() => Native->GetCharArrayElements(Addr, false);
}

public unsafe class LJCharArray : JCharArray
{
    public LJCharArray(LHandle handle) : base(handle) { }
    public LJCharArray(int length) : base(LHandle.Create(Env.ThreadNativeEnv->NewCharArray(length))) { }
}

public unsafe class GJCharArray : JCharArray
{
    public GJCharArray(GHandle handle) : base(handle) { }
    public GJCharArray(int length) : base(GHandle.Create(Env.ThreadNativeEnv->NewCharArray(length))) { }
}

public unsafe abstract class JShortArray : JPrimitiveArray<short>
{
    public JShortArray(EnvHandle handle) : base(handle) { }

    public override unsafe short* GetElements() => Native->GetShortArrayElements(Addr, false);
}

public unsafe class LJShortArray : JShortArray
{
    public LJShortArray(LHandle handle) : base(handle) { }
    public LJShortArray(int length) : base(LHandle.Create(Env.ThreadNativeEnv->NewShortArray(length))) { }
}

public unsafe class GJShortArray : JShortArray
{
    public GJShortArray(GHandle handle) : base(handle) { }
    public GJShortArray(int length) : base(GHandle.Create(Env.ThreadNativeEnv->NewShortArray(length))) { }
}

public unsafe abstract class JIntArray : JPrimitiveArray<int>
{
    public JIntArray(EnvHandle handle) : base(handle) { }

    public override unsafe int* GetElements() => Native->GetIntArrayElements(Addr, false);
}

public unsafe class LJIntArray : JIntArray
{
    public LJIntArray(LHandle handle) : base(handle) { }
    public LJIntArray(int length) : base(LHandle.Create(Env.ThreadNativeEnv->NewIntArray(length))) { }
}

public unsafe class GJIntArray : JIntArray
{
    public GJIntArray(GHandle handle) : base(handle) { }
    public GJIntArray(int length) : base(GHandle.Create(Env.ThreadNativeEnv->NewIntArray(length))) { }
}

public unsafe abstract class JLongArray : JPrimitiveArray<long>
{
    public JLongArray(EnvHandle handle) : base(handle) { }

    public override unsafe long* GetElements() => Native->GetLongArrayElements(Addr, false);
}

public unsafe class LJLongArray : JLongArray
{
    public LJLongArray(LHandle handle) : base(handle) { }
    public LJLongArray(int length) : base(LHandle.Create(Env.ThreadNativeEnv->NewLongArray(length))) { }
}

public unsafe class GJLongArray : JLongArray
{
    public GJLongArray(GHandle handle) : base(handle) { }
    public GJLongArray(int length) : base(GHandle.Create(Env.ThreadNativeEnv->NewLongArray(length))) { }
}

public unsafe abstract class JFloatArray : JPrimitiveArray<float>
{
    public JFloatArray(EnvHandle handle) : base(handle) { }

    public override unsafe float* GetElements() => Native->GetFloatArrayElements(Addr, false);
}

public unsafe class LJFloatArray : JFloatArray
{
    public LJFloatArray(LHandle handle) : base(handle) { }
    public LJFloatArray(int length) : base(LHandle.Create(Env.ThreadNativeEnv->NewFloatArray(length))) { }
}

public unsafe class GJFloatArray : JFloatArray
{
    public GJFloatArray(GHandle handle) : base(handle) { }
    public GJFloatArray(int length) : base(GHandle.Create(Env.ThreadNativeEnv->NewFloatArray(length))) { }
}

public unsafe abstract class JDoubleArray : JPrimitiveArray<double>
{
    public JDoubleArray(EnvHandle handle) : base(handle) { }

    public override unsafe double* GetElements() => Native->GetDoubleArrayElements(Addr, false);
}

public unsafe class LJDoubleArray : JDoubleArray
{
    public LJDoubleArray(LHandle handle) : base(handle) { }
    public LJDoubleArray(int length) : base(LHandle.Create(Env.ThreadNativeEnv->NewDoubleArray(length))) { }
}

public unsafe class GJDoubleArray : JDoubleArray
{
    public GJDoubleArray(GHandle handle) : base(handle) { }
    public GJDoubleArray(int length) : base(GHandle.Create(Env.ThreadNativeEnv->NewDoubleArray(length))) { }
}