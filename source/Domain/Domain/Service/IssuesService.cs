using Domain.Domain.Entity;
using Domain.IntrastructureInterface;
using System.Collections.Generic;

namespace Domain.Domain.Service
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
    public List<IssueEntity> GetIssues(IIssueRepository issueRepository,IApiRepository apiRepository)
    {
      var issuesEntity = IssuesEntity.Create(issueRepository.GetIssues());
      var result = issuesEntity.GetModifyIssues(apiRepository.GetLatestIssues());
      issueRepository.SetIssues(result);

      return result;
    }
  }
}
