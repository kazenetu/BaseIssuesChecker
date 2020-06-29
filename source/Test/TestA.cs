using Domain.Domain.Entity;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using Xunit;
using Test.Repository;
using Domain.Domain.Service;

namespace Test
{
  [Trait("テスト", nameof(TestA))]
  public class TestA
  {
    private IssueRepository issueRepository = new IssueRepository();
    private ApiRepository apiRepository = new ApiRepository();


    [Fact]
    public void FisrtIssuesTest()
    {
      apiRepository.JsonText = @"
[
    {
        ""number"": 2,
        ""title"": ""イシュー２"",
        ""user"": {
            ""login"": ""user"",
            ""email"": ""user@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-09T04:32:49Z"",
        ""updated_at"": ""2020-06-18T07:13:54Z"",
        ""body"": ""イシュー２"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/2/comments"",
        ""html_url"": ""html_url/test/issues/2""
    }
]      
      ";

      var service = new IssuesService();


      var issues = service.GetIssues(issueRepository, apiRepository);

      Assert.True(issues.Count == 1);
      Assert.True(issues[0].number == 2);
      Assert.True(issues[0].user.login == "user");
    }

    [Fact]
    public void ModifyIssuesTest()
    {
      apiRepository.JsonText = @"
[
    {
        ""number"": 2,
        ""title"": ""イシュー２"",
        ""user"": {
            ""login"": ""user"",
            ""email"": ""user@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-09T04:32:49Z"",
        ""updated_at"": ""2020-06-18T07:13:54Z"",
        ""body"": ""イシュー２"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/2/comments"",
        ""html_url"": ""html_url/test/issues/2""
    }
]      
      ";

      var service = new IssuesService();

      service.GetIssues(issueRepository, apiRepository);

      apiRepository.JsonText = @"
[
    {
        ""number"": 2,
        ""title"": ""イシュー２"",
        ""user"": {
            ""login"": ""user"",
            ""email"": ""user@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-09T04:32:49Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー２"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/2/comments"",
        ""html_url"": ""html_url/test/issues/2""
    }
]      
      ";
      var issues = service.GetIssues(issueRepository, apiRepository);

      Assert.True(issues.Count == 1);
      Assert.True(issues[0].number == 2);
      Assert.True(issues[0].user.login == "user");
    }

    [Fact]
    public void AddIssuesTest()
    {

      var service = new IssuesService();

      apiRepository.JsonText = @"
[
    {
        ""number"": 2,
        ""title"": ""イシュー２"",
        ""user"": {
            ""login"": ""user"",
            ""email"": ""user@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-09T04:32:49Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー２"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/2/comments"",
        ""html_url"": ""html_url/test/issues/2""
    }
]      
      ";

      service.GetIssues(issueRepository, apiRepository);


      apiRepository.JsonText = @"
[
    {
        ""number"": 2,
        ""title"": ""イシュー２"",
        ""user"": {
            ""login"": ""user"",
            ""email"": ""user@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-09T04:32:49Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー２"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/2/comments"",
        ""html_url"": ""html_url/test/issues/2""
    },
    {
        ""number"": 3,
        ""title"": ""イシュー3"",
        ""user"": {
            ""login"": ""userA"",
            ""email"": ""userA@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-29T07:13:54Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー3"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/3/comments"",
        ""html_url"": ""html_url/test/issues/3""
    }
]      
      ";

      var issues = service.GetIssues(issueRepository, apiRepository);

      Assert.True(issues.Count == 1);
      Assert.True(issues[0].number == 3);
      Assert.True(issues[0].user.login == "userA");
    }

    [Fact]
    public void RemoveIssuesTest()
    {

      var service = new IssuesService();

      apiRepository.JsonText = @"
[
    {
        ""number"": 2,
        ""title"": ""イシュー２"",
        ""user"": {
            ""login"": ""user"",
            ""email"": ""user@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-09T04:32:49Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー２"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/2/comments"",
        ""html_url"": ""html_url/test/issues/2""
    }
]      
      ";

      service.GetIssues(issueRepository, apiRepository);


      apiRepository.JsonText = @"
[
    {
        ""number"": 2,
        ""title"": ""イシュー２"",
        ""user"": {
            ""login"": ""user"",
            ""email"": ""user@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""close"",
        ""created_at"": ""2020-06-09T04:32:49Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー２"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/2/comments"",
        ""html_url"": ""html_url/test/issues/2""
    },
    {
        ""number"": 3,
        ""title"": ""イシュー3"",
        ""user"": {
            ""login"": ""userA"",
            ""email"": ""userA@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""close"",
        ""created_at"": ""2020-06-29T07:13:54Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー3"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/3/comments"",
        ""html_url"": ""html_url/test/issues/3""
    }
]      
      ";

      var issues = service.GetIssues(issueRepository, apiRepository);

      Assert.True(issues.Count == 0);
    }

    [Fact]
    public void AddAndModifyIssuesTest()
    {

      var service = new IssuesService();

      apiRepository.JsonText = @"
[
    {
        ""number"": 2,
        ""title"": ""イシュー２"",
        ""user"": {
            ""login"": ""user"",
            ""email"": ""user@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-09T04:32:49Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー２"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/2/comments"",
        ""html_url"": ""html_url/test/issues/2""
    }
]      
      ";

      service.GetIssues(issueRepository, apiRepository);


      apiRepository.JsonText = @"
[
    {
        ""number"": 2,
        ""title"": ""イシュー２"",
        ""user"": {
            ""login"": ""user"",
            ""email"": ""user@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-09T04:32:49Z"",
        ""updated_at"": ""2020-06-29T10:13:54Z"",
        ""body"": ""イシュー２"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/2/comments"",
        ""html_url"": ""html_url/test/issues/2""
    },
    {
        ""number"": 3,
        ""title"": ""イシュー3"",
        ""user"": {
            ""login"": ""userA"",
            ""email"": ""userA@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-29T07:13:54Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー3"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/3/comments"",
        ""html_url"": ""html_url/test/issues/3""
    }
]      
      ";

      var issues = service.GetIssues(issueRepository, apiRepository);

      Assert.True(issues.Count == 2);
      Assert.True(issues[0].number == 2);
      Assert.True(issues[0].user.login == "user");
      Assert.True(issues[1].number == 3);
      Assert.True(issues[1].user.login == "userA");
    }

    [Fact]
    public void AddAndRemoveIssuesTest()
    {

      var service = new IssuesService();

      apiRepository.JsonText = @"
[
    {
        ""number"": 2,
        ""title"": ""イシュー２"",
        ""user"": {
            ""login"": ""user"",
            ""email"": ""user@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-09T04:32:49Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー２"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/2/comments"",
        ""html_url"": ""html_url/test/issues/2""
    }
]      
      ";

      service.GetIssues(issueRepository, apiRepository);


      apiRepository.JsonText = @"
[
    {
        ""number"": 2,
        ""title"": ""イシュー２"",
        ""user"": {
            ""login"": ""user"",
            ""email"": ""user@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""close"",
        ""created_at"": ""2020-06-09T04:32:49Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー２"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/2/comments"",
        ""html_url"": ""html_url/test/issues/2""
    },
    {
        ""number"": 3,
        ""title"": ""イシュー3"",
        ""user"": {
            ""login"": ""userA"",
            ""email"": ""userA@"",
            ""type"": ""User"",
            ""site_admin"": false,
            ""created_at"": ""2020-06-05T08:59:57Z"",
            ""id"": 0,
            ""url"": ""url1"",
            ""html_url"": ""url2"",
            ""avatar_url"": ""url3""
        },
        ""labels"": [],
        ""state"": ""open"",
        ""created_at"": ""2020-06-29T07:13:54Z"",
        ""updated_at"": ""2020-06-29T07:13:54Z"",
        ""body"": ""イシュー3"",
        ""id"": 0,
        ""comments_url"": ""comments_url/issues/3/comments"",
        ""html_url"": ""html_url/test/issues/3""
    }
]      
      ";

      var issues = service.GetIssues(issueRepository, apiRepository);

      Assert.True(issues.Count == 1);
      Assert.True(issues[0].number == 3);
      Assert.True(issues[0].user.login == "userA");
    }

    [Fact]
    public void TestGitHubAPISample()
    {
      var jsonText = @"
[
  {
    ""id"": 1,
    ""node_id"": ""MDU6SXNzdWUx"",
    ""url"": ""https://api.github.com/repos/octocat/Hello-World/issues/1347"",
    ""repository_url"": ""https://api.github.com/repos/octocat/Hello-World"",
    ""labels_url"": ""https://api.github.com/repos/octocat/Hello-World/issues/1347/labels{/name}"",
    ""comments_url"": ""https://api.github.com/repos/octocat/Hello-World/issues/1347/comments"",
    ""events_url"": ""https://api.github.com/repos/octocat/Hello-World/issues/1347/events"",
    ""html_url"": ""https://github.com/octocat/Hello-World/issues/1347"",
    ""number"": 1347,
    ""state"": ""open"",
    ""title"": ""Found a bug"",
    ""body"": ""I'm having a problem with this."",
    ""user"": {
      ""login"": ""octocatA"",
      ""id"": 1,
      ""node_id"": ""MDQ6VXNlcjE="",
      ""avatar_url"": ""https://github.com/images/error/octocat_happy.gif"",
      ""gravatar_id"": """",
      ""url"": ""https://api.github.com/users/octocat"",
      ""html_url"": ""https://github.com/octocat"",
      ""followers_url"": ""https://api.github.com/users/octocat/followers"",
      ""following_url"": ""https://api.github.com/users/octocat/following{/other_user}"",
      ""gists_url"": ""https://api.github.com/users/octocat/gists{/gist_id}"",
      ""starred_url"": ""https://api.github.com/users/octocat/starred{/owner}{/repo}"",
      ""subscriptions_url"": ""https://api.github.com/users/octocat/subscriptions"",
      ""organizations_url"": ""https://api.github.com/users/octocat/orgs"",
      ""repos_url"": ""https://api.github.com/users/octocat/repos"",
      ""events_url"": ""https://api.github.com/users/octocat/events{/privacy}"",
      ""received_events_url"": ""https://api.github.com/users/octocat/received_events"",
      ""type"": ""User"",
      ""site_admin"": false
    },
    ""labels"": [
      {
        ""id"": 208045946,
        ""node_id"": ""MDU6TGFiZWwyMDgwNDU5NDY="",
        ""url"": ""https://api.github.com/repos/octocat/Hello-World/labels/bug"",
        ""name"": ""bug"",
        ""description"": ""Something isn't working"",
        ""color"": ""f29513"",
        ""default"": true
      }
    ],
    ""assignee"": {
      ""login"": ""octocat"",
      ""id"": 1,
      ""node_id"": ""MDQ6VXNlcjE="",
      ""avatar_url"": ""https://github.com/images/error/octocat_happy.gif"",
      ""gravatar_id"": """",
      ""url"": ""https://api.github.com/users/octocat"",
      ""html_url"": ""https://github.com/octocat"",
      ""followers_url"": ""https://api.github.com/users/octocat/followers"",
      ""following_url"": ""https://api.github.com/users/octocat/following{/other_user}"",
      ""gists_url"": ""https://api.github.com/users/octocat/gists{/gist_id}"",
      ""starred_url"": ""https://api.github.com/users/octocat/starred{/owner}{/repo}"",
      ""subscriptions_url"": ""https://api.github.com/users/octocat/subscriptions"",
      ""organizations_url"": ""https://api.github.com/users/octocat/orgs"",
      ""repos_url"": ""https://api.github.com/users/octocat/repos"",
      ""events_url"": ""https://api.github.com/users/octocat/events{/privacy}"",
      ""received_events_url"": ""https://api.github.com/users/octocat/received_events"",
      ""type"": ""User"",
      ""site_admin"": false
    },
    ""assignees"": [
      {
        ""login"": ""octocat"",
        ""id"": 1,
        ""node_id"": ""MDQ6VXNlcjE="",
        ""avatar_url"": ""https://github.com/images/error/octocat_happy.gif"",
        ""gravatar_id"": """",
        ""url"": ""https://api.github.com/users/octocat"",
        ""html_url"": ""https://github.com/octocat"",
        ""followers_url"": ""https://api.github.com/users/octocat/followers"",
        ""following_url"": ""https://api.github.com/users/octocat/following{/other_user}"",
        ""gists_url"": ""https://api.github.com/users/octocat/gists{/gist_id}"",
        ""starred_url"": ""https://api.github.com/users/octocat/starred{/owner}{/repo}"",
        ""subscriptions_url"": ""https://api.github.com/users/octocat/subscriptions"",
        ""organizations_url"": ""https://api.github.com/users/octocat/orgs"",
        ""repos_url"": ""https://api.github.com/users/octocat/repos"",
        ""events_url"": ""https://api.github.com/users/octocat/events{/privacy}"",
        ""received_events_url"": ""https://api.github.com/users/octocat/received_events"",
        ""type"": ""User"",
        ""site_admin"": false
      }
    ],
    ""milestone"": {
      ""url"": ""https://api.github.com/repos/octocat/Hello-World/milestones/1"",
      ""html_url"": ""https://github.com/octocat/Hello-World/milestones/v1.0"",
      ""labels_url"": ""https://api.github.com/repos/octocat/Hello-World/milestones/1/labels"",
      ""id"": 1002604,
      ""node_id"": ""MDk6TWlsZXN0b25lMTAwMjYwNA=="",
      ""number"": 1,
      ""state"": ""open"",
      ""title"": ""v1.0"",
      ""description"": ""Tracking milestone for version 1.0"",
      ""creator"": {
        ""login"": ""octocat"",
        ""id"": 1,
        ""node_id"": ""MDQ6VXNlcjE="",
        ""avatar_url"": ""https://github.com/images/error/octocat_happy.gif"",
        ""gravatar_id"": """",
        ""url"": ""https://api.github.com/users/octocat"",
        ""html_url"": ""https://github.com/octocat"",
        ""followers_url"": ""https://api.github.com/users/octocat/followers"",
        ""following_url"": ""https://api.github.com/users/octocat/following{/other_user}"",
        ""gists_url"": ""https://api.github.com/users/octocat/gists{/gist_id}"",
        ""starred_url"": ""https://api.github.com/users/octocat/starred{/owner}{/repo}"",
        ""subscriptions_url"": ""https://api.github.com/users/octocat/subscriptions"",
        ""organizations_url"": ""https://api.github.com/users/octocat/orgs"",
        ""repos_url"": ""https://api.github.com/users/octocat/repos"",
        ""events_url"": ""https://api.github.com/users/octocat/events{/privacy}"",
        ""received_events_url"": ""https://api.github.com/users/octocat/received_events"",
        ""type"": ""User"",
        ""site_admin"": false
      },
      ""open_issues"": 4,
      ""closed_issues"": 8,
      ""created_at"": ""2011-04-10T20:09:31Z"",
      ""updated_at"": ""2014-03-03T18:58:10Z"",
      ""closed_at"": ""2013-02-12T13:22:01Z"",
      ""due_on"": ""2012-10-09T23:39:01Z""
    },
    ""locked"": true,
    ""active_lock_reason"": ""too heated"",
    ""comments"": 0,
    ""pull_request"": {
      ""url"": ""https://api.github.com/repos/octocat/Hello-World/pulls/1347"",
      ""html_url"": ""https://github.com/octocat/Hello-World/pull/1347"",
      ""diff_url"": ""https://github.com/octocat/Hello-World/pull/1347.diff"",
      ""patch_url"": ""https://github.com/octocat/Hello-World/pull/1347.patch""
    },
    ""closed_at"": null,
    ""created_at"": ""2011-04-22T13:33:48Z"",
    ""updated_at"": ""2011-04-22T13:33:48Z""
  }
]    
      ";

      var issues = JsonSerializer.Deserialize<List<IssueEntity>>(jsonText);

      Assert.True(issues.Count == 1);
      Assert.True(issues[0].number == 1347);
      Assert.True(issues[0].user.login == "octocatA");
    }
  }
}
