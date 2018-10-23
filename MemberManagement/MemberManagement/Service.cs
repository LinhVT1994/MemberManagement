using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MemberManagement
{
    enum RegisterErrorStatus
    {
        None,
        Registered, // The email is registered.
        EmailInvalid,
        InfoNotEnough,
    }
    class Service
    {
        private Dictionary<string, Member> _MemberList = null;
        private RegisterErrorStatus _ErrorStatus = RegisterErrorStatus.None;
        public Service()
        {
            _MemberList = new Dictionary<string, Member>();
        }
        /// <summary>
        /// Register a new member.
        /// </summary>
        /// <param name="firstName">Firstname of the member wants to register.</param>
        /// <param name="lastName">Lastname of the member wants to register.</param>
        /// <param name="email">Email adrress of the member wants to register.</param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <returns>A member object if the registering is success and in contrary, the null value will returned.</returns>
        public Member Register(string firstName, string lastName, string email, string address = null, string phoneNumber = null)
        {
            Member newMember = Member.Create(firstName, lastName, email, address, phoneNumber);
            return Register(newMember);
        }
        /// <summary>
        /// Register a new member.
        /// </summary>
        /// <param name="member">The member object, needs to register.</param>
        /// <returns>True if the registering is success and in contrary, the false value will returned.</returns>
        public Member Register(Member member)
        {
            bool isValid = ValidationInformation(member);
            if (!isValid)
            {
                return null;
            }
            return AddNewMember(member);
        }
        /// <summary>
        /// Check the input information of entered member object before registering whether is valid or not.
        /// </summary>
        /// <param name="member">The member object, needs to check.</param>
        /// <returns>True if the object is valid and false if the object is invalid.</returns>
        public bool ValidationInformation(Member member)
        {
            if (member == null)
            {
                ErrorStatus = RegisterErrorStatus.InfoNotEnough;
                return false;
            }
            if (!Validation.InputValidation(member))
            {
                ErrorStatus = RegisterErrorStatus.InfoNotEnough;
                return false;
            }
            if (!Validation.EmailValidation(member.EmailAddress))
            {
                ErrorStatus = RegisterErrorStatus.EmailInvalid;
                return false;
            }
            if (IsExist(member.EmailAddress))
            {
                ErrorStatus = RegisterErrorStatus.Registered;
                return false;
            }
            return true;
        }
        /// <summary>
        /// Add a new memmber.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">Email address.</param>
        /// <param name="address">Address.</param>
        /// <param name="phoneNumber">Phone number.</param>
        /// <returns>The information of the member has just registered.</returns>
        private Member AddNewMember(string firstName, string lastName, string email, string address = null, string phoneNumber = null)
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
        /// <summary>
        /// Add a new memmber.
        /// </summary>
        /// <param name="member">The memmber needs to register.</param>
        /// <returns>The information of the member has just registered.</returns>
        private Member AddNewMember(Member member)
        {
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
        /// <summary>
        /// Check whether a email address has registered or not.
        /// </summary>
        /// <param name="email">The email need to check.</param>
        /// <returns>true value if the email is exist and In contrary, return the false value.</returns>
        public bool IsExist(string email)
        {
            email = email.Trim(); // remove spaces at the first and the last of entered email to avoid unexpected errors. 
            if (!Validation.EmailValidation(email))
            {
                return false;
            }
            else
            {
                if (_MemberList==null)
                {
                    return false;
                }
                else
                {
                   return _MemberList.ContainsKey(email);  // the account has already registed.
                }
            }
        }
        /// <summary>
        /// The status of registering an new account.
        /// </summary>
        public RegisterErrorStatus ErrorStatus
        {
            get
            {
                return _ErrorStatus;
            }
            private set
            {
                _ErrorStatus = value;
            }
        }
    }
}
