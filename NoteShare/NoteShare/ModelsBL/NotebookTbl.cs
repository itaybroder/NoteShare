using Castle.Components.DictionaryAdapter.Xml;
using NoteShare.ModelsBL;
using System;
using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    /// <summary>
    /// A class that represents the NotebookTbl table in the database.
    /// </summary>
    public partial class NotebookTbl
    {
        /// <summary>
        /// A database context object.
        /// </summary>
        public static NoteShareContext db = new NoteShareContext();

        /// <summary>
        /// a copy constructor that copys NotebookWS to NotebookTBl object.
        /// </summary>
        /// <param name="notebook"></param>
        public NotebookTbl(NotebookWS notebook)
       {
            this.NotebookId = notebook.NotebookId;
            this.UserId = notebook.UserId;
            this.Title = notebook.Title;
            this.Description = notebook.Description;
            this.Color = notebook.Color;
            this.Format = notebook.Format;
            this.Path = notebook.Path;
            this.CreatedDate = notebook.CreatedDate;
            this.UpdateDate = notebook.UpdateDate;
            this.Accessibility = notebook.Accessibility;
            this.SchoolId = notebook.SchoolId;
            this.SubjectId = notebook.SubjectId;
            this.OnlineNotebookFormat = notebook.OnlineNotebookFormat;
            this.SubjectId = notebook.SubjectId;
       }

        public NotebookTbl()
        {

        }

        /// <summary>
        /// Creates a notebook with all the properties, then returns it.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="color"></param>
        /// <param name="format"></param>
        /// <param name="path"></param>
        /// <param name="accessibility"></param>
        /// <param name="schoolId"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static NotebookTbl CreateNewNotebook(int userId, string title, string description, string color, string format, string path, string accessibility, int schoolId, string subject)
        {
            NoteShareContext db = new NoteShareContext();
            NotebookTbl notebook = new NotebookTbl();
            {
                notebook.UserId = userId;
                notebook.Title = title;
                notebook.Description = description;
                notebook.Color = color;
                notebook.Format = format;
                notebook.Path = path;
                notebook.UpdateDate = DateTime.Now;
                notebook.CreatedDate = DateTime.Now;
                notebook.Accessibility = accessibility;
                if(SchoolTbl.GetSchoolByID(schoolId) != null)
                {
                    notebook.SchoolId = schoolId;
                }
                
                notebook.SubjectId = SubjectTbl.GetSubjectByName(subject).SubjectId;
            }
            db.Entry(notebook).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            db.SaveChanges();
            return notebook;
        }

        /// <summary>
        /// Updates Notebook.
        /// </summary>
        /// <param name="notebookId"></param>
        /// <param name="userId"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="color"></param>
        /// <param name="format"></param>
        /// <param name="path"></param>
        /// <param name="accessibility"></param>
        /// <param name="schoolId"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static NotebookTbl UpdateNotebook(int notebookId, int userId, string title, string description, string color, string format, string path, string accessibility, int schoolId, string subject)
        {
            NotebookTbl notebook = GetNotebookByNotebookID(notebookId);

            notebook.UserId = userId;
            notebook.Title = title;
            notebook.Description = description;
            notebook.Color = color;
            notebook.Format = format;
            notebook.Path = path;
            notebook.UpdateDate = DateTime.Now;
            notebook.Accessibility = accessibility;
            if (SchoolTbl.GetSchoolByID(schoolId) != null)
            {
                notebook.SchoolId = schoolId;
            }
            notebook.SubjectId = SubjectTbl.GetSubjectByName(subject).SubjectId;
            db.Update(notebook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return notebook;
        }

        /// <summary>
        /// A class function for updating this notebook.
        /// </summary>
        /// <param name="notebookId"></param>
        /// <param name="userId"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="color"></param>
        /// <param name="format"></param>
        /// <param name="path"></param>
        /// <param name="accessibility"></param>
        /// <param name="schoolId"></param>
        /// <param name="subject"></param>
        public void Update(int notebookId, int userId, string title, string description, string color, string format, string path, string accessibility, int schoolId, string subject)
        {
            this.UserId = userId;
            this.Title = title;
            this.Description = description;
            this.Color = color;
            this.Format = format;
            this.Path = path;
            this.UpdateDate = DateTime.Now;
            this.Accessibility = accessibility;
            this.SchoolId = schoolId;
            this.SubjectId = SubjectTbl.GetSubjectByName(subject).SubjectId;
            db.Update(this).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
      
        /// <summary>
        /// Returns a list of notebooks by Description.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static List<NotebookTbl> getNotebooksByDescription(string text)
        {
            return db.NotebookTbl.ToList().FindAll(x => x.Description.Contains(text));
        }

        /// <summary>
        /// Returns a list of notebooks by a certain school.
        /// </summary>
        /// <param name="SchoolId"></param>
        /// <returns></returns>
        public static List<NotebookTbl> getNotebooksFromSchoolId(int SchoolId)
        {
            NoteShareContext db = new NoteShareContext();
            return db.NotebookTbl.ToList().FindAll(x => x.SchoolId == SchoolId);
        }

        /// <summary>
        /// Returns a list of all the notebooks.
        /// </summary>
        /// <returns></returns>
        public static List<NotebookTbl> getAllNotebooks()
        {
            NoteShareContext db = new NoteShareContext();
            return db.NotebookTbl.ToList();
        }

        /// <summary>
        /// Returns a notebook selected from an existing list and variable.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="var"></param>
        /// <returns></returns>
        public static List<NotebookTbl> getNotebooksFromListAndVar(List<NotebookTbl> list, int index, string var)
        {
            List<NotebookTbl> notebooks = new List<NotebookTbl>();
            if (index == 0)//אם מחפשים לפי שם
            {
                foreach (NotebookTbl notebook in list)
                {
                    if (UserTbl.GetUserByUserId(notebook.UserId).Username.StartsWith(var))
                        notebooks.Add(notebook);
                }
            }
            if (index == 1)//אם מחפשים לפי מקצוע
            {
                foreach (NotebookTbl notebook in list)
                {
                    if (SubjectTbl.GetSubjectByID(notebook.SubjectId).Name == var)
                        notebooks.Add(notebook);
                }
            }

            if (index == 2)//אם מחפשים לפי בית ספר
            {
                foreach (NotebookTbl notebook in list)
                {
                    if (SchoolTbl.GetSchoolByID((int)notebook.SchoolId) != null && SchoolTbl.GetSchoolByID((int)notebook.SchoolId).Name == var)
                        notebooks.Add(notebook);
                }
            }
            if (index == 3)//אם מחפשים לפי תיאור
            {
                foreach (NotebookTbl notebook in list)
                {
                    if (notebook.Description.Contains(var))
                        notebooks.Add(notebook);
                }
            }
            return notebooks;

        }

        /// <summary>
        /// Updates the path property of a notebook.
        /// </summary>
        /// <param name="notebook"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static NotebookTbl UpdatePath(NotebookTbl notebook, string path)
        {
            notebook.Path = path;

            db.Update(notebook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return notebook;
        }

        /// <summary>
        /// Returns a notebook list of a certain user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<NotebookTbl> GetNotebooksByUserID(int userId)
        {
            return db.NotebookTbl.ToList().FindAll(x => x.UserId == userId);
        }

        /// <summary>
        /// Returns a notebook list from a certain school.
        /// </summary>
        /// <param name="schoolName"></param>
        /// <returns></returns>
        public static List<NotebookTbl> GetNotebooksBySchool(string schoolName)
        {
            SchoolTbl school = SchoolTbl.GetSchoolByName(schoolName);
            return db.NotebookTbl.ToList().FindAll(x => x.SchoolId == school.SchoolId);
        }

        /// <summary>
        /// Returns a list of notebooks by a certain subject.
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static List<NotebookTbl> GetNotebooksBySubject(string subject)
        {
            return db.NotebookTbl.ToList().FindAll(x => SubjectTbl.GetSubjectByID(x.SubjectId).Name == subject);
        }

        /// <summary>
        /// Returns a list of notebooks by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<NotebookTbl> GetNotebooksByUsername(string username)
        {
            if (UserTbl.GetUserByUsername(username) == null)
            {
                return null;
            }
            return db.NotebookTbl.ToList().FindAll(x => x.UserId == UserTbl.GetUserByUsername(username).UserId);
        }

        /// <summary>
        /// Returns all the public notebooks by username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<NotebookTbl> GetPublicNotebooksByUsername(string username)
        {
            return GetNotebooksByUsername(username).FindAll(x => x.Accessibility == "public");
        }

        /// <summary>
        /// Returns a list of notebooks by a certain subject and username.
        /// </summary>
        /// <param name="notebookID"></param>
        /// <returns></returns>
        public static NotebookTbl GetNotebookByNotebookID(int notebookID)
        {
            return db.NotebookTbl.ToList().Find(x => x.NotebookId == notebookID);
        }

        /// <summary>
        /// Returns a list of notebooks by a certain subject and username.
        /// </summary>
        public void DeleteNotebook()
        {
            DeleteAllLikes();
            NoteShareContext db = new NoteShareContext();
            db.Remove(this).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }
       


        /// <summary>
        /// Update this noteook's html.
        /// </summary>
        /// <param name="notebookHtmlText"></param>
        /// <param name="notebook"></param>
        /// <returns></returns>
        public static NotebookTbl UpdateNotebookHtml(string notebookHtmlText, NotebookTbl notebook)
        {
            notebook.OnlineNotebookFormat = notebookHtmlText;
            db.Update(notebook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return notebook; 
        }

        /// <summary>
        /// A function that Updates this notebook's html.
        /// </summary>
        /// <param name="notebookHtmlText"></param>
        /// <returns></returns>
        public void UpdateNotebookHtml(string notebookHtmlText)
        {
            UpdateNotebookHtml(notebookHtmlText, this);
        }

        /// <summary>
        /// Returns the number of notebooks of a certain user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetNumberOfNotebooksByUserId(int userId)
        {
            NoteShareContext db = new NoteShareContext();
            return db.NotebookTbl.ToList().FindAll(x => x.UserId == userId).Count;
        }

        /// <summary>
        ///  Checks if the notebook is owend by a user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="notebook"></param>
        /// <returns></returns>
        public static bool IsHisNotebook(UserTbl user, NotebookTbl notebook)
        {
            if (NotebookTbl.GetNotebooksByUserID(user.UserId).Contains(notebook))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// adds a comment to a notebook.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="comment"></param>
        public void AddComment(UserTbl user, string comment)
        {
            NoteShareContext db = new NoteShareContext();
            CommentTbl commentTbl = new CommentTbl();
            {
                commentTbl.NotebookId = this.NotebookId;
                commentTbl.UserId = user.UserId;
                commentTbl.Comment = comment;
                commentTbl.CreatedDate = DateTime.Now;
            }
            db.Entry(commentTbl).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            db.SaveChanges();
        }

        /// <summary>
        /// likes a notebook, adds a like to the database.
        /// </summary>
        /// <param name="user">this is the givven user</param>
        public void Like(UserTbl user)
        {
            NoteShareContext db = new NoteShareContext();
            LikeTbl like = new LikeTbl();
            {
                like.UserId = user.UserId;
                like.NotebookId = this.NotebookId;
                like.CreatedDate = DateTime.Now;
            }

            db.Entry(like).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            db.SaveChanges();
        }

        /// <summary>
        /// Unlike a notebook, removes a like from the database.
        /// </summary>
        /// <param name="user"></param>
        public void UnLike(UserTbl user)
        {
            NoteShareContext db = new NoteShareContext();
            LikeTbl like = NoteShare.Models.LikeTbl.GetAllLikes().FindAll(x => x.UserId == user.UserId && x.NotebookId == this.NotebookId).First();


            db.Remove(like).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        /// <summary>
        /// Returns the total number of likes of a notebook.
        /// </summary>
        /// <returns></returns>
        public int GetLikeCount()
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList().FindAll(x => x.NotebookId == this.NotebookId).Count;
        }

        /// <summary>
        /// Returns a list of all the likes of a notebook.
        /// </summary>
        /// <returns></returns>
        public List<LikeTbl> GetAllLikes()
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList().FindAll(x => x.NotebookId == this.NotebookId);
        }

        /// <summary>
        /// Deletes all likes of a notebook.
        /// </summary>
        public void DeleteAllLikes()
        {
            NoteShareContext db = new NoteShareContext();
            foreach (LikeTbl like in db.LikeTbl.ToList())
            {
                if (like.NotebookId == this.NotebookId)
                {
                    db.Remove(like).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    db.SaveChanges();
                }

            }
        }

        /// <summary>
        /// Returns a list of all the likes of a notebook from a user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<LikeTbl> GetLikesFromUser(UserTbl user)
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList().FindAll(x => x.NotebookId == this.NotebookId && x.UserId == user.UserId);
        }

        /// <summary>
        /// checks if a user has liked a notebook.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsLiked(int userId)
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList().Find(x => x.UserId == userId && x.NotebookId == this.NotebookId ) != null ? true : false;
        }
    }
}
