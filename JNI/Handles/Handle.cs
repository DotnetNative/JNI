using static System.Formats.Asn1.AsnWriter;
using System.ComponentModel;
using System.Net;

namespace JNI;

/// <summary>
/// Contains address of jvm object, like <see cref="JObject"/>, <see cref="JField"/> and etc
/// </summary>
public unsafe abstract class Handle
{
    public abstract nint Addr { get; set; }

    /// <summary>
    /// Checks if handle is null. This check can't be used for <see cref="JObject"/>
    /// </summary>
    public bool IsNull => Addr == nint.Zero;

    public static implicit operator nint(Handle val) => val.Addr;
    public static implicit operator void*(Handle val) => (void*)val.Addr;
}