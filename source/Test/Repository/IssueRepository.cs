using Domain.Domain.Issue;
using Domain.IntrastructureInterface;
using System.Collections.Generic;

namespace Test.Repository
{
  class IssueRepository : IIssueRepository
  {
    private IssuesEntity issues = IssuesEntity.Create(new List<IssueEntity>());

    public IssuesEntity GetIssues()
    {
      return issues;
    }

    public bool SetIssues(IssuesEntity target)
    {
      issues = target;
      return true;
    }
  }
}
