using API.Dtos.Issue;
using API.Dtos.User;
using API.Models;

namespace API.Mappings
{
  public class IssueMapper
  {
    public static Issue ToNewIssue(IssueRequestDto request,string userId)
    {
      return new Issue
      {
        Description = request.Description,
        StatusId = 1,
        UserId = userId,
        IssueTypeId = request.IssueTypeId,
        DateUpdated = null
      };
    }
    public static List<IssueResponseDto> ToResponseDtoList(List<Issue> issues)
    {
      return issues.Select(ToResponseDto).ToList();
    }

    public static IssueResponseDto ToResponseDto(Issue issue)
    {
      return new IssueResponseDto
      {
        Id = issue.Id,
        Description = issue.Description,
        CreatedAt = issue.CreatedAt,
        DateUpdated = issue.DateUpdated,
        Status = new StatusDto
        {
          Id = issue.Status.Id,
          Name = issue.Status.Name
        },
        IssueType = new IssueTypeDto
        {
          Id = issue.IssueType.Id,
          Name = issue.IssueType.Name
        },
        User = new UserDto
        {
          Id = issue.User.Id,
          UserName = issue.User.UserName
        }
      };
    }
  }
}
