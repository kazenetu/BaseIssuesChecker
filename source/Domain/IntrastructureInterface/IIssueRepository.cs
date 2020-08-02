using Domain.Domain.Issue;

namespace Domain.IntrastructureInterface
{
  /// <summary>
  /// Issueリポジトリインターフェイス
  /// </summary>
  public interface IIssueRepository
  {
    IssuesEntity GetIssues();
    bool SetIssues(IssuesEntity target);
  }
}
