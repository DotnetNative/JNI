namespace JNI.Models.Global;
public unsafe sealed class JGArray : JGObject
{
    public JGArray(Env env, nint lAddr) : base(env.NewGlobalRef(lAddr), lAddr) { }
    public JGArray(JGObject obj) : base(obj.Addr, obj.LocalAddr) { }

    public JGObject Get(Env env, int index)
    {
        var addr = env.Master->GetObjectArrayElement(Addr, index);
        return new JGObject(env.NewGlobalRef(addr), addr);
    }
    public void Set(Env env, int index, JGObject obj) => env.Master->SetObjectArrayElement(Addr, index, !obj);

    public int Count => throw new NotImplementedException();
    public int GetCount(Env env) => env.Master->GetArrayLength(Addr);

    public bool IsReadOnly => true;

    public bool Contains(Env env, JGObject item)
    {
        int count = Count;
        for (int i = 0; i < count; i++)
        {
            var obj = Get(env, i);
            if (obj == item)
                return true;
            obj.Dispose(env);
        }
        return false;
    }

    public int IndexOf(Env env, JGObject item)
    {
        int count = Count;
        for (int i = 0; i < count; i++)
        {
            var obj = Get(env, i);
            if (obj == item)
                return i;
            obj.Dispose(env);
        }
        return -1;
    }
}