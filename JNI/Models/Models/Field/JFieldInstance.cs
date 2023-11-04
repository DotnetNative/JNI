using JNI.Models.Handles;
using JNI.Models.Models.Class;
using JNI.Models.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.Models.Models.Field;
public abstract class JFieldInstance : FieldData
{
    public JFieldInstance(EnvHandle handle, string name, TypeInfo type) : base(handle, name, type) { }
}