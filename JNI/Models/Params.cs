using System.Collections;

namespace JNI.Models;
public sealed unsafe class Params : IList<JValue>
{
    public Params(params JValue[] values)
    {
        listValues = values.ToList();
        Values = values;
    }

    private List<JValue> listValues;
    public JValue[] Values;

    public int Count => Values.Length;

    public bool IsReadOnly => false;

    public JValue this[int index] { get => Values[index]; set => Values[index] = value; }

    public int IndexOf(JValue item) => listValues.IndexOf(item);

    public void Insert(int index, JValue item)
    {
        listValues.Insert(index, item);
        Values = listValues.ToArray();
    }

    public void RemoveAt(int index)
    {
        listValues.RemoveAt(index);
        Values = listValues.ToArray();
    }

    public void Add(JValue item)
    {
        listValues.Add(item);
        Values = listValues.ToArray();
    }

    public void Clear()
    {
        listValues.Clear();
        Values = new JValue[0];
    }

    public bool Remove(JValue item)
    {
        bool res = listValues.Remove(item);
        if (res)
            Values = listValues.ToArray();
        return res;
    }

    public IEnumerator<JValue> GetEnumerator() => throw new NotImplementedException();
    public bool Contains(JValue item) => throw new NotImplementedException();
    public void CopyTo(JValue[] array, int arrayIndex) => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
}