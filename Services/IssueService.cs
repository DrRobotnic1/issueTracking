using API.Dtos;
using API.Dtos.Issue;
using API.Mappings;
using API.Models;
using API.Repositories;
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
    public async Task CreateIssueAsync(IssueRequestDto request)
    {
      await _repository.AddAsync(IssueMapper.ToNewIssue(request));
    }
    public async Task<List<IssueResponseDto>> GetAllIssueAsync()
    {
      return IssueMapper.ToResponseDtoList(await _repository.GetAllAsync());
    }
    public async Task<IssueResponseDto> GetIssueByIdAsync(int Id)
    {
      return  IssueMapper.ToResponseDto(await _repository.GetByIdAsync(Id));
    }
  }
}
