﻿using NoteShare.Models;
using System;

namespace NoteShare.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void LoginBTN_Click(object sender, EventArgs e)
        {
            string username = UsernameTB.Text;
            string password = PasswordTB.Text;

            UserTbl user = UserTbl.UserLogin(username, password);
            if (user == null)
            {
                lblMessage.Text = "login unsuccessfull";
            }
            else
            {
                Session["User"] = user;
                Response.Redirect("home.aspx");
            }

        }
    }
}