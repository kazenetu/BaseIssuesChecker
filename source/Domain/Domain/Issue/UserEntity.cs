using System;

namespace Domain.Domain.Issue
{
  /// <summary>
  /// ユーザーエンティティ
  /// </summary>
  public class UserEntity
  {
    public string login { private set; get; }
    public string email { private set; get; }
    public string type { private set; get; }
    public bool site_admin { private set; get; }
    public DateTimeOffset created_at { private set; get; }
    public int id { private set; get; }
    public string url { private set; get; }
    public string html_url { private set; get; }
    public string avatar_url { private set; get; }

    public UserEntity(
      string login,
      string email,
      string type,
      bool site_admin,
      DateTimeOffset created_at,
      int id,
      string url,
      string html_url,
      string avatar_url
    ){
      this.login = login;
      this.email = email;
      this.type = type;
      this.site_admin = site_admin;
      this.created_at = created_at;
      this.id = id;
      this.url = url;
      this.html_url = html_url;
      this.avatar_url = avatar_url;
    }
  }
}