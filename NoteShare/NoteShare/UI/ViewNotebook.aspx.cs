using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoteShare.UI
{
    public partial class ViewNotebook : System.Web.UI.Page
    {
        public static UserTbl user;
        public static NotebookTbl notebook;
        protected void Page_Load(object sender, EventArgs e)
        {
            //handling online notebook update
            //this if is called when the Save button is clicked.
                if (Request.HttpMethod == "POST")
                 {
                    var notebookHtmlText = Request.Headers.Get("mytext");
                    var notebookId = Request.Headers.Get("notebookId");
                    if (notebookId != null && notebookHtmlText != null && notebookId != "" && notebookHtmlText != "")
                    {
                        notebook = NotebookTbl.GetNotebookByNotebookID(int.Parse(notebookId));
                        notebook.UpdateNotebookHtml(notebookHtmlText);
                        CantEditDiv.InnerHtml = notebook.OnlineNotebookFormat;
                    }
                }

            if (!IsPostBack)
            {
                user = (UserTbl)Session["User"];
                if (user == null)
                {
                    Response.Redirect("login.aspx");
                    return;
                }

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
                    notebook = NotebookTbl.GetNotebookByNotebookID(Int32.Parse(desiredValue));
                    NoteTitle.Text = notebook.Title;
                    DescriptionLabel.Text = notebook.Description;
                    DateLBL.Text = notebook.UpdateDate.ToString("dd/MM/yyyy");
                    CreateDate.Text = notebook.CreatedDate.ToString("dd/MM/yyyy");
                    NotebookTypeLabel.Text = notebook.Accessibility;
                    NotebookSubject.Text = SubjectTbl.GetSubjectByID(notebook.SubjectId).Name;
                    if(notebook.SchoolId != null)
                    {
                        if (SchoolTbl.GetSchoolByID((int)notebook.SchoolId) != null)
                        {
                            NotebookSchoolLabel.Text = SchoolTbl.GetSchoolByID((int)notebook.SchoolId).Name;
                        }
                    }
                    
                   
                    UserLinkl.Text = UserTbl.GetUserByUserId(notebook.UserId).Username;



                    if (notebook.Format == "document")
                    {
                        DocumentPanel.Visible = true;

                    }
                    if (notebook.Format == "online")
                    {

                        OnlinePanel.Visible = true;

                        textinput.InnerHtml = notebook.OnlineNotebookFormat;
                        CantEditDiv.InnerHtml = notebook.OnlineNotebookFormat;
                    }
                }

                if (user.UserId != notebook.UserId)
                {
                    UpdateButton.Visible = false;
                    SwitchView.Visible = false;
                    DeleteNotebookButton.Visible = false;
                }
                else
                {
                    UpdateButton.Visible = true;
                    SwitchView.Visible = true;
                    DeleteNotebookButton.Visible = true;
                }
                if (user.Permission == "admin")
                {
                    UpdateButton.Visible = true;
                    SwitchView.Visible = true;
                    DeleteNotebookButton.Visible = true;
                }
                if (notebook.Format != "online")
                {
                    OnlinePanel.Visible = false;

                }
                if (notebook.Format == "document")
                {
                    SwitchView.Visible = false;

                }
            }

            if (LikeTbl.IsLiked(user.UserId, notebook.NotebookId))
            {
                LikeButton.ImageUrl = "~/UI/Assets/LikeAfter.png";
            }

            LikeCountLabel.Text = "" + notebook.GetLikeCount();
            SwitchView.Text = "Switch To Edit View";

            List<CommentTbl> list = new List<CommentTbl>(CommentTbl.GetCommentsByNotebookId(notebook.NotebookId));
            list.Reverse();
            CommentsDataList.DataSource = list;
            CommentsDataList.DataBind();
        }

        protected void BackBTN_Click(object sender, EventArgs e)
        {
            if (Session["url"].ToString() != null)
            {
                Response.Redirect(Session["url"].ToString());
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }

        /// <summary>
        /// Downloads the notebook file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DownloadButton_Click(object sender, EventArgs e)
        {
            string filePath = notebook.Path;
            if (filePath == null || filePath == "")
            {
                ErrorLabel.Text = "no file detected, try uploading a new one by clicking update notebook";
                return;
            }
            FileInfo file = new FileInfo(Server.MapPath(filePath));


            if (file.Exists)
            {
                // Clear Rsponse reference  
                Response.Clear();
                // Add header by specifying file name  
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                // Add header for content length  
                Response.AddHeader("Content-Length", file.Length.ToString());
                // Specify content type  
                Response.ContentType = "text/plain";
                // Clearing flush  
                Response.Flush();
                // Transimiting file  
                Response.TransmitFile(file.FullName);
                Response.End();
            }
            else
            {
                ErrorLabel.Text = "Requested file is not available to download(Error in server)";
            }
        }

        /// <summary>
        /// Redirecting to the update notebook page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Session["url"] = Request.UrlReferrer.AbsoluteUri.ToString();
            Response.Redirect($"CreateNotebook.aspx?id={notebook.NotebookId}");
        }

        /// <summary>
        /// Switches views between the edit view, which the user can edit the notebook, and the normal view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SwitchView_Click(object sender, EventArgs e)
        {
            if (EditView.Visible == false)
            {
                EditView.Visible = true;
                CantEditDiv.Visible = false;
                SwitchView.Text = "Switch To Normal View";
                CommentPanel.Visible = false;
            }
            else
            {
                EditView.Visible = false;
                CantEditDiv.Visible = true;
                SwitchView.Text = "Switch To Edit View";
                Response.Redirect(Request.RawUrl);
                CommentPanel.Visible = true;
            }
        }

        /// <summary>
        /// Likes the notebook.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LikeButton_Click(object sender, ImageClickEventArgs e)
        {
            if (notebook.IsLiked(user.UserId))
            {
                //unlike
                notebook.UnLike(user);
                LikeButton.ImageUrl = "~/UI/Assets/LikeBefore.png";
                LikeCountLabel.Text = "" + notebook.GetLikeCount();
            }
            else
            {
                //like
                notebook.Like(user);
                LikeButton.ImageUrl = "~/UI/Assets/LikeAfter.png";
                LikeCountLabel.Text = "" + notebook.GetLikeCount();
            }
        }

        /// <summary>
        /// Deletes the notebook.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeleteNotebookButton_Click(object sender, EventArgs e)
        {
            notebook.DeleteNotebook();
            Response.Redirect("Home.aspx");
        }

        /// <summary>
        /// Adds a comment to the notebook.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddCommentBTN_Click(object sender, EventArgs e)
        {
            string comment = CommentTextBox.Text;
            notebook.AddComment(user, comment);
     
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        /// <summary>
        /// Comments item command, from here you can delete a comment.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Comments_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "DeleteUser")
            {
                CommentTbl.DeleteComment(int.Parse((String)e.CommandArgument));
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        /// <summary>
        /// Comments data bound.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CommentsDataList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
             e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Web.UI.WebControls.LinkButton BT = e.Item.FindControl("DeleteCommentButton") as System.Web.UI.WebControls.LinkButton;
                int commentID = int.Parse(BT.CommandArgument);
                if ((user.Permission == "admin"))
                {


                    BT.Visible = true;
                }
                if (user.UserId == notebook.UserId)
                {
                    BT.Visible = true;
                }
                if (user.UserId == CommentTbl.GetUserThatCommented(commentID).UserId)
                {
                    BT.Visible = true;
                }

            }

        }
    }
}