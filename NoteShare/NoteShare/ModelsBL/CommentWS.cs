using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteShare.ModelsBL
{
    //This class is a copy of the CommentTbl class that can be transfered through a web service
    public class CommentWS
    {
        /// <summary>
        /// Constructor that gets all the props and initializes them.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="notebookId"></param>
        /// <param name="comment"></param>
        /// <param name="createdDate"></param>
        /// <param name="commentId"></param>
        public CommentWS(int userId, int notebookId, string comment, DateTime createdDate, int commentId)
        {
            UserId = userId;
            NotebookId = notebookId;
            Comment = comment;
            CreatedDate = createdDate;
            CommentId = commentId;
        }

        /// <summary>
        /// Copy constructor that copys a CommentTbl object to CommentWS.
        /// </summary>
        /// <param name="comment"></param>
        public CommentWS(CommentTbl comment)
        {
            UserId = comment.CommentId;
            NotebookId = comment.NotebookId;
            Comment = comment.Comment;
            CreatedDate = comment.CreatedDate;
            CommentId = comment.CommentId;
            Username = UserTbl.GetUserByUserId(comment.UserId).Username;
        }

        public CommentWS()
        {

        }

        public int UserId { get; set; }
        public int NotebookId { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CommentId { get; set; }
    }
}