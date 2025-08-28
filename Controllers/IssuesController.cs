using API.Data;
using API.Dtos.Issue;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
  [Authorize]
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
    public async Task<IActionResult> CreateIssueAsync(IssueRequestDto request)
    {
      var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

      if (string.IsNullOrEmpty(userId))
      {
        return Unauthorized("User ID not found in token.");
      }

      await _issueService.CreateIssueAsync(request, userId);
      return Ok();
    }
  }
}
