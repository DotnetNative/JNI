using JNI.Models.Local;

namespace JNI.Models;
public class MethodData : MethodHandle
{
    public MethodData(Env env, IntPtr handle, string name, JType type, Arg[] args) : base(env, handle)
    {
        MethodName = name;
        Type = type;
        Args = args;
    }

    public string MethodName { get; protected private set; }
    public JType Type { get; protected private set; }
    public Arg[] Args { get; protected private set; }
}