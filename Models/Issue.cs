using System.ComponentModel.DataAnnotations;

namespace API.Models
{
  public class Issue
  {
    public int Id { get; set; }

    public string Description { get; set; }

    [Required]
    public int StatusId { get; set; }
    public Status Status { get; set; }

    [Required]
    public int IssueTypeId { get; set; }
    public IssueType IssueType { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? DateUpdated { get; set; }

    public string UserId { get; set; }
    public User User { get; set; }
  }
}
