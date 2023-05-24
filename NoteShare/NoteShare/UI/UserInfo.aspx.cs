using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoteShare.UI
{
    public partial class profile : System.Web.UI.Page
    {
        // The current user.
        public static UserTbl user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (UserTbl)Session["User"];
            if (user == null)
            {
                Response.Redirect("login.aspx");
                return;
            }

            if (user.Permission == "admin")
            {

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
                if (Session["UserFromAdmin"] != null)
                {
                    desiredValue = ((UserTbl)Session["UserFromAdmin"]).UserId.ToString();
                }
                if (desiredValue != "")
                {
                    if (UserTbl.GetUserByUserId(int.Parse(desiredValue)) != null)
                    {
                        user = UserTbl.GetUserByUserId(int.Parse(desiredValue));
                    }

                }
            }

            NameLBL.Text = user.FirstName + " " + user.LastName;
            PassLBL.Text = user.Password;
            BDLBL.Text = user.Birthday.ToString("dd/MM/yyyy");
            SchoolLBL.Text = "";
            foreach (SchoolTbl school in UserInSchoolTbl.GetSchoolsByUserId(user.UserId))
            {
                SchoolLBL.Text += school.Name + ", ";
            }
            if (SchoolLBL.Text.Length >= 2)
            {
                SchoolLBL.Text = SchoolLBL.Text.Substring(0, SchoolLBL.Text.Length - 2);
            }

            AdressLBL.Text = user.Address;
            UsernameLBL.Text = user.Username;

            if (!IsPostBack)
            {
                List<SchoolTbl> schoolsList = SchoolTbl.GetSchools();
                SchoolsDataList.DataSource = schoolsList;
                SchoolsDataList.DataBind();

                InitUpdatePanel();
            }

            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void BackBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        /// <summary>
        /// Redirect to the user notebook page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GoToUserNotebooks_Click(object sender, EventArgs e)
        {
            Session["url"] = Request.UrlReferrer.AbsoluteUri.ToString();
            Response.Redirect($"UserNotebooks.aspx?id={user.UserId}");
        }

        /// <summary>
        /// Opens the edit panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditButton_Click(object sender, EventArgs e)
        {
            EditUserPanel.Visible = true;
            UserInfoPanel.Visible = false;
            EditButton.Visible = false;
        }

        /// <summary>
        /// initializes the Update profile panel.
        /// </summary>
        public void InitUpdatePanel()
        {
            FirstNameTB.Text = user.FirstName;
            LastNameTB.Text = user.LastName;
            PasswordTB.Text = user.Password;
            UsernameTB.Text = user.Username;
            from_date.Text = user.Birthday.ToString();
            AdressTB.Text = user.Address;
        }

        /// <summary>
        /// Updates the user info.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RegisterBTN_Click(object sender, EventArgs e)
        {
            string firstName = FirstNameTB.Text;
            string lastName = LastNameTB.Text;
            string password = PasswordTB.Text;

            DateTime birthday = Convert.ToDateTime(from_date.Text);
            List<SchoolTbl> schools = new List<SchoolTbl>();

            foreach (DataListItem item in SchoolsDataList.Items)
            {
                RadioButton chkSmall = (RadioButton)item.FindControl("CheckBox");
                if (chkSmall.Checked)
                {
                    schools.Add(SchoolTbl.GetSchoolByName(chkSmall.Text));
                }
            }



            string address = AdressTB.Text;
            string username = UsernameTB.Text;

            if (PasswordTB.Text != PasswordTB2.Text)
            {
                lblMessage.Text = "Password doesn't match";
                return;
            }
            if (Session["UserFromAdmin"] != null)
            {
                UserTbl userToUpdate = new UserTbl(((UserTbl)Session["UserFromAdmin"]).UserId);
                user.UpdateUser(((UserTbl)Session["UserFromAdmin"]).Permission, username, password, firstName, lastName, birthday, schools, address);
            }
            else
            {
                user.UpdateUser(user.Permission, username, password, firstName, lastName, birthday, schools, address);
            }

            if (user == null) lblMessage.Text = "User already exist";
            else
            {
                Session["user"] = user;
                CancelButton_Click(null, null);
            }

        }

        /// <summary>
        /// Cancels the update info panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}