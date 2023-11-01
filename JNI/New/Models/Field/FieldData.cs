using JNI.New.Handles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New.Models.Field;
public abstract class FieldData : HandleContainer
{
    public FieldData(EnvHandle handle, string name, string sig) : base(handle)
    {
        Name = name;
        Signature = sig;
    }

    public readonly string Name;
    public readonly string Signature;
}