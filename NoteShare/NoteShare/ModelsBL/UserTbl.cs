using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteShare.Models
{
    /// <summary>
    /// A class that represents a user in the database.
    /// </summary>
    public partial class UserTbl
    {

        /// <summary>
        /// Login a user with username and password. Then returns the loged in user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static UserTbl UserLogin(string username, string pass)
        {
            NoteShareContext db = new NoteShareContext();
            try
            {
                return db.UserTbl.ToList().Find(x => x.Username == username && x.Password == pass);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }


        /// <summary>
        /// Registers a user. Returning the new user.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="LastName"></param>
        /// <param name="birthday"></param>
        /// <param name="schools"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static UserTbl Register(string username, string password, string firstName, string LastName, DateTime birthday, List<SchoolTbl> schools, string address)
        {
            NoteShareContext db = new NoteShareContext();
            if (GetUserByUsername(username) == null)
            {
                UserTbl user = new UserTbl();
                {
                    user.Username = username;
                    user.Password = password;
                    user.FirstName = firstName;
                    user.LastName = LastName;
                    user.Birthday = birthday;


                    user.Address = address;
                    user.Permission = "user";
                }
                db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                db.SaveChanges();

                foreach (SchoolTbl school in schools)
                {
                    UserInSchoolTbl userInSchool = new UserInSchoolTbl();
                    {
                        userInSchool.UserId = user.UserId;
                        userInSchool.SchoolId = school.SchoolId;
                    }
                    db.Entry(userInSchool).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
                db.SaveChanges();
                return user;
            }

            return null;
        }

        /// <summary>
        /// Updates user with properties.
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="LastName"></param>
        /// <param name="birthday"></param>
        /// <param name="schools"></param>
        /// <param name="address"></param>
        public void UpdateUser(string permission, string username, string password, string firstName, string LastName, DateTime birthday, List<SchoolTbl> schools, string address)
        {
            NoteShareContext db = new NoteShareContext();
            if (GetUserByUsername(username) == null || GetUserByUsername(username).Username == username)
            {
                UserTbl user = new UserTbl();
                {
                    user.UserId = this.UserId;
                    user.Username = username;
                    user.Password = password;
                    user.FirstName = firstName;
                    user.LastName = LastName;
                    user.Birthday = birthday;
                    user.Permission = permission;
                    user.Address = address;
                }
                db.Update(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();


                foreach (SchoolTbl school in schools)
                {

                    NoteShare.Models.UserInSchoolTbl.AddUserInSchool(school.SchoolId, UserId);
                }
       
            }
        }

        /// <summary>
        /// Returns a user by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static UserTbl GetUserByUsername(string username)
        {
            NoteShareContext db = new NoteShareContext();
            return db.UserTbl.ToList().Find(x => x.Username == username);
        }

        /// <summary>
        /// Returns a user by userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserTbl GetUserByUserId(int id)
        {
            NoteShareContext db = new NoteShareContext();
            return db.UserTbl.ToList().Find(x => x.UserId == id);
        }

        /// <summary>
        /// Returns a list of all the users.
        /// </summary>
        /// <returns></returns>
        public static List<UserTbl> GetAllUsers()
        {
            NoteShareContext db = new NoteShareContext();
            return db.UserTbl.ToList();
        }

        /// <summary>
        /// Deletes all Comments from the notebook.
        /// </summary>
        public void DeleteAllComments()
        {
            NoteShareContext db = new NoteShareContext();
            foreach (CommentTbl comment in db.CommentTbl.ToList().FindAll(x => x.UserId == this.UserId))
            {
                comment.Delete();
            }
        }

        /// <summary>
        /// Deletes All the notebooks that the user of this notebooks wrote.
        /// </summary>
        public void DeleteAllNotebooks()
        {
            foreach (NotebookTbl notebook in NoteShare.Models.NotebookTbl.GetNotebooksByUserID(this.UserId))
            {
                notebook.DeleteNotebook();
            }
        }

        /// <summary>
        /// Deletes a user from the database.
        /// </summary>
        public void Delete()
        {
            DeleteAllLikes();
            DeleteAllComments();
            DeleteAllNotebooks();
            
            NoteShareContext db = new NoteShareContext();
            NoteShare.Models.UserInSchoolTbl.DeleteUserInSchool(this.UserId);
            UserTbl user = new UserTbl();
            {
                user.UserId = this.UserId;
            }
            db.Remove(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        /// <summary>
        /// Deletes all likes from user.
        /// </summary>
        public void DeleteAllLikes()
        {
            NoteShareContext db = new NoteShareContext();
            foreach (LikeTbl like in db.LikeTbl.ToList().FindAll(x => x.UserId == this.UserId))
            {

                db.Remove(like).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();


            }
        }

        /// <summary>
        /// Gets all the liked notebooks of the user.
        /// </summary>
        /// <returns></returns>
        public List<NotebookTbl> GetLikedNotebooks()
        {
            NoteShareContext db = new NoteShareContext();
            List<LikeTbl> likes = db.LikeTbl.ToList().FindAll(x => x.UserId == this.UserId);
            List<NotebookTbl> notebooks = new List<NotebookTbl>();
            foreach (LikeTbl like in likes)
            {
                notebooks.Add(NoteShare.Models.NotebookTbl.GetNotebookByNotebookID(like.NotebookId));
            }

            return notebooks;
        }
    }
}
