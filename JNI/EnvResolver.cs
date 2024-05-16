namespace JNI;
public unsafe class EnvResolver
{
    [DllImport("kernel32")] public static extern 
        byte* TlsGetValue(int index);

    public EnvResolver(Env_* e)
    {
        for (var i = 0; i < byte.MaxValue; i++)
        {
            var tlsValue = TlsGetValue(i);
            var offset = (nint)e - (nint)tlsValue;
            if (Math.Abs(offset) < Math.Abs(Offset))
            {
                Offset = offset;
                Index = i;
            }
        }
    }

    int Index = -1;
    nint Offset = nint.MaxValue;

    public Env_* Resolve() => (Env_*)(TlsGetValue(Index) + Offset);
}