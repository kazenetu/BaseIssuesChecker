using Domain.Domain.Entity;
using System.Collections.Generic;

namespace Domain.IntrastructureInterface
{
  /// <summary>
  /// API呼び出しインターフェイス
  /// </summary>
  public interface IApiRepository
  {
    List<IssueEntity> GetLatestIssues();
  }
}
