using NoteShare.Models;
using System;

namespace NoteShare.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loggedInAsPanel.Visible = false;
            UserTbl user = (UserTbl)Session["User"];
            if (!IsPostBack)
            {
                if (user == null)
                {
                    Response.Redirect("login.aspx");
                    return;
                }

                WelcomeLBL.Text = "Welcome " + user.FirstName + "✨";
            }
            if (user.Permission == "admin")
            {
                AdminPanelButton.Visible = true;
                WebsiteStats.Visible = true;
                if (Session["UserFromAdmin"] != null)
                {
                    UserTbl loggedInUser = (UserTbl)Session["UserFromAdmin"];
                    loggedInAsPanel.Visible = true;
                    LoggedAsUserLabel.Text = loggedInUser.Username;
                }
            }
        }

        /// <summary>
        /// Redirecting to the admin panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AdminPanelButton_Click(object sender, EventArgs e)
        {
            Session["url"] = Request.UrlReferrer.AbsoluteUri.ToString();
            Response.Redirect("AdminPanel.aspx");
        }

        /// <summary>
        /// Logout user button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LogOutUseruButton_Click(object sender, EventArgs e)
        {
            loggedInAsPanel.Visible = false;
            Session["UserFromAdmin"] = null;
        }

        /// <summary>
        /// Redirecting to the website stats page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void WebsiteStats_Click(object sender, EventArgs e)
        {
            Session["url"] = Request.UrlReferrer.AbsoluteUri.ToString();
            Response.Redirect("WebsiteStats.aspx");
        }
    }
}