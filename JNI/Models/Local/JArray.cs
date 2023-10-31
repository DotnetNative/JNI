using System.Collections;

namespace JNI.Models.Local;
public unsafe sealed class JArray : JObject, IList<JObject>
{
    public JArray(Env env, nint addr) : base(env, addr) { }
    public JArray(JObject obj) : base(obj.Env, obj.Addr) { }
    public JArray(Env env, ClassHandle type, int length, JObject init) : base(env, nint.Zero)
    {
        var arr = env.NewObjectArray(length, type, init);
        Addr = arr.Addr;
    }

    public JObject this[int index]
    {
        get => new(Env, Env.Native->GetObjectArrayElement(Addr, index));
        set => Env.Native->SetObjectArrayElement(Addr, index, !value);
    }

    public int Count => Env.Native->GetArrayLength(Addr);

    public bool IsReadOnly => true;

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