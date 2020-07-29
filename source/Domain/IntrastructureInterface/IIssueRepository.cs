using Domain.Domain.Issue;
using System.Collections.Generic;

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
