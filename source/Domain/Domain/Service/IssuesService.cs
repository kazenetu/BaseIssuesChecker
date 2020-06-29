using Domain.Domain.Entity;
using Domain.IntrastructureInterface;
using System.Collections.Generic;

namespace Domain.Domain.Service
{
  /// <summary>
  /// Issue用サービス
  /// </summary>
  public class IssuesService
  {
    public List<IssueEntity> GetIssues(IIssueRepository issueRepository,IApiRepository apiRepository)
    {
      var issuesEntity = IssuesEntity.Create(issueRepository.GetIssues());
      var result = issuesEntity.GetModifyIssues(apiRepository.GetLatestIssues());
      issueRepository.SetIssues(result);

      return result;
    }
  }
}
