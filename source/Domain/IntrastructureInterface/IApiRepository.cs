using Domain.Domain.Issue;

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
