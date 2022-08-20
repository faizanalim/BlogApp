using BlogApp.BAL.Interfaces;
using BlogApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BAL.Service
{
    public class APIService: IAPIService
    {

        public async Task<List<SQ1APIBlog>> GetBlogsApiData(string url)
        {
            var json = await ExecuteGet(url);
            var data = JsonConvert.DeserializeObject<SQ1APIBlogData>(json);
            return data.Data;
        }
        public async Task<string> ExecuteGet(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = response.Content;
            var str = await content.ReadAsStringAsync();
            return str;
        }

        
    }
}
