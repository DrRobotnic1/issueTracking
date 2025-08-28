using API.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Issue
{
  public class IssueRequestDto
  {

    [Required]
    public int IssueTypeId { get; set; }
    [Required]
    public string Description { get; set; }
  }
}
