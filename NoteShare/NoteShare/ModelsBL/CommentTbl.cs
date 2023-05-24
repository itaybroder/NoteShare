using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteShare.Models
{
    /// <summary>
    /// this class is an extention of the CommentTbl class created by the scaffold command from 
    /// the database. it has functions that interacts with the Comment table.
    /// </summary>
    public partial class CommentTbl
    {
        /// <summary>
        /// Returns a list of comments by notebookID.
        /// </summary>
        /// <param name="notebookId"></param>
        /// <returns></returns>
        public static List<CommentTbl> GetCommentsByNotebookId(int notebookId)
        {
            NoteShareContext db = new NoteShareContext();
            return db.CommentTbl.ToList().FindAll(x => x.NotebookId == notebookId);
        }

        /// <summary>
        /// Deletes comment by a commentId.
        /// </summary>
        /// <param name="CommentId"></param>      
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

        /// <summary>
        /// A class function for deleting this comment.
        /// </summary>
        public void Delete()
        {
            DeleteComment(this.CommentId);
        }


        /// <summary>
        /// Returns a UserTbl object of the user that wrote a comment.
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns></returns>
        public static UserTbl GetUserThatCommented(int commentID)
        {
            NoteShareContext db = new NoteShareContext();
            return UserTbl.GetUserByUserId(db.CommentTbl.ToList().Find(x => x.CommentId == commentID).UserId);
        }

    }
}