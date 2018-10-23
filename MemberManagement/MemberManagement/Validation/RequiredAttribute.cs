using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace MemberManagement
{
    [AttributeUsage(AttributeTargets.Property)] // only use this attribute for properties.
    class RequiredAttribute : Attribute
    {
        private string _Message;
        public RequiredAttribute(string message)
        {
            if (message == null || message.Length == 0)
            {
                message = "The field is requred.";
            }
            Message = message;
        }
        public RequiredAttribute()
        {
            Message = "The field is requred.";
        }
        public string Message
        {
            get
            {
                return _Message;
            }
            private set
            {
                _Message = value;
            }
        }
    }
}
