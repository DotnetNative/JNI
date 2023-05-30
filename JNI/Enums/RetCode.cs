namespace JNI.Enums;
public enum RetCode : int
{
    OK = 0,                /* success */
    ERR = -1,              /* unknown error */
    EDETACHED = -2,        /* thread detached from the VM */
    EVERSION = -3,         /* JNI version error */
    ENOMEM = -4,           /* not enough memory */
    EEXIST = -5,           /* VM already created */
    EINVAL = -6,
}