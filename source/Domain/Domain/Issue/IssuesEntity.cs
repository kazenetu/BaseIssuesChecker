using System.Collections.Generic;
using System.Linq;

namespace Domain.Domain.Issue
{
  public class IssuesEntity
  {
    private List<IssueEntity> issues  = new List<IssueEntity>();

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <remarks>生成できないように非公開</remarks>
    private IssuesEntity()
    {
    }

    /// <summary>
    /// 更新されたIssueを返す
    /// </summary>
    /// <param name="lastedIssueEntities">最新Issues</param>
    /// <returns>差分の更新されたIssues</returns>
    public List<IssueEntity> GetModifyIssues(List<IssueEntity> lastedIssueEntities)
    {
      // 現在のIssuesと同じものを除外
      var excecpEntities = lastedIssueEntities.Where(entity =>entity.state == "open" && issues.Any(issue => issue.number == entity.number && issue.updated_at == entity.updated_at));
      return lastedIssueEntities.Where(entity => entity.state == "open").Except(excecpEntities).ToList();
    }

    /// <summary>
    /// インスタンス生成
    /// </summary>
    /// <param name="issueEntities">Issueエントリリスト</param>
    public static IssuesEntity Create(List<IssueEntity> issueEntities)
    {
      var result = new IssuesEntity();
      result.issues.AddRange(issueEntities);
      return result;
    }
  }
}
