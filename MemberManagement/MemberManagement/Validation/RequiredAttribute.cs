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

        /// <summary>
        /// Get all of properties that is required.
        /// </summary>
        /// <param name="obj"></param>
        public static List<string> GetRequiredProperties(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();
            List<string> requiredPropaties = new List<string>();
            foreach (PropertyInfo property in properties)
            {
                Attribute[] attributes = (Attribute[])property.GetCustomAttributes(typeof(RequiredAttribute), false); // get the attributes of a property.
                if (attributes.Length > 0)
                {
                    requiredPropaties.Add(property.Name); // add a attribute in the required properties.
                }
            }
            return requiredPropaties;
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
