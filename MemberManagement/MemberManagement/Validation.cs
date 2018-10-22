using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement
{
    enum ValidationInfo
    {
        Unregistered,
        Registered,
        EmailInvalid,
    }
    class Validation
    {
        public static bool CheckEmail(string email)
        {
            return false;
        }
    }
}
