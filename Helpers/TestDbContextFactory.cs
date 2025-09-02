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


      context.Statuses.Add(new Status { Name = "Open" });
      context.IssueTypes.Add(new IssueType { Name = "Bug" });
      context.Users.Add(new User { Id = "TestUser", UserName = "Thabang Nkomo" });
      context.SaveChanges();

      return context;
    }
  }
}
