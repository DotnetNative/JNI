using JNI.Internal;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace JNI.Models;
public class HandleEnv : Handle, IDisposable
{
    public HandleEnv(Env env, IntPtr handle) : base(handle)
    {
        Env = env;
        //frame = new JFrame(handle);
        //Active.Add(frame);
    }

    public Env Env;
    //private JFrame frame;
    //public static object RedisposeCountLocker;
    //public static int RedisposeCount = 0;

    public void PutGlobal()
    {
        SecondaryAddr = Addr;
        Addr = Env.NewGlobalRef(Addr);
    }

    //private bool isDisposed;
    public void Dispose()
    {
        //if (isDisposed)
        //{
            //lock (RedisposeCountLocker)
                //RedisposeCount++;
            //return;
        //}
        //isDisposed = true;

        //Active.Remove(frame);

        if (SecondaryAddr == IntPtr.Zero)
            Env.DeleteLocalRef(Addr);
        else
        {
            Env.DeleteGlobalRef(Addr);
            Env.DeleteLocalRef(SecondaryAddr);
        }
    }

    //~HandleEnv() => Dispose(true);

    //public static List<JFrame> Active = new List<JFrame>();

    /*
    public class JFrame
    {
        public JFrame(IntPtr handle)
        {
            Created = DateTime.Now;
            //Frames = new StackTrace(true).GetFrames();
            try
            {
                //StackTrace = Environment.StackTrace;
            }
            catch (Exception ex) { File.AppendAllText(@"B:\a.txt", ex.ToString() + "|||\n\n\n"); }
            Handle = handle;
        }

        public DateTime Created;
        //public StackFrame[] Frames;
        public string StackTrace;
        public IntPtr Handle;
    }
    */
}