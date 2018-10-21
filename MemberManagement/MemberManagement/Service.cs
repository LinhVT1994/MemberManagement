using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MemberManagement
{
    enum RegisterStatus
    {
        Unregistered,
        Registered,
        EmailInvalid,
    }
    class Service
    {
        private Dictionary<string, Member> _MemberList = null;
        public Service()
        {
            _MemberList = new Dictionary<string, Member>();
        }
        public void Register(string email)
        {
            switch (CheckRegisteredStatus(email))
            {
                case RegisterStatus.Unregistered:
                    // can register this email.
                    break;
                case RegisterStatus.Registered:
                    // the email is registered.
                    break;
                case RegisterStatus.EmailInvalid:
                    // the format of the entered email address is not correct.

                    break;
                default:
                    break;
            }
        }
        private RegisterStatus CheckRegisteredStatus(string email)
        {
            if (email == null)
            {
                return RegisterStatus.EmailInvalid;
            }

            email = email.Trim(); // remove spaces at the first and last of the entered email to avoid  unexpected errors.
           
            // check whether the entered email is a valid email address.
            if (!IsEmailAddressValid(email)) 
            {
                return RegisterStatus.EmailInvalid;
            }

            // check whether the entered email has existed or not.
            if (_MemberList.ContainsKey(email))
            {
                return RegisterStatus.Registered;
            }
            else
            {
                return RegisterStatus.Unregistered;
            }
        }
        private bool IsEmailAddressValid(string email)
        {
            string expresion = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, expresion);
        }

    }
}
