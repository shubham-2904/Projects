using System.ComponentModel.DataAnnotations;

namespace Entities {
    public class Person {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        [StringLength(250)]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        [StringLength(250)]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Age Name Required")]
        public int Age { get; set; }
    }
}
