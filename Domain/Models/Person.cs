using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "NullPerson";

        [Required]
        public int Age { get; set; } = 0;

        public Company? Work { get; set; }
    }
}
