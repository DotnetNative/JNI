using JNI.Models.Handles;
using JNI.Models.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.Models.Models.Field;
public abstract class FieldData : FieldHandle
{
    public FieldData(EnvHandle handle, string name, TypeInfo type) : base(handle)
    {
        Name = name;
        Signature = SigGen.Field(type);
        Type = type;
    }

    public readonly string Name;
    public readonly string Signature;
    public readonly TypeInfo Type;
}