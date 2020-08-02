using System;

namespace Domain.Domain.Issue
{
  /// <summary>
  /// Isuueエンティティ
  /// </summary>
  public class IssueEntity
  {
    public int number { private set; get; }
    public string title { private set; get; }
    public UserEntity user { private set; get; }
    public string state { private set; get; }
    public DateTimeOffset created_at { private set; get; }
    public DateTimeOffset updated_at { private set; get; }
    public string body { private set; get; }
    public int id { private set; get; }
    public string comments_url { set; get; }
    public string html_url { private set; get; }

    public IssueEntity(
      int number,
      string title,
      UserEntity user,
      string state,
      DateTimeOffset created_at,
      DateTimeOffset updated_at,
      string body,
      int id,
      string comments_url,
      string html_url
    )
    {
      this.number = number;
      this.title = title;
      this.user = user;
      this.state = state;
      this.created_at = created_at;
      this.updated_at = updated_at;
      this.body = body;
      this.id = id;
      this.comments_url = comments_url;
      this.html_url = html_url;
    }
  }
}