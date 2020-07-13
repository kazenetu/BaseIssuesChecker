using Domain.Application.Model;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using Xunit;
using Test.Repository;
using Domain.Domain.Service;
using Domain.Application;

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

      var application = new IssuesApplication();


      var issues = application.GetIssues(issueRepository, apiRepository);

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

      var appplication = new IssuesApplication();

      appplication.GetIssues(issueRepository, apiRepository);

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
      var issues = appplication.GetIssues(issueRepository, apiRepository);

      Assert.True(issues.Count == 1);
      Assert.True(issues[0].number == 2);
      Assert.True(issues[0].user.login == "user");
    }

    [Fact]
    public void AddIssuesTest()
    {

      var application = new IssuesApplication();

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

      application.GetIssues(issueRepository, apiRepository);


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

      var issues = application.GetIssues(issueRepository, apiRepository);

      Assert.True(issues.Count == 1);
      Assert.True(issues[0].number == 3);
      Assert.True(issues[0].user.login == "userA");
    }

    [Fact]
    public void RemoveIssuesTest()
    {

      var application = new IssuesApplication();

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

      application.GetIssues(issueRepository, apiRepository);


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

      var issues = application.GetIssues(issueRepository, apiRepository);

      Assert.True(issues.Count == 0);
    }

    [Fact]
    public void AddAndModifyIssuesTest()
    {

      var application = new IssuesApplication();

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

      application.GetIssues(issueRepository, apiRepository);


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

      var issues = application.GetIssues(issueRepository, apiRepository);

      Assert.True(issues.Count == 2);
      Assert.True(issues[0].number == 2);
      Assert.True(issues[0].user.login == "user");
      Assert.True(issues[1].number == 3);
      Assert.True(issues[1].user.login == "userA");
    }

    [Fact]
    public void AddAndRemoveIssuesTest()
    {

      var application = new IssuesApplication();

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

      application.GetIssues(issueRepository, apiRepository);


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

      var issues = application.GetIssues(issueRepository, apiRepository);

      Assert.True(issues.Count == 1);
      Assert.True(issues[0].number == 3);
      Assert.True(issues[0].user.login == "userA");
    }

  }
}