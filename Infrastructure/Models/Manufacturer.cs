using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Manufacturer Name")]
        public string? Name { get; set; }
    }
}
