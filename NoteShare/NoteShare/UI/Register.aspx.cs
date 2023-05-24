using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace NoteShare.UI
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<SchoolTbl> schoolsList = SchoolTbl.GetSchools();
                SchoolsDataList.DataSource = schoolsList;
                SchoolsDataList.DataBind();
            }
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


        }

        /// <summary>
        /// Registers the user.
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

            UserTbl user = UserTbl.Register(username, password, firstName, lastName, birthday, schools, address);
            if (user == null) lblMessage.Text = "User already exist";
            else
            {
                Session["user"] = user;
                Response.Redirect("home.aspx");
            }
        }
    }
}