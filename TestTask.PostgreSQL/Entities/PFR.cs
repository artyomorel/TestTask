using System.ComponentModel.DataAnnotations;

namespace TestTask.PostgreSQL.Entities
{
    public class PFR
    {
        [Key]
        public string Snils { get; set; }
        public double Sum { get; set; }
        public int Perio { get; set; }
    }
}
