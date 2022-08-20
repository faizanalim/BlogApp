using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Model
{
    public class SQ1APIBlog
    {
        [JsonProperty("title")]
        string Title { get; set; }
        [JsonProperty("description")]
        string Description { get; set; }
        [JsonProperty("publication_date")]
        string PublicationDate { get; set; }
    }
    public class SQ1APIBlogData
    {
        public List<SQ1APIBlog> Data { get; set; }
    }
}
