using Domain.Domain.Entity;
using Domain.IntrastructureInterface;
using System.Collections.Generic;
using System.Text.Json;

namespace Test.Repository
{
  class ApiRepository : IApiRepository
  {
    public string JsonText { set; get; }

    public List<IssueEntity> GetLatestIssues()
    {
      return JsonSerializer.Deserialize<List<IssueEntity>>(JsonText);
    }
  }
}
