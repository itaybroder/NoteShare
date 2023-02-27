using System;
using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    public partial class CommentTbl
    {
        public static List<CommentTbl> GetCommentsByNotebookId(int notebookId)
        {
            NoteShareContext db = new NoteShareContext();
            return db.CommentTbl.ToList().FindAll(x => x.NotebookId == notebookId);
        }
   

        public static void DeleteComment(int CommentId)
        {
            NoteShareContext db = new NoteShareContext();
            CommentTbl comment = new CommentTbl();
            {
                comment.CommentId = CommentId;
            }
            db.Remove(comment).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

       

        public static UserTbl GetUserThatCommented(int commentID)
        {
            NoteShareContext db = new NoteShareContext();
            return UserTbl.GetUserByUserId(db.CommentTbl.ToList().Find(x => x.CommentId == commentID).UserId);
        }

    }
}
