namespace API.Models
{
  public class IssueType
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Issue> Issues { get; set; }
  }
}
