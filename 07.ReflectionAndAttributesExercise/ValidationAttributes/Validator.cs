using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties();

            PropertyInfo[] propsWithCustomAttributes = properties
                .Where(p => Attribute.IsDefined(p, typeof(MyValidationAttribute), inherit: true))
                .ToArray();

            foreach (PropertyInfo property in propsWithCustomAttributes)
            {
                IEnumerable<MyValidationAttribute> validationAttributes = property
                    .GetCustomAttributes(typeof(MyValidationAttribute), inherit: true)
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in validationAttributes)
                {
                    object value = property.GetValue(obj);
                    if (!attribute.IsValid(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
