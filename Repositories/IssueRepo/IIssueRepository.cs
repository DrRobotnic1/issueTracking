using API.Models;

namespace API.Repositories.IssueRepo
{
  public interface IIssueRepository
  {
    Task AddAsync(Issue issue);
    Task<List<Issue>> GetAllAsync();
    Task<Issue> GetByIdAsync(int id);
  }
}
