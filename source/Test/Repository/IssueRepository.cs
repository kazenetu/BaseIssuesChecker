using Domain.Domain.Entity;
using Domain.IntrastructureInterface;
using System.Collections.Generic;

namespace Test.Repository
{
  class IssueRepository : IIssueRepository
  {
    private List<IssueEntity> issues = new List<IssueEntity>();

    public List<IssueEntity> GetIssues()
    {
      return issues;
    }

    public bool SetIssues(List<IssueEntity> target)
    {
      issues.Clear();
      issues.AddRange(target);
      return true;
    }
  }
}
