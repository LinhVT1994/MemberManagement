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
        Success, // The registering is success.
        Fail,    // The registering is fail.
        AccountRegistered, // The email is registered.
    }

    class Service
    {
        private Dictionary<string, Member> _MemberList = null;
        public Service()
        {
            _MemberList = new Dictionary<string, Member>();
        }
        public RegisterStatus Register(string firstName, string lastName, string email, string address = null, string phoneNumber = null)
        {
            switch (EmailValidation(email))
            {
                case MemberManagement.ValidationInfo.Unregistered:
                    // can register this email.
                    Member member = CreateNewAccount(firstName, lastName, email, address, phoneNumber); // create a new account.
                    if (member == null)
                    {
                        return RegisterStatus.Fail;
                    }
                    else
                    {
                        return RegisterStatus.Success;
                    }
                case MemberManagement.ValidationInfo.Registered:
                    Console.WriteLine("This email is used to registered.");
                    // the email is registered.

                    return RegisterStatus.AccountRegistered;
                case MemberManagement.ValidationInfo.EmailInvalid:
                    Console.WriteLine("The email address you entered is invalid.");
                    // the format of the entered email address is not correct.
                    return RegisterStatus.Fail;
                default:
                    return RegisterStatus.Fail;
            }
        }
        public RegisterStatus Register(Member newMember)
        {
            if (newMember.FirstName==null || newMember.LastName==null || newMember.EmailAddress ==null)
            {
                return RegisterStatus.Fail;
            }
            else
            {
                if (newMember.FirstName.Length == 0 || newMember.LastName.Length == 0 || newMember.EmailAddress.Length == 0)
                {
                    return RegisterStatus.Fail;
                }
            }
            switch (EmailValidation(newMember.EmailAddress))
            {
                case MemberManagement.ValidationInfo.Unregistered:
                    // can register this email.
                    Console.WriteLine("Please create a new account.");
                    return RegisterStatus.Success;

                case MemberManagement.ValidationInfo.Registered:
                    Console.WriteLine("This email is used to registered.");
                    // the email is registered.
                    return RegisterStatus.AccountRegistered;
                case MemberManagement.ValidationInfo.EmailInvalid:
                    Console.WriteLine("The email address you entered is invalid.");
                    // the format of the entered email address is not correct.
                    return RegisterStatus.Fail;
                default:
                    return RegisterStatus.Fail;
            }
        }
        /// <summary>
        /// Create a new account.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">Email address.</param>
        /// <param name="address">Address.</param>
        /// <param name="phoneNumber">Phone number.</param>
        public Member CreateNewAccount(string firstName, string lastName, string email, string address = null, string phoneNumber = null)
        {
            Member member = Member.Create(firstName, lastName, email, address, phoneNumber); // create a new member.
            if (member == null)
            {
                return null;
            }
            else
            {
                _MemberList.Add(member.EmailAddress, member); // add the new member into the list member.
                return member;
            }
        }
        private ValidationInfo EmailValidation(string email)
        {
            if (email == null)
            {
                return MemberManagement.ValidationInfo.EmailInvalid;
            }
            email = email.Trim(); // remove spaces at the first and last of the entered email to avoid  unexpected errors.
           
            // check whether the entered email is a valid email address.
            if (!IsEmailAddressValid(email)) 
            {
                return MemberManagement.ValidationInfo.EmailInvalid;
            }

            // check whether the entered email has existed or not.
            if (_MemberList.ContainsKey(email))
            {
                return MemberManagement.ValidationInfo.Registered;
            }
            else
            {
                return MemberManagement.ValidationInfo.Unregistered;
            }
        }
        private bool IsEmailAddressValid(string email)
        {
            string expresion = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, expresion);
        }

    }
}
