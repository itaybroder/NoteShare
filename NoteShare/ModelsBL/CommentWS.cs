using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteShare.ModelsBL
{
    public class CommentWS
    {
        public CommentWS(int userId, int notebookId, string comment, DateTime createdDate, int commentId)
        {
            UserId = userId;
            NotebookId = notebookId;
            Comment = comment;
            CreatedDate = createdDate;
            CommentId = commentId;
        }
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