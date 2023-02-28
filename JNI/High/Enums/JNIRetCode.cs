using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Enums;
public enum JNIRetCode
{
    OK = 0,                /* success */
    ERR = -1,              /* unknown error */
    EDETACHED = -2,              /* thread detached from the VM */
    EVERSION = -3,              /* JNI version error */
    ENOMEM = -4,              /* not enough memory */
    EEXIST = -5,              /* VM already created */
    EINVAL = -6,
}