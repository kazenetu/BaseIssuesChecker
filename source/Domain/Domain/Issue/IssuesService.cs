using Domain.IntrastructureInterface;

namespace Domain.Domain.Issue
{
  /// <summary>
  /// Issue用サービス
  /// </summary>
  class IssuesService
  {
    /// <summary>
    /// APIから最新のIssue情報を取得、差分の情報を返す
    /// </summary>
    /// <param name="issueRepository">Issueリポジトリインスタンス</param>
    /// <param name="apiRepository">API呼び出しリポジトリインスタンス</param>
    /// <returns>最新差分Issue情報</returns>
    public IssuesEntity GetIssues(IIssueRepository issueRepository, IApiRepository apiRepository)
    {
      // 前回取得結果を取得
      var issuesEntity = issueRepository.GetIssues();

      // APIから最新Issueを取得
      var lastedIssues = apiRepository.GetLatestIssues();

      // 最新Issueを反映
      issueRepository.SetIssues(lastedIssues);

      // 前回から更新された結果を返す
      return issuesEntity.GetModifyIssues(lastedIssues);
    }
  }
}
