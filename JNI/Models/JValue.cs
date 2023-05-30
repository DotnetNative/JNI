using JNI.Models.Global;
using JNI.Models.Local;
using System.Runtime.InteropServices;

namespace JNI.Models;

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
    public nint l; //8

    public static JValue Zero = new JValue(nint.Zero);

    public JValue(bool value)
    {
        this = new();
        z = value;
    }

    public JValue(sbyte value)
    {
        this = new();
        b = value;
    }

    public JValue(char value)
    {
        this = new();
        c = value;
    }

    public JValue(short value)
    {
        this = new();
        s = value;
    }

    public JValue(int value)
    {
        this = new();
        i = value;
    }

    public JValue(long value)
    {
        this = new();
        j = value;
    }

    public JValue(float value)
    {
        this = new();
        f = value;
    }

    public JValue(double value)
    {
        this = new();
        d = value;
    }

    public JValue(nint value)
    {
        this = new();
        l = value;
    }

    public JValue(JObject value)
    {
        this = new();
        l = value.Addr;
    }

    public JValue(JGObject value)
    {
        this = new();
        l = value.Addr;
    }

    public static implicit operator JValue(bool val) => new(val);
    public static implicit operator JValue(sbyte val) => new(val);
    public static implicit operator JValue(char val) => new(val);
    public static implicit operator JValue(short val) => new(val);
    public static implicit operator JValue(int val) => new(val);
    public static implicit operator JValue(long val) => new(val);
    public static implicit operator JValue(float val) => new(val);
    public static implicit operator JValue(double val) => new(val);
    public static implicit operator JValue(nint val) => new(val);
    public static implicit operator JValue(JObject val) => new(val);
    public static implicit operator JValue(JString val) => new(val);
}