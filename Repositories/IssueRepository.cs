using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
  public class IssueRepository : IIssueRepository
  {
    private readonly AppDbContext _context;
    public IssueRepository(AppDbContext context)
    {
        this._context = context;
    }
    public async Task AddAsync(Issue issue)
    {
      await _context.AddAsync(issue);
      await _context.SaveChangesAsync();
    }

    public async Task<List<Issue>> GetAllAsync()
    {
      return await _context.Issues
       .Include(issue => issue.Status)
       .Include(issue => issue.IssueType)
       .ToListAsync();
    }

    public async Task<Issue> GetByIdAsync(int Id)
    {
      return await _context.Issues
         .Include(i => i.Status)
         .Include(i => i.IssueType)
         .FirstOrDefaultAsync(i => i.Id == Id);
    }
  }
}
