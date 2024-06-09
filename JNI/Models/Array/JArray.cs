namespace JNI;
public unsafe abstract class JArray : JObject
{
    public JArray(Handle handle) : base(handle) => Length = env_->GetArrayLength(Address);

    public readonly int Length;
}

public unsafe abstract class JObjectArray<T>(Handle handle) : JArray(handle) where T : Handle
{
    public T this[int index] { get => Get(index); set => env_->SetObjectArrayElement(Address, index, value); }
    public T Get(int index) => FromHandle(HandleImpl.Create(env_->GetObjectArrayElement(Address, index)));

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

    public T[] ToArray()
    {
        var e_ = env_;
        var length = Length;
        var array = new T[length];
        for (int i = 0; i < length; i++)
            array[i] = FromHandle(HandleImpl.Create(e_->GetObjectArrayElement(Address, i)));
        return array;
    }

    protected abstract T FromHandle(Handle handle);
}

public class JStringArray(Handle handle) : JObjectArray<JString>(handle) { protected override JString FromHandle(Handle handle) => new(handle); }
public class JStringArray2D(Handle handle) : JObjectArray<JStringArray>(handle) { protected override JStringArray FromHandle(Handle handle) => new(handle); }
public class JStringArray3D(Handle handle) : JObjectArray<JStringArray2D>(handle) { protected override JStringArray2D FromHandle(Handle handle) => new(handle); }
public class JStringArray4D(Handle handle) : JObjectArray<JStringArray3D>(handle) { protected override JStringArray3D FromHandle(Handle handle) => new(handle); }

public class JObjectArray(Handle handle) : JObjectArray<JObject>(handle) { protected override JObject FromHandle(Handle handle) => JObjectImpl.Create(handle); }
public class JObjectArray2D(Handle handle) : JObjectArray<JObjectArray>(handle) { protected override JObjectArray FromHandle(Handle handle) => new(handle); }
public class JObjectArray3D(Handle handle) : JObjectArray<JObjectArray2D>(handle) { protected override JObjectArray2D FromHandle(Handle handle) => new(handle); }
public class JObjectArray4D(Handle handle) : JObjectArray<JObjectArray3D>(handle) { protected override JObjectArray3D FromHandle(Handle handle) => new(handle); }

public unsafe abstract class JPrimitiveArray<T> : JArray where T : unmanaged
{
    public JPrimitiveArray(Handle handle) : base(handle) => Pointer = GetElements();

    public T* Pointer;
    public abstract T* GetElements(bool isCopy = false);

    public T this[int index] { get => Pointer[index]; set => Pointer[index] = value; }

    public bool Contains(T item) => MemEx.Contains(Pointer, Length, item);

    public int IndexOf(T item) => MemEx.IndexOf(Pointer, Length, item);
}

public unsafe class JBoolArray(Handle handle) : JPrimitiveArray<bool>(handle) { public override bool* GetElements(bool isCopy = false) => env_->GetBooleanArrayElements(Address, isCopy); }
public class JBoolArray2D(Handle handle) : JObjectArray<JBoolArray>(handle) { protected override JBoolArray FromHandle(Handle handle) => new(handle); }
public class JBoolArray3D(Handle handle) : JObjectArray<JBoolArray2D>(handle) { protected override JBoolArray2D FromHandle(Handle handle) => new(handle); }
public class JBoolArray4D(Handle handle) : JObjectArray<JBoolArray3D>(handle) { protected override JBoolArray3D FromHandle(Handle handle) => new(handle); }

public unsafe class JByteArray(Handle handle) : JPrimitiveArray<byte>(handle) { public override byte* GetElements(bool isCopy = false) => env_->GetByteArrayElements(Address, isCopy); }
public class JByteArray2D(Handle handle) : JObjectArray<JByteArray>(handle) { protected override JByteArray FromHandle(Handle handle) => new(handle); }
public class JByteArray3D(Handle handle) : JObjectArray<JByteArray2D>(handle) { protected override JByteArray2D FromHandle(Handle handle) => new(handle); }
public class JByteArray4D(Handle handle) : JObjectArray<JByteArray3D>(handle) { protected override JByteArray3D FromHandle(Handle handle) => new(handle); }

