using CSJNI.Low;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class Params : IList<JValue>
{
    public Params(params JValue[] values)
    {
        listValues = values.ToList();
        this.values = values;
    }

    private List<JValue> listValues;
    private JValue[] values;
    public JValue* Ptr { get {
        fixed (JValue* arr = values)
            return arr;
    }}

    public int Count => values.Length;

    public bool IsReadOnly => false;

    public JValue this[int index] { get => values[index]; set => values[index] = value; }

    public int IndexOf(JValue item) => listValues.IndexOf(item);

    public void Insert(int index, JValue item)
    {
        listValues.Insert(index, item);
        values = listValues.ToArray();
    }

    public void RemoveAt(int index)
    {
        listValues.RemoveAt(index);
        values = listValues.ToArray();
    }

    public void Add(JValue item)
    {
        listValues.Add(item);
        values = listValues.ToArray();
    }

    public void Clear()
    {
        listValues.Clear();
        values = new JValue[0];
    }

    public bool Remove(JValue item)
    {
        bool res = listValues.Remove(item);
        if (res)
            values = listValues.ToArray();
        return res;
    }

    public IEnumerator<JValue> GetEnumerator() => throw new NotImplementedException();
    public bool Contains(JValue item) => throw new NotImplementedException();
    public void CopyTo(JValue[] array, int arrayIndex) => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
}