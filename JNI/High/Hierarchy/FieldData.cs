using CSJNI.High;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public class FieldData : TypeHandle
{
    public FieldData(Env env, IntPtr handle, string name, JType type) : base(env, handle)
    {
        FieldName = name;
        Type = type;
    }

    public string FieldName { get; init; }
    public JType Type { get; init; }
}