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
    public partial class NotebookTbl
    {
        public static NoteShareContext db = new NoteShareContext();

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
                notebook.SchoolId = schoolId;
                notebook.SubjectId = SubjectTbl.GetSubjectByName(subject).SubjectId;
            }
            db.Entry(notebook).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            db.SaveChanges();
            return notebook;
        }

        public static NotebookTbl UpdateNotebook(int notebookId, int userId, string title, string description, string color, string format, string path, string accessibility, int schoolId, string subject)
        {
            NotebookTbl notebook = getNotebookByNotebookID(notebookId);

            notebook.UserId = userId;
            notebook.Title = title;
            notebook.Description = description;
            notebook.Color = color;
            notebook.Format = format;
            notebook.Path = path;
            notebook.UpdateDate = DateTime.Now;
            notebook.Accessibility = accessibility;
            notebook.SchoolId = schoolId;
            notebook.SubjectId = SubjectTbl.GetSubjectByName(subject).SubjectId;
            db.Update(notebook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return notebook;
        }


        public static List<NotebookTbl> getNotebooksByDescription(string text)
        {
            return db.NotebookTbl.ToList().FindAll(x => x.Description.Contains(text));
        }

        public static List<NotebookTbl> getNotebooksFromSchoolId(int SchoolId)
        {
            NoteShareContext db = new NoteShareContext();
            return db.NotebookTbl.ToList().FindAll(x => x.SchoolId == SchoolId);
        }

        public static List<NotebookTbl> getAllNotebooks()
        {
            NoteShareContext db = new NoteShareContext();
            return db.NotebookTbl.ToList();
        }

        public static List<NotebookTbl> getNotebooksFromListAndVar(List<NotebookTbl> list, int index, string var)
        {
            List<NotebookTbl> notebooks = new List<NotebookTbl>();
            if (index == 0)//אם מחפשים לפי שם
            {
                foreach (NotebookTbl notebook in list)
                {
                    if (UserTbl.GetUserByUserId(notebook.UserId).Username == var)
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
        public static NotebookTbl UpdatePath(NotebookTbl notebook, string path)
        {
            notebook.Path = path;

            db.Update(notebook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return notebook;
        }
        public static List<NotebookTbl> getNotebooksByUserID(int userId)
        {
            return db.NotebookTbl.ToList().FindAll(x => x.UserId == userId);
        }
        public static List<NotebookTbl> getNotebooksBySchool(string schoolName)
        {
            SchoolTbl school = SchoolTbl.GetSchoolByName(schoolName);
            return db.NotebookTbl.ToList().FindAll(x => x.SchoolId == school.SchoolId);
        }
        public static List<NotebookTbl> getNotebooksBySubject(string subject)
        {
            return db.NotebookTbl.ToList().FindAll(x => SubjectTbl.GetSubjectByID(x.SubjectId).Name == subject);
        }
        public static List<NotebookTbl> getNotebooksByUsername(string username)
        {
            if (UserTbl.GetUserByUsername(username) == null)
            {
                return null;
            }
            return db.NotebookTbl.ToList().FindAll(x => x.UserId == UserTbl.GetUserByUsername(username).UserId);
        }

        public static List<NotebookTbl> getPublicNotebooksByUsername(string username)
        {
            return getNotebooksByUsername(username).FindAll(x => x.Accessibility == "public");
        }

        public static NotebookTbl getNotebookByNotebookID(int notebookID)
        {
            return db.NotebookTbl.ToList().Find(x => x.NotebookId == notebookID);
        }
        public void DeleteNotebook()
        {
            DeleteAllLikes();
            NoteShareContext db = new NoteShareContext();
            db.Remove(this).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }
       

        public static NotebookTbl UpdateNotebookHtml(string notebookHtmlText, NotebookTbl notebook)
        {
            notebook.OnlineNotebookFormat = notebookHtmlText;
            db.Update(notebook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return notebook;
        }

        public static int GetNumberOfNotebooksByUserId(int userId)
        {
            NoteShareContext db = new NoteShareContext();
            return db.NotebookTbl.ToList().FindAll(x => x.UserId == userId).Count;
        }

        public static bool isHisNotebook(UserTbl user, NotebookTbl notebook)
        {
            if (NotebookTbl.getNotebooksByUserID(user.UserId).Contains(notebook))
            {
                return true;
            }
            return false;
        }

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

        public void UnLike(UserTbl user)
        {
            NoteShareContext db = new NoteShareContext();
            LikeTbl like = LikeTbl.GetAllLikes().FindAll(x => x.UserId == user.UserId && x.NotebookId == this.NotebookId).First();


            db.Remove(like).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        public int GetLikeCount()
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList().FindAll(x => x.NotebookId == this.NotebookId).Count;
        }

        public List<LikeTbl> GetAllLikes()
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList().FindAll(x => x.NotebookId == this.NotebookId);
        }

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

        public List<LikeTbl> GetLikesFromUser(UserTbl user)
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList().FindAll(x => x.NotebookId == this.NotebookId && x.UserId == user.UserId);
        }

        public bool IsLiked(int userId)
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList().Find(x => x.UserId == userId && x.NotebookId == this.NotebookId ) != null ? true : false;
        }
    }
}
