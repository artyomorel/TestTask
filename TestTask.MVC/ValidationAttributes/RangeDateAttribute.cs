using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestTask.MVC.ValidationAttributes
{
    public class RangeDateAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value == null || !Regex.IsMatch((string)value, "^([0]?[1-9]|[1|2][0-9]|[3][0|1])[.-]([0]?[1-9]|[1][0-2])[.-]([0-9]{4}|[0-9]{2})$"))
            {
                return false;
            }
            
            int[] valueTime = value.ToString().Split(".").Select(x=>Convert.ToInt32(x)).ToArray();

            DateTime time = new DateTime(valueTime[2],valueTime[1], valueTime[0]);
            return time < DateTime.Now;
        }
    }
}
