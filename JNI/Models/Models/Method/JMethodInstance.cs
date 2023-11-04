using JNI.Models.Handles;
using JNI.Models.Models.Class;
using JNI.Models.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.Models.Models.Method;
public abstract class JMethodInstance : MethodData
{
    public JMethodInstance(EnvHandle handle, string name, TypeInfo type, JClass clazz, params Arg[] args) : base(handle, name, type, args) => Clazz = clazz;

    public JClass Clazz;
}