using API.Dtos;
using API.Dtos.Issue;
using API.Models;

namespace API.Mappings
{
  public class IssueMapper
  {
    public static Issue ToNewIssue(IssueRequestDto request)
    {
      return new Issue
      {
        Description = request.Description,
        StatusId = 1,
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
        CreatedAt = issue.CreatedAt,
        DateUpdated = issue.DateUpdated
      };
    }
  }
}
