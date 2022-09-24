using System.ComponentModel.DataAnnotations;

namespace DockerTestBD.Api.Models.EF.Tables
{
    /// <summary>
    /// Person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; } = "NullPerson";
        /// <summary>
        /// Age
        /// </summary>
        [Required]
        public int Age { get; set; } = 0;
        /// <summary>
        /// Work => WorkId in EF
        /// </summary>
        public Company? Work { get; set; }
    }
}
