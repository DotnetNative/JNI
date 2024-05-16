namespace JNI;
public unsafe abstract class JArray : HandleContainer
{
    public JArray(Handle handle) : base(handle) => Length = env_->GetArrayLength(Address);

    public readonly int Length;
}

public unsafe class JStringArray(Handle handle) : JArray(handle)
{
    public JString this[int index] { get => new(Get(index)); set => env_->SetObjectArrayElement(Address, index, value); }
    public JString Get(int index) => new(JObject.Create(env_->GetObjectArrayElement(Address, index)));

    public bool Contains(JString item) => IndexOf(item) != -1;

    public int IndexOf(JString item)
    {
        var e = env_;
        int length = Length;
        for (int i = 0; i < length; i++)
        {
            var obj = e->GetObjectArrayElement(Address, i);
            if (e->IsSameObject(obj, item))
                return i;
        }
        return -1;
    }
}

public unsafe class JObjectArray(Handle handle) : JArray(handle)
{
    public JObject this[int index] { get => Get(index); set => env_->SetObjectArrayElement(Address, index, value); }
    public JObject Get(int index) => JObject.Create(env_->GetObjectArrayElement(Address, index));

    public bool Contains(JObject item) => IndexOf(item) != -1;

    public int IndexOf(JObject item)
    {
        var e_ = env_;
        int length = Length;
        for (int i = 0; i < length; i++)
        {
            var obj = e_->GetObjectArrayElement(Address, i);
            if (e_->IsSameObject(obj, item))
                return i;
        }
        return -1;
    }

    public JObject[] ToArray()
    {
        var e_ = env_;
        var length = Length;
        var array = new JObject[length];
        for (int i = 0; i < length; i++)
            array[i] = JObject.Create(e_->GetObjectArrayElement(Address, i));
        return array;
    }
}

public unsafe abstract class JPrimitiveArray<T> : JArray where T : unmanaged
{
    public JPrimitiveArray(Handle handle) : base(handle) => Pointer = GetElements();

    public T* Pointer;
    public abstract T* GetElements();

    public T this[int index] { get => Pointer[index]; set => Pointer[index] = value; }

    public bool Contains(T item) => MemEx.Contains(Pointer, Length, item);

    public int IndexOf(T item) => MemEx.IndexOf(Pointer, Length, item);
}

public unsafe class JBoolArray(Handle handle) : JPrimitiveArray<bool>(handle) { public override bool* GetElements() => env_->GetBooleanArrayElements(Address, false); }
public unsafe class JByteArray(Handle handle) : JPrimitiveArray<byte>(handle) { public override byte* GetElements() => env_->GetByteArrayElements(Address, false); }
public unsafe class JCharArray(Handle handle) : JPrimitiveArray<char>(handle) { public override char* GetElements() => env_->GetCharArrayElements(Address, false); }
public unsafe class JShortArray(Handle handle) : JPrimitiveArray<short>(handle) { public override short* GetElements() => env_->GetShortArrayElements(Address, false); }
public unsafe class JIntArray(Handle handle) : JPrimitiveArray<int>(handle) { public override int* GetElements() => env_->GetIntArrayElements(Address, false); }
public unsafe class JLongArray(Handle handle) : JPrimitiveArray<long>(handle) { public override long* GetElements() => env_->GetLongArrayElements(Address, false); }
public unsafe class JFloatArray(Handle handle) : JPrimitiveArray<float>(handle) { public override float* GetElements() => env_->GetFloatArrayElements(Address, false); }
public unsafe class JDoubleArray(Handle handle) : JPrimitiveArray<double>(handle) { public override double* GetElements() => env_->GetDoubleArrayElements(Address, false); }