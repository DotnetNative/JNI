using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public class JArray : JObject, IList<JObject>
{
    public JArray(Env env, IntPtr addr) : base(env, addr)
    {

    }

    public JObject this[int index]
    {
        get => Env.GetObjectArrayElement(this, index);
        set => Env.SetObjectArrayElement(this, index, value);
    }

    public int Count => Env.GetArrayLength(this);

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