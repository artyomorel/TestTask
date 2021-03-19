using System;
using System.ComponentModel.DataAnnotations;

namespace TestTask.MVC.ValidationAttributes
{
    public class RangeDateAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || (DateTime)value > DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
