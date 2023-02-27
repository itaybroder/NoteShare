using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteShare.ModelsBL
{
    public class UserWS
    {
        public UserWS(int userId, string firstName, string lastName, string password, string permission, DateTime birthday, string address, string username)
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
        public UserWS(UserTbl user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            Permission = user.Permission;
            Birthday = user.Birthday;
            Address = user.Address;
            Username = user.Username;
        }

        public UserWS()
        {

        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
    }
}