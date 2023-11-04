using JNI.Models.Handles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.Models.Models.Field;
public class FieldHandle : HandleContainer
{
    public FieldHandle(EnvHandle handle) : base(handle) { }
}