using Domain.Domain.Issue;
using Domain.IntrastructureInterface;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Intrastructure
{
  /// <summary>
  /// Issueリポジトリ
  /// </summary>
  /// <remarks>singletonパターンで実装</remarks>
  public class IssueRepository : IIssueRepository
  {
    private const string JSONFileName = "local.json";

    /// <summary>
    /// Issueリポジトリインスタンス
    /// </summary>
    private static IssueRepository instance = null;

    /// <summary>
    /// Issueデータ
    /// </summary>
    private IssuesEntity issues = IssuesEntity.Create(new List<IssueEntity>());

    /// <summary>
    /// 基本パス：実行ファイルのパス
    /// </summary>
    private string baseDirectory;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <remarks>非公開</remarks>
    private IssueRepository()
    {
      baseDirectory = Path.GetDirectoryName(typeof(IssueRepository).Assembly.Location);
    }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <returns>インスタンス</returns>
    public static IssueRepository GetInstance()
    {
      if (instance is null)
      {
        instance = new IssueRepository();

        // ローカルからファイルを取得
        instance.loadIssueFile();
      }

      return instance;
    }

    /// <summary>
    /// Issueデータの取得
    /// </summary>
    /// <returns>現在設定されているIssueデータ</returns>
    public IssuesEntity GetIssues()
    {
      return issues;
    }

    /// <summary>
    /// Issueデータの設定
    /// </summary>
    /// <param name="target">設定値</param>
    /// <returns>設定の成功/失敗</returns>
    public bool SetIssues(IssuesEntity target)
    {
      issues = target;

      saveIssueFile();

      return true;
    }

    /// <summary>
    /// IssueデータJsonファイルの読み取り
    /// </summary>
    private void loadIssueFile()
    {
      var JSONFilePath = Path.Combine(baseDirectory, JSONFileName);

      // ファイルがない場合は終了
      if (!File.Exists(JSONFilePath))
      {
        return;
      }

      var json = string.Empty;
      using (var sr = new StreamReader(JSONFilePath))
      {
        json = sr.ReadToEnd();
      }
      var jsonIssues = JsonSerializer.Deserialize<List<JsonIssue>>(json);
      issues = IssuesEntity.Create(jsonIssues.Select(item => item.ToDomainEntity()).ToList());
    }

    /// <summary>
    /// IssueデータJsonファイルの書き込み
    /// </summary>
    private void saveIssueFile()
    {
      var json = JsonSerializer.Serialize(issues.Issues);

      var JSONFilePath = Path.Combine(baseDirectory, JSONFileName);
      using (var sw = new StreamWriter(JSONFilePath))
      {
        sw.Write(json);
      }
    }
  }
}
