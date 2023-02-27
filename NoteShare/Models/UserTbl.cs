using System;
using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    public partial class UserTbl
    {
        public UserTbl()
        {
            CommentTbl = new HashSet<CommentTbl>();
            LikeTbl = new HashSet<LikeTbl>();
            SharedNotebookTbl = new HashSet<SharedNotebookTbl>();
            UserInSchoolTbl = new HashSet<UserInSchoolTbl>();
        }
        public UserTbl(int userId)
        {
            NoteShareContext context = new NoteShareContext();
            UserTbl user = context.UserTbl.ToList().Find(x=>x.UserId == userId);

            this.UserId = userId;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Password = user.Password;
            this.Permission = user.Permission;
            this.Birthday = user.Birthday;
            this.Address = user.Address;
            this.Username = user.Username;
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }

        public virtual ICollection<CommentTbl> CommentTbl { get; set; }
        public virtual ICollection<LikeTbl> LikeTbl { get; set; }
        public virtual ICollection<SharedNotebookTbl> SharedNotebookTbl { get; set; }
        public virtual ICollection<UserInSchoolTbl> UserInSchoolTbl { get; set; }
    }
}
