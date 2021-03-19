using System;
using System.ComponentModel.DataAnnotations;

namespace TestTask.PostgreSQL.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Birthday { get; set; }
        public string Snils { get; set; }
    }
}
