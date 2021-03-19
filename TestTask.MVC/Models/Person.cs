using System;
using System.ComponentModel.DataAnnotations;
using TestTask.MVC.ValidationAttributes;

namespace TestTask.MVC.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Поле дожно быть заполнено")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Поле дожно быть заполнено")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле дожно быть заполнено")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Поле дожно быть заполнено")]
        [RangeDate(ErrorMessage = "Некорректная дата,дата должна быть в формате дд.мм.гггг")]
        public string Birthday { get; set; }
        [Required(ErrorMessage = "Поле дожно быть заполнено")]
        [RegularExpression("^\\d{3}-\\d{3}-\\d{3}-\\d{2}$",ErrorMessage ="Снилс должен быть в формате XXX-XXX-XXX-XX")]
        public string Snils { get; set; }
    }
}
