using Domain.Domain.Issue;
using System;


namespace Test.Repository
{
  /// <summary>
  /// Json用Isuueエンティティ
  /// </summary>
  public class JsonIssue
  {
    public int number { set; get; }
    public string title { set; get; }
    public JsonUser user { set; get; }
    public string state { set; get; }
    public DateTimeOffset created_at { set; get; }
    public DateTimeOffset updated_at { set; get; }
    public string body { set; get; }
    public int id { set; get; }
    public string comments_url { set; get; }
    public string html_url { set; get; }

    IssueEntity ToDomainEntity()
    {
        // HACK コンストラクタのパラメータによるインスタンス生成
        return new IssueEntity()
        {
            number = number,
            title = title,
            user = user.ToDomainEntity(),
            state = state,
            created_at = created_at,
            updated_at = updated_at,
            body = body,
            id = id,
            comments_url = comments_url,
            html_url = html_url
        };
    }
  }
}