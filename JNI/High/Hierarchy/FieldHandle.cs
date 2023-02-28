using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public class FieldHandle : HandleEnv
{
    public FieldHandle(Env env, IntPtr handle) : base(env, handle) { }
}