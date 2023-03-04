using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public class MethodData : HandleEnv
{
    public MethodData(Env env, IntPtr handle, string name, JType type, Arg[] args) : base(env, handle)
    {
        MethodName = name;
        Type = type;
        Args = args;
    }

    public string MethodName { get; init; }
    public JType Type { get; init; }
    public Arg[] Args { get; init; }
}