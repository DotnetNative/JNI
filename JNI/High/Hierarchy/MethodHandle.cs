using CSJNI.High;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public class MethodHandle : HandleEnv
{
    public MethodHandle(Env env, IntPtr handle) : base(env, handle) { }
}