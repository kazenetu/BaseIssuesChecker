using Domain.Domain.Issue;
using Domain.IntrastructureInterface;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Test.Repository
{
  class ApiRepository : IApiRepository
  {
    public string JsonText { set; get; }

    public IssuesEntity GetLatestIssues()
    {
      var result = JsonSerializer.Deserialize<List<JsonIssue>>(JsonText);
      return IssuesEntity.Create(result.Select(item => item.ToDomainEntity()).ToList());
    }
  }
}
