using System.Collections.Generic;

namespace Domain.Domain.Entity
{
    public class IssueEntity
    {
        public int number{set;get;}
        public string title{set;get;}
        public UserEntity user{set;get;}
        public List<string> labels{set;get;}
        public string state{set;get;}
        public DateTimeOffset created_at{set;get;}
        public DateTimeOffset updated_at{set;get;}
        public string body{set;get;}
        public int id{set;get;}
        public string comments_url{set;get;}
        public string html_url{set;get;}
    }
}