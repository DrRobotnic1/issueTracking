using API.Models;

namespace API.Repositories
{
  public interface IIssueRepository
  {
    Task AddAsync(Issue issue);
    Task<List<Issue>> GetAllAsync();
    Task<Issue> GetByIdAsync(int id);
  }
}
