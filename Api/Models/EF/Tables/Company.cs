using System.ComponentModel.DataAnnotations;

namespace DockerTestBD.Api.Models.EF.Tables
{
    /// <summary>
    /// Company
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of Company
        /// </summary>
        [Required]
        public string Name { get; set; } = "NullCompany";
        /// <summary>
        /// All Workers in company
        /// </summary>
        public List<Person>? Workers { get; set; }
    }
}
