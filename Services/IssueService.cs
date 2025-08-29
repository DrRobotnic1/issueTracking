using API.Dtos.Issue;
using API.Mappings;
using API.Models;
using API.Repositories.IssueRepo;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Services
{
  public class IssueService
  {
    private readonly IIssueRepository _repository;
    public IssueService(IIssueRepository repository)
    {
       this._repository = repository; 
    }
    public async Task CreateIssueAsync(IssueRequestDto request,string userId)
    {
      await _repository.AddAsync(IssueMapper.ToNewIssue(request,userId));
    }
    public async Task<List<IssueResponseDto>> GetAllIssueAsync()
    {
      return IssueMapper.ToResponseDtoList(await _repository.GetAllAsync());
    }
    public async Task<IssueResponseDto> GetIssueByIdAsync(int Id)
    {
      return  IssueMapper.ToResponseDto(await _repository.GetByIdAsync(Id));
    }
    public async Task UpdateIssueStatusAsync(int issueId, int newStatusId)
    {
      await _repository.UpdateStatusAsync(issueId, newStatusId);
    }
  }
}
