using API.Dtos;
using API.Services;
using Xunit;
using Moq;
using API.Models;
using API.Repositories.IssueRepo;
using API.Dtos.Issue;

namespace API.API.Tests.ServiceTests
{
  public class IssueServiceTests
  {
    private readonly Mock<IIssueRepository> _mockRepo;
    private readonly IssueService _service;

    public IssueServiceTests()
    {
      _mockRepo = new Mock<IIssueRepository>();
      _service = new IssueService(_mockRepo.Object);
    }

    [Fact]
    public async Task CreateIssueAsync_ShouldCallAddAsync_WithMappedIssue()
    {
      var request = new IssueRequestDto
      {
        Description = "Test issue",
        IssueTypeId = 1
      };

      var userId = "thabang-test-user-id";

      await _service.CreateIssueAsync(request, userId);

      _mockRepo.Verify(repo => repo.AddAsync(It.Is<Issue>(
          issue =>
              issue.Description == "Test issue" &&
              issue.IssueTypeId == 1 &&
              issue.StatusId == 1 && 
              issue.UserId == userId
      )), Times.Once);
    }
    [Fact]
    public async Task GetAllIssueAsync_ShouldReturnMappedResponse()
    {
      var issues = new List<Issue>
{
    new Issue
    {
        Id = 1,
        Description = "Issue 1",
        StatusId = 1,
        Status = new Status { Id = 1, Name = "Open" },       
        IssueTypeId = 1,
        IssueType = new IssueType { Id = 1, Name = "Bug" },  
        UserId = "TestUser",
        User = new User { Id = "TestUser", UserName = "Test User" } 
    }
};

      _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(issues);
      var result = await _service.GetAllIssueAsync();

      Assert.Single(result);
      Assert.Equal("Issue 1", result[0].Description);
      Assert.Equal("Open", result[0].Status.Name);
      Assert.Equal("Bug", result[0].IssueType.Name);
    }

    [Fact]
    public async Task GetIssueByIdAsync_ShouldReturnCorrectIssue()
    {

      var issue = new Issue
      {
        Id = 1,
        Description = "Issue 1",
        StatusId = 1,
        Status = new Status { Id = 1, Name = "Open" },
        IssueTypeId = 1,
        IssueType = new IssueType { Id = 1, Name = "Bug" },
        UserId = "TestUser",
        User = new User { Id = "TestUser", UserName = "Test User" } 
      };


      _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(issue);
      var result = await _service.GetIssueByIdAsync(1);

      Assert.NotNull(result);
      Assert.Equal("Issue 1", result.Description);
      Assert.Equal("Open", result.Status.Name);
    }
  }
}
