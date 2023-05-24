using System;
using System.Collections.Generic;

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
            NotebookTbl = new HashSet<NotebookTbl>();
            UserInSchoolTbl = new HashSet<UserInSchoolTbl>();
        }

        public UserTbl(int userId, string firstName, string lastName, string password, string permission, DateTime birthday, string address, string username)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Permission = permission;
            Birthday = birthday;
            Address = address;
            Username = username;
        }
        public UserTbl(int userId)
        {
            UserTbl user = UserTbl.GetUserByUserId(userId);
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            Permission = user.Permission;
            Birthday = user.Birthday;
            Address = user.Address;
            Username = user.Username;
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
        public virtual ICollection<NotebookTbl> NotebookTbl { get; set; }
        public virtual ICollection<UserInSchoolTbl> UserInSchoolTbl { get; set; }
    }
}
