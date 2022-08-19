using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DAL.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publication_Date { get; set; }
    }
}
