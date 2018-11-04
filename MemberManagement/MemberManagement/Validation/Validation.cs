using MemberManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MemberManagement
{
    class Validation
    {
        /// <summary>
        /// Check the validation of a email.
        /// </summary>
        /// <param name="email">The email address, needs to check.</param>
        /// <returns>The true value if the email is valid \n.In contrast, the false value will be returned.</returns>
        public static bool EmailValidation(string email)
        {
            return IsEmailAddressValid(email);
        }
        /// <summary>
        /// Check the format of a email address. 
        /// </summary>
        /// <param name="email">The email address, needs to check.</param>
        /// <returns>The true value if the email is valid format. In contrast, the false value will be returned.</returns>
        private static bool IsEmailAddressValid(string email)
        {
            string expresion = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, expresion);
        }
        /// <summary>
        /// Check that the parameters of a member object, is required, is whether valid or not.
        /// </summary>
        /// <param name="member">The member object, needs to check.</param>
        /// <returns>The true value if all of info is correct.</returns>
        public static bool InputValidation(Member member)
        {
            List<string> requiredPropaties = RequiredAttribute.GetRequiredProperties(member); // get required properties.
            Type type = member.GetType();
            string value = null;
            foreach (string str in requiredPropaties)
            {
                value = (string)GetPropValue(member, str);
                if (value == null || value.Length == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

    }
}
