using Domain.Domain.Issue;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Application.Model
{
  /// <summary>
  /// Issueモデル
  /// </summary>
  public class IssueModel
  {
    public int number { set; get; }
    public string title { set; get; }
    public UserModel user { set; get; }
    public string state { set; get; }
    public DateTimeOffset created_at { set; get; }
    public DateTimeOffset updated_at { set; get; }
    public string body { set; get; }
    public int id { set; get; }
    public string comments_url { set; get; }
    public string html_url { set; get; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="entity">対象エンティティ</param>
    internal IssueModel(IssueEntity entity)
    {
      number = entity.number;
      title = entity.title;
      user = new UserModel(entity.user);
      state = entity.state;
      created_at = entity.created_at;
      updated_at = entity.updated_at;
      body = entity.body;
      id = entity.id;
      comments_url = entity.comments_url;
      html_url = entity.html_url;
    }

    /// <summary>
    /// インスタンス生成
    /// </summary>
    /// <param name="entities">対象エンティティ</param>
    /// <returns>Issueモデルリスト</returns>
    internal static List<IssueModel> CreateIssues(List<IssueEntity> entities)
    {
      return entities.Select(entity=>new IssueModel(entity)).ToList();
    }
  }
}