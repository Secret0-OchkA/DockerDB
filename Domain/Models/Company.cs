using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "NullCompany";

        public List<Person>? Workers { get; set; }
    }
}
