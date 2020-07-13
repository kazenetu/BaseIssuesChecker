using Domain.Domain.Entity;
using System;

namespace Domain.Application.Model
{
  /// <summary>
  /// ユーザーモデル
  /// </summary>
  public class UserModel
  {
    public string login { set; get; }
    public string email { set; get; }
    public string type { set; get; }
    public bool site_admin { set; get; }
    public DateTimeOffset created_at { set; get; }
    public int id { set; get; }
    public string url { set; get; }
    public string html_url { set; get; }
    public string avatar_url { set; get; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="entity">対象エンティティ</param>
    internal UserModel(UserEntity entity)
    {
      login = entity.login;
      email = entity.email;
      type = entity.type;
      site_admin = entity.site_admin;
      created_at = entity.created_at;
      id = entity.id;
      url = entity.url;
      html_url = entity.html_url;
      avatar_url = entity.avatar_url;
    }
  }
}