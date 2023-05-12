using System.ComponentModel.DataAnnotations;

namespace MiniApp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage ="Class Required")]
        public string Class { get; set; } = string.Empty;
    }
}
