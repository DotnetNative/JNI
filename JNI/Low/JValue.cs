using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSJNI.Low;

[StructLayout(LayoutKind.Explicit)]
public struct JValue
{
    [FieldOffset(0)]
    public bool z; //1
    [FieldOffset(1)]
    public byte b; //1
    [FieldOffset(2)]
    public ushort c; //2
    [FieldOffset(4)]
    public short s; //2
    [FieldOffset(6)]
    public int i; //4
    [FieldOffset(10)]
    public long j; //8
    [FieldOffset(18)]
    public float f; //4
    [FieldOffset(22)]
    public double d; //8
    [FieldOffset(30)]
    public object l; //8
}