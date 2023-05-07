using JNI.Internal;

namespace JNI.Models.Local;
public unsafe class JType : ClassHandle
{
    public JType(Env env, IntPtr handle, string name, string sig) : base(env, handle)
    {
        BaseCtor(name, sig);
    }

    public JType(Env env, IntPtr handle, string nameAndSig) : this(env, handle, nameAndSig, nameAndSig) { }

    public JType(Env env, string name, string sig) : base(env, env.Master->FindClass(name.Replace('.', '/').UtfPtr()))
    {
        BaseCtor(name, sig);
    }

    private void BaseCtor(string name, string sig)
    {
        Name = name.Replace('.', '/');
        Sig = sig.Replace('.', '/');
    }

    public JType(Env env, string nameAndSig) : this(env, nameAndSig, nameAndSig) { }

    public string Name { get; protected private set; }
    public string Sig { get; protected private set; }
    public int Dim { get; set; } = 0;

    public static explicit operator Arg(JType type) => new Arg(type);
}