using Domain.Domain.Entity;
using Domain.IntrastructureInterface;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace Intrastructure
{
  /// <summary>
  /// API呼び出しリポジトリ
  /// </summary>
  public class ApiRepository: IApiRepository
  {
    private string uri = "";

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ApiRepository(string uri)
    {
      this.uri = uri;
    }

    /// <summary>
    /// 最新Issueをネットワークから取得する
    /// </summary>
    /// <returns>最新Issueリスト</returns>
    public List<IssueEntity> GetLatestIssues()
    {
      var json = string.Empty;
      using (var client = new HttpClient())
      {
        var response = client.GetAsync(uri).Result.Content.ReadAsStringAsync();
        json = response.Result;
      }
      return JsonSerializer.Deserialize<List<IssueEntity>>(json);
    }
  }
}
