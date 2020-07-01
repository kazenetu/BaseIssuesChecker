using Domain.Application;
using Intrastructure;
using System;

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {
      // 第一パラメータにリポジトリのIssuesをJsonで取得するAPI(GET)のURIを指定する
      if(args.Length < 1)
      {
        Console.WriteLine("Issue取得のURLを設定してください。");
        return;
      }

      var issueRep = IssueRepository.GetInstance();
      var apiRep = new ApiRepository(args[0]);
      var app = new IssuesApplication();
      var issues = app.GetIssues(issueRep, apiRep);

      foreach(var issue in issues)
      {
        Console.WriteLine($"{issue.number} [{issue.body}]");
      }

    }
  }
}
