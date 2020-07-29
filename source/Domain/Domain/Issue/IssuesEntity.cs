using System.Collections.Generic;
using System.Linq;

namespace Domain.Domain.Issue
{
  public class IssuesEntity
  {
    public List<IssueEntity> Issues{private set; get;}  = new List<IssueEntity>();

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
    public IssuesEntity GetModifyIssues(IssuesEntity lastedIssueEntities)
    {
      // 現在のIssuesと同じものを除外
      var excecpEntities = lastedIssueEntities.Issues.Where(entity =>entity.state == "open" && Issues.Any(issue => issue.number == entity.number && issue.updated_at == entity.updated_at));
      return IssuesEntity.Create(lastedIssueEntities.Issues.Where(entity => entity.state == "open").Except(excecpEntities).ToList());
    }

    /// <summary>
    /// インスタンス生成
    /// </summary>
    /// <param name="issueEntities">Issueエントリリスト</param>
    public static IssuesEntity Create(List<IssueEntity> issueEntities)
    {
      var result = new IssuesEntity();
      result.Issues.AddRange(issueEntities);
      return result;
    }
  }
}
