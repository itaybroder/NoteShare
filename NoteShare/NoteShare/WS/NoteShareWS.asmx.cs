using NoteShare.Models;
using NoteShare.ModelsBL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
namespace NoteShare.WS
{
    /// <summary>
    /// Summary description for NoteShareWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NoteShareWS : System.Web.Services.WebService
    {
        /// <summary>
        /// Returns all the notebooks.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<NotebookWS> GetAllNotebooks()
        {
            List<NotebookTbl> notebooks = NotebookTbl.getAllNotebooks();
            return notebooks.Select(x=> new NotebookWS(x)).ToList();
        }

       /// <summary>
       /// Returns a notebook by id.
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [WebMethod]
        public NotebookWS GetNotebookById(int id)
        {
            NotebookWS notebook = new NotebookWS(NotebookTbl.GetNotebookByNotebookID(id));
            return notebook;
        }

        /// <summary>
        /// returns the user that owns the notebook.
        /// </summary>
        /// <param name="notebook"></param>
        /// <returns></returns>
        [WebMethod]
        public UserWS GetUserFromNotebook(NotebookWS notebook)
        {
            return new UserWS(UserTbl.GetUserByUserId(notebook.UserId));
        }

        /// <summary>
        /// Likes a notebook.
        /// </summary>
        /// <param name="notebook"></param>
        [WebMethod]
        public void LikeNotebook(NotebookWS notebook)
        {
            //24 is a user which allows anonymos likes and comments.
            NotebookTbl notebookTbl = new NotebookTbl(notebook);
            notebookTbl.Like(new UserTbl(24));
        }

        /// <summary>
        /// Unlikes a notebook.
        /// </summary>
        /// <param name="notebook"></param>
        [WebMethod]
        public void UnLikeNotebook(NotebookWS notebook)
        {
            //24 is a user which allows anonymos likes and comments.
            NotebookTbl notebookTbl = new NotebookTbl(notebook);
            List<LikeTbl> likes = notebookTbl.GetAllLikes();
            
            if(likes.Count > 0)
            {
                likes.First().UnLike();
            }
        }

        /// <summary>
        /// Adds a comment to a notebook.
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="notebook"></param>
        [WebMethod]
        public void CommentOnNotebook(string comment, NotebookWS notebook)
        {
            //24 is a user which allows anonymos likes and comments.
            NotebookTbl notebookTbl = new NotebookTbl(notebook);
            notebookTbl.AddComment(new UserTbl(24), comment);
        }

        /// <summary>
        /// Returns all the comments of a notebook.
        /// </summary>
        /// <param name="notebook"></param>
        /// <returns></returns>
        [WebMethod]
        public List<CommentWS> GetCommentsOfNotebook(NotebookWS notebook)
        {
            List<CommentTbl> comments = CommentTbl.GetCommentsByNotebookId(notebook.NotebookId);
            return comments.Select(x => new CommentWS(x)).ToList();
        }

        /// <summary>
        /// returns a subject by a subject Id.
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetSubjectById(int subjectId)
        {
            return SubjectTbl.GetSubjectByID(subjectId).Name;
        }

        /// <summary>
        /// Returns the like count of a notebook.
        /// </summary>
        /// <param name="notebook"></param>
        /// <returns></returns>
        [WebMethod]
        public int GetLikeCount(NotebookWS notebook)
        {
            NotebookTbl notebookTbl = new NotebookTbl(notebook);
            return notebookTbl.GetLikeCount();
        }

    }
}
