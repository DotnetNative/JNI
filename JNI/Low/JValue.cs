using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSJNI.Low;

[StructLayout(LayoutKind.Explicit)]
public struct JValue
{
    [FieldOffset(0)]
    public bool z; //1
    [FieldOffset(0)]
    public sbyte b; //1
    [FieldOffset(0)]
    public ushort c; //2
    [FieldOffset(0)]
    public short s; //2
    [FieldOffset(0)]
    public int i; //4
    [FieldOffset(0)]
    public long j; //8
    [FieldOffset(0)]
    public float f; //4
    [FieldOffset(0)]
    public double d; //8
    [FieldOffset(0)]
    public IntPtr l; //8

    public static JValue Zero = new JValue(IntPtr.Zero);

    public JValue(bool value)
    {
        this = new JValue();
        z = value;
    }

    public JValue(sbyte value)
    {
        this = new JValue();
        b = value;
    }

    public JValue(char value)
    {
        this = new JValue();
        c = value;
    }

    public JValue(short value)
    {
        this = new JValue();
        s = value;
    }

    public JValue(int value)
    {
        this = new JValue();
        i = value;
    }

    public JValue(long value)
    {
        this = new JValue();
        j = value;
    }

    public JValue(float value)
    {
        this = new JValue();
        f = value;
    }

    public JValue(double value)
    {
        this = new JValue();
        d = value;
    }

    public JValue(IntPtr value)
    {
        this = new JValue();
        l = value;
    }

    public JValue(JObject value)
    {
        this = new JValue();
        l = value.Addr;
    }

    public static implicit operator JValue(bool val) => new JValue(val);
    public static implicit operator JValue(sbyte val) => new JValue(val);
    public static implicit operator JValue(char val) => new JValue(val);
    public static implicit operator JValue(short val) => new JValue(val);
    public static implicit operator JValue(int val) => new JValue(val);
    public static implicit operator JValue(long val) => new JValue(val);
    public static implicit operator JValue(float val) => new JValue(val);
    public static implicit operator JValue(double val) => new JValue(val);
    public static implicit operator JValue(IntPtr val) => new JValue(val);
    public static implicit operator JValue(JObject val) => new JValue(val);

}