using JNI.Models.Handles;
using JNI.Models.Models.Class;
using JNI.Models.Models.Object;
using JNI.Models.Models.Type;
using System;
using System.Collections;

namespace JNI.Models.Models.Array;
public unsafe abstract class JArray : HandleContainer, IList<JObject>
{
    public JArray(EnvHandle handle) : base(handle) { }

    public int Count => Env.Native->GetArrayLength(Addr);

    public bool IsReadOnly => true;

    public JObject this[int index] { get => Get(index); set => Set(index, value); }

    public virtual JObject Get(int index) => LJObject.Create(Native->GetObjectArrayElement(Addr, index));
    public void Set(int index, JObject obj) => Native->SetObjectArrayElement(Addr, index, obj);

    public bool Contains(JObject item)
    {
        int count = Count;
        for (int i = 0; i < count; i++)
        {
            using var obj = this[i];
            if (obj == item)
                return true;
        }
        return false;
    }

    public int IndexOf(JObject item)
    {
        int count = Count;
        for (int i = 0; i < count; i++)
        {
            using var obj = this[i];
            if (obj == item)
                return i;
        }
        return -1;
    }

    public void Add(JObject item) => throw new NotImplementedException();
    public void CopyTo(JObject[] array, int arrayIndex) => throw new NotImplementedException();
    public IEnumerator<JObject> GetEnumerator() => throw new NotImplementedException();
    public void Insert(int index, JObject item) => throw new NotImplementedException();
    public bool Remove(JObject item) => throw new NotImplementedException();
    public void RemoveAt(int index) => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
    public void Clear() => throw new NotImplementedException();
}

public unsafe class LJArray : JArray
{
    public LJArray(LHandle handle) : base(handle) { }

    public new LJObject this[int index] { get => (Get(index) as LJObject)!; set => Set(index, value); }
}

public unsafe class GJArray : JArray
{
    public GJArray(GHandle handle) : base(handle) { }

    public override JObject Get(int index) => GJObject.Create(Native->GetObjectArrayElement(Addr, index));

    public new GJObject this[int index] { get => (Get(index) as GJObject)!; set => Set(index, value); }
}