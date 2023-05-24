using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    public partial class SchoolTbl
    {
        public SchoolTbl()
        {
            NotebookTbl = new HashSet<NotebookTbl>();
            UserInSchoolTbl = new HashSet<UserInSchoolTbl>();
        }

        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        public virtual ICollection<NotebookTbl> NotebookTbl { get; set; }
        public virtual ICollection<UserInSchoolTbl> UserInSchoolTbl { get; set; }
    }
}
