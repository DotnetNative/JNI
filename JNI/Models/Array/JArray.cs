using Memory;

namespace JNI;
public unsafe abstract class JArray : HandleContainer
{
    public JArray(EnvHandle handle) : base(handle) => Length = Env.Native->GetArrayLength(Addr);

    public readonly int Length;
}

public unsafe abstract class JStringArray(EnvHandle handle) : JArray(handle)
{
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

public unsafe class LJStringArray(LHandle handle) : JStringArray(handle)
{
    public LJStringArray(int length) : this(LHandle.Create(Env.ThreadNativeEnv->NewObjectArray(length, Env.StaticTypes.StringType, 0))) { }
}
public unsafe class GJStringArray(GHandle handle) : JStringArray(handle)
{
    public GJStringArray(int length, JType type) : this(GHandle.Create(Env.ThreadNativeEnv->NewObjectArray(length, Env.StaticTypes.StringType, 0))) { }
}

public unsafe abstract class JObjectArray(EnvHandle handle) : JArray(handle)
{
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

public unsafe class LJObjectArray(LHandle handle) : JObjectArray(handle)
{
    public LJObjectArray(int length, JType type) : this(LHandle.Create(type.Native->NewObjectArray(length, type, 0))) { }
}
public unsafe class GJObjectArray(GHandle handle) : JObjectArray(handle)
{
    public GJObjectArray(int length, JType type) : this(GHandle.Create(type.Native->NewObjectArray(length, type, 0))) { }
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

public unsafe abstract class JBoolArray(EnvHandle handle) : JPrimitiveArray<bool>(handle)
{
    public override bool* GetElements() => Native->GetBooleanArrayElements(Addr, false);
}

public unsafe class LJBoolArray(LHandle handle) : JBoolArray(handle)
{
    public LJBoolArray(int length) : this(LHandle.Create(Env.ThreadNativeEnv->NewBooleanArray(length))) { }
}

public unsafe class GJBoolArray(GHandle handle) : JBoolArray(handle)
{
    public GJBoolArray(int length) : this(GHandle.Create(Env.ThreadNativeEnv->NewBooleanArray(length))) { }
}

public unsafe abstract class JByteArray(EnvHandle handle) : JPrimitiveArray<byte>(handle)
{
    public override byte* GetElements() => Native->GetByteArrayElements(Addr, false);
}

public unsafe class LJByteArray(LHandle handle) : JByteArray(handle)
{
    public LJByteArray(int length) : this(LHandle.Create(Env.ThreadNativeEnv->NewByteArray(length))) { }
}

public unsafe class GJByteArray(GHandle handle) : JByteArray(handle)
{
    public GJByteArray(int length) : this(GHandle.Create(Env.ThreadNativeEnv->NewByteArray(length))) { }
}

public unsafe abstract class JCharArray(EnvHandle handle) : JPrimitiveArray<char>(handle)
{
    public override char* GetElements() => Native->GetCharArrayElements(Addr, false);
}

public unsafe class LJCharArray(LHandle handle) : JCharArray(handle)
{
    public LJCharArray(int length) : this(LHandle.Create(Env.ThreadNativeEnv->NewCharArray(length))) { }
}

public unsafe class GJCharArray(GHandle handle) : JCharArray(handle)
{
    public GJCharArray(int length) : this(GHandle.Create(Env.ThreadNativeEnv->NewCharArray(length))) { }
}

public unsafe abstract class JShortArray(EnvHandle handle) : JPrimitiveArray<short>(handle)
{
    public override short* GetElements() => Native->GetShortArrayElements(Addr, false);
}

public unsafe class LJShortArray(LHandle handle) : JShortArray(handle)
{
    public LJShortArray(int length) : this(LHandle.Create(Env.ThreadNativeEnv->NewShortArray(length))) { }
}

public unsafe class GJShortArray(GHandle handle) : JShortArray(handle)
{
    public GJShortArray(int length) : this(GHandle.Create(Env.ThreadNativeEnv->NewShortArray(length))) { }
}

public unsafe abstract class JIntArray(EnvHandle handle) : JPrimitiveArray<int>(handle)
{
    public override int* GetElements() => Native->GetIntArrayElements(Addr, false);
}

public unsafe class LJIntArray(LHandle handle) : JIntArray(handle)
{
    public LJIntArray(int length) : this(LHandle.Create(Env.ThreadNativeEnv->NewIntArray(length))) { }
}

public unsafe class GJIntArray(GHandle handle) : JIntArray(handle)
{
    public GJIntArray(int length) : this(GHandle.Create(Env.ThreadNativeEnv->NewIntArray(length))) { }
}

public unsafe abstract class JLongArray(EnvHandle handle) : JPrimitiveArray<long>(handle)
{
    public override long* GetElements() => Native->GetLongArrayElements(Addr, false);
}

public unsafe class LJLongArray(LHandle handle) : JLongArray(handle)
{
    public LJLongArray(int length) : this(LHandle.Create(Env.ThreadNativeEnv->NewLongArray(length))) { }
}

public unsafe class GJLongArray(GHandle handle) : JLongArray(handle)
{
    public GJLongArray(int length) : this(GHandle.Create(Env.ThreadNativeEnv->NewLongArray(length))) { }
}

public unsafe abstract class JFloatArray(EnvHandle handle) : JPrimitiveArray<float>(handle)
{
    public override float* GetElements() => Native->GetFloatArrayElements(Addr, false);
}

public unsafe class LJFloatArray(LHandle handle) : JFloatArray(handle)
{
    public LJFloatArray(int length) : this(LHandle.Create(Env.ThreadNativeEnv->NewFloatArray(length))) { }
}

public unsafe class GJFloatArray(GHandle handle) : JFloatArray(handle)
{
    public GJFloatArray(int length) : this(GHandle.Create(Env.ThreadNativeEnv->NewFloatArray(length))) { }
}

public unsafe abstract class JDoubleArray : JPrimitiveArray<double>
{
    public JDoubleArray(EnvHandle handle) : base(handle) { }

    public override double* GetElements() => Native->GetDoubleArrayElements(Addr, false);
}

public unsafe class LJDoubleArray(LHandle handle) : JDoubleArray(handle)
{
    public LJDoubleArray(int length) : this(LHandle.Create(Env.ThreadNativeEnv->NewDoubleArray(length))) { }
}

public unsafe class GJDoubleArray(GHandle handle) : JDoubleArray(handle)
{
    public GJDoubleArray(int length) : this(GHandle.Create(Env.ThreadNativeEnv->NewDoubleArray(length))) { }
}