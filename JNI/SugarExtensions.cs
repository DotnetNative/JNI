namespace JNI;
public static unsafe class SugarExtensions
{
    public static Arg[] ToArgs(this TypeInfo[] arr)
    {
        var ret = new Arg[arr.Length];
        for (int i = 0; i < arr.Length; i++)
            ret[i] = new(arr[i]);
        return ret;
    }

    public static NativeMethod_[] ToStructs(this NativeMethod[] arr)
    {
        var result = new NativeMethod_[arr.Length];
        for (int i = 0; i < arr.Length; i++)
            result[i] = arr[i].ToStruct();
        return result;
    }

    public static string AsJavaPath(this string path) => path.Replace('.', '/');
}