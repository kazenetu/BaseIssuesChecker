﻿using Domain.Domain.Entity;
using Domain.Domain.Service;
using Domain.IntrastructureInterface;
using System.Collections.Generic;

namespace Domain.Application
{
  /// <summary>
  /// Issuesアプリケーションサービス
  /// </summary>
  public class IssuesApplication
  {
    /// <summary>
    /// 最新のIssue情報を取得する
    /// </summary>
    /// <param name="issueRepository">Issueリポジトリインスタンス</param>
    /// <param name="apiRepository">API呼び出しリポジトリインスタンス</param>
    /// <returns>最新Issue情報</returns>
    public List<IssueEntity> GetIssues(IIssueRepository issueRepository, IApiRepository apiRepository)
    {
      return new IssuesService().GetIssues(issueRepository, apiRepository);
    }
  }
}