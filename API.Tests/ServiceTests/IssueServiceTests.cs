using API.Dtos;
using API.Repositories;
using API.Services;
using Xunit;
using Moq;
using API.Models;

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
      await _service.CreateIssueAsync(request);

      _mockRepo.Verify(repo => repo.AddAsync(It.Is<Issue>(
          issue => issue.Description == "Test issue" && issue.IssueTypeId == 1 && issue.StatusId == 1
      )), Times.Once);
    }
  }
}
