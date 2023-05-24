using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    public partial class CommentTbl
    {
        public int UserId { get; set; }
        public int NotebookId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CommentId { get; set; }

        public virtual NotebookTbl Notebook { get; set; }
        public virtual UserTbl User { get; set; }
    }
}
