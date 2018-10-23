using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static bool EmailValidation(string email)
        {
            return IsEmailAddressValid(email);
        }
        private static bool IsEmailAddressValid(string email)
        {
            string expresion = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, expresion);
        }
        public static bool InputValidation(Member member)
        {

            if (member.FirstName == null || member.LastName == null || member.EmailAddress == null)
            {
                return false;
            }
            else
            {
                if (member.FirstName.Length == 0 || member.LastName.Length == 0 || member.EmailAddress.Length == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
