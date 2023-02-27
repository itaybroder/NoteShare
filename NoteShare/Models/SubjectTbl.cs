using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    public partial class SubjectTbl
    {
        public SubjectTbl()
        {
            NotebookTbl = new HashSet<NotebookTbl>();
        }

        public int SubjectId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NotebookTbl> NotebookTbl { get; set; }
    }
}
