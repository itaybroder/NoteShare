using RamonSchool.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RamonSchool
{
    public partial class ViewNotebook : System.Web.UI.Page
    {
        /// <summary>
        /// A static instance of the notebook to be used in the page.
        /// </summary>
        public static NotebookWS notebook;
        protected void Page_Load(object sender, EventArgs e)
        {
            //loadinng a noteShareWS instance
            NoteShareWS context = new NoteShareWS();
            if (!IsPostBack)
            {
                //get the id from the url
                string desiredValue = "";
                foreach (string item in HttpContext.Current.Request.Url.Query.Split('&'))
                {
                    string[] parts = item.Replace("?", "").Split('=');
                    if (parts[0] == "id")
                    {
                        desiredValue = parts[1];
                        break;
                    }
                }
                //update mode
                if (desiredValue != "")
                {
                    // get the notebook by id
                    notebook = context.GetNotebookById((Int32.Parse(desiredValue)));
                    NoteTitle.Text = notebook.Title;
                    DescriptionLabel.Text = notebook.Description;
                    DateLBL.Text = notebook.UpdateDate.ToString("dd/MM/yyyy");
                    CantEditDiv.InnerHtml = notebook.OnlineNotebookFormat;

                    NotebookSubject.Text = context.GetSubjectById(notebook.SubjectId);

                    UserLinkl.Text = context.GetUserFromNotebook(notebook).Username;


                    // Getting the comments of the notebook
                    CommentWS[] commentsArray = context.GetCommentsOfNotebook(notebook);
                    List<CommentWS> comments = new List<CommentWS>();
                    foreach (CommentWS comment in commentsArray)
                    {
                        comments.Add(comment);
                    }

                    comments.Reverse();
                    CommentsDataList.DataSource = comments;
                    CommentsDataList.DataBind();
                }


            }
            //Getting the like count of the notebook
            LikeCountLabel.Text = "" + context.GetLikeCount(notebook);
        }

        /// <summary>
        /// When liked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LikeButton_Click(object sender, ImageClickEventArgs e)
        {
            NoteShareWS context = new NoteShareWS();
            if (LikeButton.ImageUrl == "./Assets/LikeBefore.png")
            {
               //like
                context.LikeNotebook(notebook);
                LikeButton.ImageUrl = "./Assets/LikeAfter.png";
            }
            else
            {
                //unlike
                context.UnLikeNotebook(notebook);
                LikeButton.ImageUrl = "./Assets/LikeBefore.png";
            }
            LikeCountLabel.Text = "" + context.GetLikeCount(notebook);
        }

        /// <summary>
        /// Adding a comment to the notebook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddCommentBTN_Click(object sender, EventArgs e)
        {
            NoteShareWS context = new NoteShareWS();
            string comment = CommentTextBox.Text;
            context.CommentOnNotebook(comment, notebook);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}