using Domain.Domain.Issue;
using System;

namespace Test.Repository
{
  /// <summary>
  /// Json用ユーザーエンティティ
  /// </summary>
  public class JsouUser
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

    UserEntity ToDomainEntity()
    {
        // HACK コンストラクタのパラメータによるインスタンス生成
        return new UserEntity()
        {
            login = login,
            email = email,
            type = type,
            site_admin = site_admin,
            created_at = created_at,
            id = id,
            url = url,
            html_url = html_url,
            avatar_url = avatar_url
        };
    }
  }
}