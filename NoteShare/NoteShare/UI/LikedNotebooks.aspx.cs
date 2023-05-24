using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace NoteShare.UI
{
    public partial class LikedNotebooks : System.Web.UI.Page
    {
        //the current user.
        public static UserTbl user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user = (UserTbl)Session["User"];
                if (user == null)
                {
                    Response.Redirect("login.aspx");
                    return;
                }

                List<NotebookTbl> likedNotebooks = user.GetLikedNotebooks();
                Notebooks.DataSource = likedNotebooks;
                Notebooks.DataBind();
            }


            if (user.Permission == "admin")
            {

                if (Session["UserFromAdmin"] != null)
                {
                    user = ((UserTbl)Session["UserFromAdmin"]);
                    List<NotebookTbl> likedNotebooks = user.GetLikedNotebooks();
                    Notebooks.DataSource = likedNotebooks;
                    Notebooks.DataBind();
                }

            }

        }

        /// <summary>
        /// Notebooks data list item command.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Notebooks_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "NotebookClick")
            {
                Session["url"] = Request.UrlReferrer.AbsoluteUri.ToString();
                Response.Redirect($"ViewNotebook.aspx?id={e.CommandArgument}");
            }
        }

        /// <summary>
        /// Returns to the home screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BackBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}