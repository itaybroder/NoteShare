using System;

namespace NoteShare
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                LogOutButton.Visible = false;
                HomePanel.Visible = true;
                LogedInPanel.Visible = false;
            }
            else
            {
                LogOutButton.Visible = true;
                HomePanel.Visible = false;
                LogedInPanel.Visible = true;
            }
        }



        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("Home.aspx");

        }
    }
}