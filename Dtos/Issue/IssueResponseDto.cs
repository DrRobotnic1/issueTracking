using API.Dtos.User;

namespace API.Dtos.Issue
{
  public class IssueResponseDto
  {
    public int Id { get; set; }
    public string Description { get; set; }

    public StatusDto Status { get; set; }
    public IssueTypeDto IssueType { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? DateUpdated { get; set; }

    public UserDto User { get; set; }
  }
}
