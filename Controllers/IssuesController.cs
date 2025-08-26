using API.Data;
using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class IssuesController : ControllerBase
  {
    private readonly AppDbContext _dbContext;
    private readonly IssueService _issueService;
    public IssuesController(IssueService issueService, AppDbContext dbContex)
    {
      this._dbContext = dbContex;
      this._issueService = issueService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllIssueAsync()
    {
      return Ok(await _issueService.GetAllIssueAsync());
    }
    [HttpGet("Id")]
    public async Task<IActionResult> GetIssueByIdAsync(int Id)
    {
      return Ok(await _issueService.GetIssueByIdAsync(Id));
    }
    [HttpPost]
    public async Task CreateIssueAsync(IssueRequestDto request)
    {
      await _issueService.CreateIssueAsync(request);
    }
  }
}
