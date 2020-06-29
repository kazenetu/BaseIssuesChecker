using Domain.Domain.Entity;
using System.Collections.Generic;

namespace Domain.IntrastructureInterface
{
  /// <summary>
  /// Issueリポジトリインターフェイス
  /// </summary>
  public interface IIssueRepository
  {
    List<IssueEntity> GetIssues();
    bool SetIssues(List<IssueEntity> target);
  }
}
