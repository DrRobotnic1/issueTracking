using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
  public static class ModelBuilderExtensions
  {

    public static void Seed(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Status>().HasData(
          new Status { Id = 1, Name = "Open" },
          new Status { Id = 2, Name = "In Progress" },
          new Status { Id = 3, Name = "Closed" }
      );

      modelBuilder.Entity<IssueType>().HasData(
          new IssueType { Id = 1, Name = "Bug" },
          new IssueType { Id = 2, Name = "Feature" },
          new IssueType { Id = 3, Name = "Task" }
      );
      modelBuilder.Entity<Issue>()
    .HasOne(i => i.User)
    .WithMany()
    .HasForeignKey(i => i.UserId)
    .OnDelete(DeleteBehavior.SetNull);

    }
  }
}
