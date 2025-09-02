using API.Data;
using API.Helpers;
using API.Models;
using API.Repositories;
using API.Repositories.IssueRepo;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace API.API.Tests.RepoTests;

public class IssueRepositoryTests
{
 

  [Fact]
  public async Task AddAsync_ShouldAddIssue()
  {

    
    var context = TestDbContextFactory.Create();
    var repo = new IssueRepository(context);

    var statusId = context.Statuses.First().Id;
    var issueTypeId = context.IssueTypes.First().Id;
    var userId = context.Users.First().Id;

    var issue = new Issue
    {
      Description = "i'm facing a problem ",
      StatusId = statusId,
      IssueTypeId = issueTypeId,
      UserId = userId,
      CreatedAt = DateTime.UtcNow,
      DateUpdated = null
    };

    await repo.AddAsync(issue);
    var issues = await context.Issues.ToListAsync();

    Assert.Single(issues);
    Assert.Equal("Test Issue", issues[0].Description);
  }
  [Fact]
  public async Task GetAllAsync_ShouldReturnIssuesWithIncludes()
  {
    
    var context = TestDbContextFactory.Create();
    var repo = new IssueRepository(context);

    var statusId = context.Statuses.First().Id;
    var issueTypeId = context.IssueTypes.First().Id;
    var userId = context.Users.First().Id;

    context.Issues.Add(new Issue
    {
      Description = "Sample issue",
      StatusId = statusId,
      IssueTypeId = issueTypeId,
      UserId = userId,
      CreatedAt = DateTime.UtcNow
    });
    await context.SaveChangesAsync();

    
    var issues = await repo.GetAllAsync();

    
    Assert.Single(issues);
    Assert.NotNull(issues[0].Status);
    Assert.NotNull(issues[0].IssueType);
  }

  [Fact]
  public async Task GetByIdAsync_ShouldReturnCorrectIssue()
  {

    var context = TestDbContextFactory.Create();
    var repo = new IssueRepository(context);

    var statusId = context.Statuses.First().Id;
    var issueTypeId = context.IssueTypes.First().Id;
    var userId = context.Users.First().Id;

    context.Issues.Add(new Issue
    {
      Id = 99,
      Description = "Specific",
      StatusId = statusId,
      IssueTypeId = issueTypeId,
      UserId = userId,
      CreatedAt = DateTime.UtcNow
    });
    await context.SaveChangesAsync();

    
    var issue = await repo.GetByIdAsync(99);

    
    Assert.NotNull(issue);
    Assert.Equal("Specific", issue.Description);
    Assert.NotNull(issue.Status);
    Assert.NotNull(issue.IssueType);
  }
}
