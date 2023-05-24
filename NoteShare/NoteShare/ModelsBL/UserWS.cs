using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteShare.ModelsBL
{
    /// <summary>
    /// A class that represents a user in the web service.
    /// </summary>
    public class UserWS
    {
        /// <summary>
        /// A consuctor for the UserWS class.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="permission"></param>
        /// <param name="birthday"></param>
        /// <param name="address"></param>
        /// <param name="username"></param>
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
        
        /// <summary>
        /// A copy constructor for the UserWS class. Copys the values from a UserTbl object.
        /// </summary>
        /// <param name="user"></param>
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