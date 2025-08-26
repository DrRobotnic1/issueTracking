using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers
{
  public static class TestDbContextFactory
  {
    public static AppDbContext Create()
    {
      var options = new DbContextOptionsBuilder<AppDbContext>()
          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
          .Options;

      var context = new AppDbContext(options);

      
      context.Statuses.Add(new Status { Id = 1, Name = "Open" });
      context.IssueTypes.Add(new IssueType { Id = 1, Name = "Bug" });
      context.SaveChanges();

      return context;
    }
  }
}
