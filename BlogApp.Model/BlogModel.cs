using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Model
{
    public class BlogModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public DateTime? PublishedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string ContentShort
        {
            get
            {
                return string.IsNullOrWhiteSpace(Content)  || Content.Length <= 100 ? Content : Content.Substring(0, 100);
            }
        }

    }
}
