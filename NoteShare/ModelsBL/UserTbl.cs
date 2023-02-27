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

        //public static UserTbl UpdateUser(int userId, string permission, string username, string password, string firstName, string LastName, DateTime birthday, List<SchoolTbl> schools, string address)
        //{
        //    NoteShareContext db = new NoteShareContext();
        //    if (GetUserByUsername(username) == null || GetUserByUsername(username).Username == username)
        //    {
        //        UserTbl user = new UserTbl();
        //        {
        //            user.UserId = userId;
        //            user.Username = username;
        //            user.Password = password;
        //            user.FirstName = firstName;
        //            user.LastName = LastName;
        //            user.Birthday = birthday;

        //            user.Permission = permission;
        //            user.Address = address;
        //        }
        //        db.Update(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        db.SaveChanges();

        //        foreach (SchoolTbl school in schools)
        //        {
        //            UserInSchoolTbl userInSchool = new UserInSchoolTbl();
        //            {
        //                userInSchool.UserId = user.UserId;
        //                userInSchool.SchoolId = school.SchoolId;
        //            }
        //            db.Update(userInSchool).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        }
        //        db.SaveChanges();
        //        return user;
        //    }

        //    return null;
        //}

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
                    UserInSchoolTbl userInSchool = new UserInSchoolTbl();
                    {
                        userInSchool.UserId = user.UserId;
                        userInSchool.SchoolId = school.SchoolId;
                    }
                    db.Update(userInSchool).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                db.SaveChanges();
            }
        }


        public static UserTbl GetUserByUsername(string username)
        {
            NoteShareContext db = new NoteShareContext();
            return db.UserTbl.ToList().Find(x => x.Username == username);
        }

        public static UserTbl GetUserByUserId(int id)
        {
            NoteShareContext db = new NoteShareContext();
            return db.UserTbl.ToList().Find(x => x.UserId == id);
        }


        public static List<UserTbl> GetAllUsers()
        {
            NoteShareContext db = new NoteShareContext();
            return db.UserTbl.ToList();
        }

        public void DeleteAllComments()
        {
            NoteShareContext db = new NoteShareContext();
            foreach (CommentTbl comment in db.CommentTbl.ToList().FindAll(x => x.UserId == this.UserId))
            {
                NoteShare.Models.CommentTbl.DeleteComment(comment.CommentId);
            }
        }
        public void DeleteAllNotebooks()
        {
            foreach (NotebookTbl notebook in NotebookTbl.getNotebooksByUserID(this.UserId))
            {
                notebook.DeleteNotebook();
            }
        }
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

        public void DeleteAllLikes()
        {
            NoteShareContext db = new NoteShareContext();
            foreach (LikeTbl like in db.LikeTbl.ToList().FindAll(x => x.UserId == this.UserId))
            {

                db.Remove(like).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();


            }
        }

        public List<NotebookTbl> GetLikedNotebooks()
        {
            NoteShareContext db = new NoteShareContext();
            List<LikeTbl> likes = db.LikeTbl.ToList().FindAll(x => x.UserId == this.UserId);
            List<NotebookTbl> notebooks = new List<NotebookTbl>();
            foreach (LikeTbl like in likes)
            {
                notebooks.Add(NotebookTbl.getNotebookByNotebookID(like.NotebookId));
            }

            return notebooks;
        }
    }
}
