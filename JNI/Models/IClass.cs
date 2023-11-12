using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI;

public abstract class IClass : JObject
{
    public IClass(EnvHandle handle) : base(handle) { }
}