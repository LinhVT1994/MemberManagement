using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManagement
{
    class Member
    {
        private string _LastName; // 姓。
        private string _FirstName; //　名。
        private string _EmailAddress; //　メールアドレス。
        private string _Address;  //　住所。
        private string _PhoneNumber; //　携帯電話番号。　

        /// <summary>
        /// Get fullname of a employee.
        /// </summary>
        /// <returns>Fullname of a employee.</returns>
        /// 
        public string GetFullName()
        {
            return FullName;
        }

        #region Properties of a member.
        /// <summary>
        /// フルネーム
        /// </summary>
        private string FullName
        {
            get
            {
                return _LastName + "　" + FirstName;
            }
            set
            {
                string fullName = value.Trim();  // remove all leading and trailing characters from the current object.
                string[] splitedString = fullName.Split(' '); // sprit the string by a space.
                if (splitedString.Length == 2)
                {
                    FirstName = splitedString[0];
                    LastName = splitedString[1];
                }
                else
                {
                    throw new ArgumentNullException(nameof(FullName) + ":  " + value);
                }
            }
        }
        /// <summary>
        /// 姓
        /// </summary>
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        /// <summary>
        /// 名
        /// </summary>
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        /// <summary>
        /// メールアドレス
        /// </summary>
        public string EmailAddress
        {
            get
            {
                return _EmailAddress;
            }
            set
            {
                _EmailAddress = value;
            }
        }
        /// <summary>
        /// 住所
        /// </summary>
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        /// <summary>
        /// 携帯電話番号
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                _PhoneNumber = value;
            }
        }
        #endregion
    }
}
