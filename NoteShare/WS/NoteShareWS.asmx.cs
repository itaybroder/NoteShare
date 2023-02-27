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

        [WebMethod]
        public List<NotebookWS> GetAllNotebooks()
        {
            List<NotebookTbl> notebooks = NotebookTbl.getAllNotebooks();
            return notebooks.Select(x=> new NotebookWS(x)).ToList();
        }

       
        [WebMethod]
        public NotebookWS GetNotebookById(int id)
        {
            NotebookWS notebook = new NotebookWS(NotebookTbl.getNotebookByNotebookID(id));
            return notebook;
        }

        [WebMethod]
        public UserWS GetUserFromNotebook(NotebookWS notebook)
        {
            return new UserWS(UserTbl.GetUserByUserId(notebook.UserId));
        }

        [WebMethod]
        public void LikeNotebook(NotebookWS notebook)
        {
            //24 is a user which allows anonymos likes and comments.
            NotebookTbl notebookTbl = new NotebookTbl(notebook);
            notebookTbl.Like(new UserTbl(24));
        }

        [WebMethod]
        public void UnLikeNotebook(NotebookWS notebook)
        {
            //24 is a user which allows anonymos likes and comments.
            NotebookTbl notebookTbl = new NotebookTbl(notebook);
            List<LikeTbl> likes = notebookTbl.GetAllLikes();
            
            if(likes.Count > 0)
            {
                LikeTbl.UnLikeByLikeId(likes.First().LikeId);
            }
        }

        [WebMethod]
        public void CommentOnNotebook(string comment, NotebookWS notebook)
        {
            //24 is a user which allows anonymos likes and comments.
            NotebookTbl notebookTbl = new NotebookTbl(notebook);
            notebookTbl.AddComment(new UserTbl(24), comment);
        }

        [WebMethod]
        public List<CommentWS> GetCommentsOfNotebook(NotebookWS notebook)
        {
            List<CommentTbl> comments = CommentTbl.GetCommentsByNotebookId(notebook.NotebookId);
            return comments.Select(x => new CommentWS(x)).ToList();
        }

        [WebMethod]
        public string GetSubjectById(int subjectId)
        {
            return SubjectTbl.GetSubjectByID(subjectId).Name;
        }

        [WebMethod]
        public int GetLikeCount(NotebookWS notebook)
        {
            NotebookTbl notebookTbl = new NotebookTbl(notebook);
            return notebookTbl.GetLikeCount();
        }

    }
}
