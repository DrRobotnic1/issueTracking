using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
  public class IssueRequestDto
  {

    [Required]
    public int IssueTypeId { get; set; }
    [Required]
    public string Description { get; set; }
  }
}
