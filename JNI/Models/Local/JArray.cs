using System.Collections;

namespace JNI.Models.Local;
public class JArray : JObject, IList<JObject>
{
    public JArray(Env env, IntPtr addr) : base(env, addr) { }
    public JArray(JObject obj) : base(obj.Env, obj.Addr) { }

    public JObject this[int index]
    {
        get => Env.GetObjectArrayElement(this, index);
        set => Env.SetObjectArrayElement(this, index, value);
    }

    public JObject Get(Env env, int index) => env.GetObjectArrayElement(this, index);
    public void Set(Env env, int index, JObject obj) => env.SetObjectArrayElement(this, index, obj);

    public int Count => Env.GetArrayLength(this);
    public int GetCount(Env env) => env.GetArrayLength(this);

    public bool IsReadOnly => true;

    public bool Contains(JObject item)
    {
        int count = Count;
        for (int i = 0; i < count; i++)
            if (this[i] == item)
                return true;
        return false;
    }

    public int IndexOf(JObject item)
    {
        int count = Count;
        for (int i = 0; i < count; i++)
            if (this[i] == item)
                return i;
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