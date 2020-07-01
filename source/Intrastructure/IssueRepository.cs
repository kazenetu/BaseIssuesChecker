﻿using Domain.Domain.Entity;
using Domain.IntrastructureInterface;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Intrastructure
{
  /// <summary>
  /// Issueリポジトリ
  /// </summary>
  /// <remarks>singletonパターンで実装</remarks>
  public class IssueRepository : IIssueRepository
  {
    private const string JSONFilePath= "./local.json";

    /// <summary>
    /// Issueリポジトリインスタンス
    /// </summary>
    private static IssueRepository instance = null;

    /// <summary>
    /// Issueデータ
    /// </summary>
    private List<IssueEntity> issues = new List<IssueEntity>();

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <remarks>非公開</remarks>
    private IssueRepository()
    {
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
    public List<IssueEntity> GetIssues()
    {
      return issues;
    }

    /// <summary>
    /// Issueデータの設定
    /// </summary>
    /// <param name="target">設定値</param>
    /// <returns>設定の成功/失敗</returns>
    public bool SetIssues(List<IssueEntity> target)
    {
      issues.Clear();
      issues.AddRange(target);

      saveIssueFile();

      return true;
    }

    /// <summary>
    /// IssueデータJsonファイルの読み取り
    /// </summary>
    private void loadIssueFile()
    {
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
      issues.AddRange(JsonSerializer.Deserialize<List<IssueEntity>>(json));
    }

    /// <summary>
    /// IssueデータJsonファイルの書き込み
    /// </summary>
    private void saveIssueFile()
    {
      var json = JsonSerializer.Serialize(issues);
      using (var sw = new StreamWriter(JSONFilePath))
      {
        sw.Write(json);
      }
    }
  }
}