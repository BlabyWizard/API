using System.ComponentModel.DataAnnotations;

namespace Universitate.Properties.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        public string Nume { get; set; }
        public string Universitate { get; set; }
        public string Profil{ get; set; }
    }
}
