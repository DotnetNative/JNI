using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public class HandleEnv : Handle
{
    public HandleEnv(Env env, IntPtr handle) : base(handle)
    {
        Env = env;
    }

    public Env Env;
}