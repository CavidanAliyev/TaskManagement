using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPlatform.Domain.Enum
{
    public enum SignInStatus
    {
        Success = 1,
        LockedOut = 2,
        RequiresVerification = 3,
        Failure = 4
    }
}
