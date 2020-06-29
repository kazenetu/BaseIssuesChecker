using Domain.Domain.Entity;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;
using Xunit;

namespace Test
{
  [Trait("テスト", nameof(TestA))]
  public class TestA
  {
    [Fact]
    public void TestSample()
    {
      var jsonText = @"
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

      var issues = JsonSerializer.Deserialize<List<IssueEntity>>(jsonText);

      Assert.True(issues.Count == 1);
      Assert.True(issues[0].number == 2);
      Assert.True(issues[0].user.login == "user");
    }
  }
}
