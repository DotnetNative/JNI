using System.Runtime.InteropServices;

namespace JNI;

[StructLayout(LayoutKind.Explicit)]
public struct JValue
{
    public JValue(bool value)
    {
        this = new();
        z = value;
    }

    public JValue(byte value)
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
        l = value.Address;
    }

    public JValue(Handle value)
    {
        this = new();
        l = value.Address;
    }

    [FieldOffset(0)] bool z;
    [FieldOffset(0)] byte b;
    [FieldOffset(0)] ushort c;
    [FieldOffset(0)] short s;
    [FieldOffset(0)] int i;
    [FieldOffset(0)] long j;
    [FieldOffset(0)] float f;
    [FieldOffset(0)] double d;
    [FieldOffset(0)] nint l;

    public static JValue Zero = new(nint.Zero);

    public static implicit operator JValue(bool val) => new(val);
    public static implicit operator JValue(byte val) => new(val);
    public static implicit operator JValue(char val) => new(val);
    public static implicit operator JValue(short val) => new(val);
    public static implicit operator JValue(int val) => new(val);
    public static implicit operator JValue(long val) => new(val);
    public static implicit operator JValue(float val) => new(val);
    public static implicit operator JValue(double val) => new(val);
    public static implicit operator JValue(nint val) => new(val);
    public static implicit operator JValue(JObject val) => new(val);
    public static implicit operator JValue(Handle val) => new(val);
}