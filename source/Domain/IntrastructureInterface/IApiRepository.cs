using Domain.Domain.Issue;
using System.Collections.Generic;

namespace Domain.IntrastructureInterface
{
  /// <summary>
  /// API呼び出しインターフェイス
  /// </summary>
  public interface IApiRepository
  {
    IssuesEntity GetLatestIssues();
  }
}
