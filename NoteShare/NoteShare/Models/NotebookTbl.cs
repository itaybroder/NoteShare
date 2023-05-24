using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    public partial class NotebookTbl
    {
      

        public int NotebookId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Accessibility { get; set; }
        public int? SchoolId { get; set; }
        public int SubjectId { get; set; }
        public string OnlineNotebookFormat { get; set; }

        public virtual SchoolTbl School { get; set; }
        public virtual SubjectTbl Subject { get; set; }
        public virtual UserTbl User { get; set; }
        public virtual ICollection<CommentTbl> CommentTbl { get; set; }
        public virtual ICollection<LikeTbl> LikeTbl { get; set; }
    }
}