public unsafe class JCharArray(Handle handle) : JPrimitiveArray<char>(handle) { public override char* GetElements(bool isCopy = false) => env_->GetCharArrayElements(Address, isCopy); }
public class JCharArray2D(Handle handle) : JObjectArray<JCharArray>(handle) { protected override JCharArray FromHandle(Handle handle) => new(handle); }
public class JCharArray3D(Handle handle) : JObjectArray<JCharArray2D>(handle) { protected override JCharArray2D FromHandle(Handle handle) => new(handle); }
public class JCharArray4D(Handle handle) : JObjectArray<JCharArray3D>(handle) { protected override JCharArray3D FromHandle(Handle handle) => new(handle); }

public unsafe class JShortArray(Handle handle) : JPrimitiveArray<short>(handle) { public override short* GetElements(bool isCopy = false) => env_->GetShortArrayElements(Address, isCopy); }
public class JShortArray2D(Handle handle) : JObjectArray<JShortArray>(handle) { protected override JShortArray FromHandle(Handle handle) => new(handle); }
public class JShortArray3D(Handle handle) : JObjectArray<JShortArray2D>(handle) { protected override JShortArray2D FromHandle(Handle handle) => new(handle); }
public class JShortArray4D(Handle handle) : JObjectArray<JShortArray3D>(handle) { protected override JShortArray3D FromHandle(Handle handle) => new(handle); }

public unsafe class JIntArray(Handle handle) : JPrimitiveArray<int>(handle) { public override int* GetElements(bool isCopy = false) => env_->GetIntArrayElements(Address, isCopy); }
public class JIntArray2D(Handle handle) : JObjectArray<JIntArray>(handle) { protected override JIntArray FromHandle(Handle handle) => new(handle); }
public class JIntArray3D(Handle handle) : JObjectArray<JIntArray2D>(handle) { protected override JIntArray2D FromHandle(Handle handle) => new(handle); }
public class JIntArray4D(Handle handle) : JObjectArray<JIntArray3D>(handle) { protected override JIntArray3D FromHandle(Handle handle) => new(handle); }

public unsafe class JLongArray(Handle handle) : JPrimitiveArray<long>(handle) { public override long* GetElements(bool isCopy = false) => env_->GetLongArrayElements(Address, isCopy); }
public class JLongArray2D(Handle handle) : JObjectArray<JLongArray>(handle) { protected override JLongArray FromHandle(Handle handle) => new(handle); }
public class JLongArray3D(Handle handle) : JObjectArray<JLongArray2D>(handle) { protected override JLongArray2D FromHandle(Handle handle) => new(handle); }
public class JLongArray4D(Handle handle) : JObjectArray<JLongArray3D>(handle) { protected override JLongArray3D FromHandle(Handle handle) => new(handle); }

public unsafe class JFloatArray(Handle handle) : JPrimitiveArray<float>(handle) { public override float* GetElements(bool isCopy = false) => env_->GetFloatArrayElements(Address, isCopy); }
public class JFloatArray2D(Handle handle) : JObjectArray<JFloatArray>(handle) { protected override JFloatArray FromHandle(Handle handle) => new(handle); }
public class JFloatArray3D(Handle handle) : JObjectArray<JFloatArray2D>(handle) { protected override JFloatArray2D FromHandle(Handle handle) => new(handle); }
public class JFloatArray4D(Handle handle) : JObjectArray<JFloatArray3D>(handle) { protected override JFloatArray3D FromHandle(Handle handle) => new(handle); }

public unsafe class JDoubleArray(Handle handle) : JPrimitiveArray<double>(handle) { public override double* GetElements(bool isCopy = false) => env_->GetDoubleArrayElements(Address, isCopy); }
public class JDoubleArray2D(Handle handle) : JObjectArray<JDoubleArray>(handle) { protected override JDoubleArray FromHandle(Handle handle) => new(handle); }
public class JDoubleArray3D(Handle handle) : JObjectArray<JDoubleArray2D>(handle) { protected override JDoubleArray2D FromHandle(Handle handle) => new(handle); }
public class JDoubleArray4D(Handle handle) : JObjectArray<JDoubleArray3D>(handle) { protected override JDoubleArray3D FromHandle(Handle handle) => new(handle); }