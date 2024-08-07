using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class Manifactor
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }  //? means the string can be nullable on creation*


}