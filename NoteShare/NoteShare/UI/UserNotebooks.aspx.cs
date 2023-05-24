using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace NoteShare.UI
{
    public partial class user_notebooks : System.Web.UI.Page
    {
        // The current user.
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

                List<NotebookTbl> userNotebooks = NotebookTbl.GetNotebooksByUserID(user.UserId);
                Notebooks.DataSource = userNotebooks;
                Notebooks.DataBind();
            }
            title.Text = $"{user.FirstName}'s notebooks";

            if (user.Permission == "admin")
            {

                if (Session["UserFromAdmin"] != null)
                {
                    user = ((UserTbl)Session["UserFromAdmin"]);
                    title.Text = $"{user.FirstName}'s notebooks";
                    List<NotebookTbl> userNotebooks = NotebookTbl.GetNotebooksByUserID(user.UserId);
                    Notebooks.DataSource = userNotebooks;
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

        protected void BackBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}