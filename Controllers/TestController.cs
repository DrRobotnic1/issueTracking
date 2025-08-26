using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestController : ControllerBase
  {
    private readonly AppDbContext _dbContext;
    public TestController(AppDbContext dbContext)
    {
      this._dbContext = dbContext;  
    }
    [HttpGet]
    public async Task<IActionResult> testOutput()
    {
      return Ok(await _dbContext.Statuses.ToListAsync());
    }
  }
}
