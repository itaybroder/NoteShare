using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoteShare.UI
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        public static UserTbl user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (UserTbl)Session["User"];
            if (user == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            if (user.Permission != "admin")
            {
                Response.Redirect("login.aspx");
                return;
            }

            if (!Page.IsPostBack)
            {
                RefreshLists();
            }
        }

        public void RefreshLists()
        {
            List<UserTbl> users = UserTbl.GetAllUsers();
            UsersDataList.DataSource = users;
            UsersDataList.DataBind();

            List<SchoolTbl> schools = SchoolTbl.GetSchools();
            SchoolsDataList.DataSource = schools;
            SchoolsDataList.DataBind();

            List<SubjectTbl> subjects = SubjectTbl.GetSubjects();
            SubjectsDataList.DataSource = subjects;
            SubjectsDataList.DataBind();
        }

        protected void Users_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "DeleteUser")
            {
                UserTbl userToDelete = new UserTbl(int.Parse((String)e.CommandArgument));
                userToDelete.Delete();

                RefreshLists();
            }
            if (e.CommandName == "UserClick")
            {
                UserTbl user = UserTbl.GetUserByUserId(int.Parse((String)e.CommandArgument));
                Session["UserFromAdmin"] = user;
                Response.Redirect("Home.aspx");
            }
        }
        protected void Schools_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DeleteSchool")
            {
                SchoolTbl.DeleteSchool(int.Parse((String)e.CommandArgument));

                RefreshLists();
            }
            else if (e.CommandName == "EditSchool")
            {
                SchoolTbl school = SchoolTbl.GetSchoolByID(int.Parse((String)e.CommandArgument));
                EditSchool.Visible = true;
                EditSchoolName.Text = school.Name;
                EditSchoolCountry.Text = school.Country;
                EditSchoolAddress.Text = school.Address;
                schoolIdLabel.Text = (String)e.CommandArgument;
            }

        }

        protected void AddSchoolButton_Click(object sender, EventArgs e)
        {
            createSchool.Visible = true;
            AddSchoolButton.Visible = false;

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            createSchool.Visible = false;
            AddSchoolButton.Visible = true;
        }

        protected void submitSchoolButton_Click(object sender, EventArgs e)
        {
            string name = CreateSchoolName.Text;
            string country = CreateSchoolCountry.Text;
            string address = CreateSchoolAddress.Text;

            SchoolTbl school = SchoolTbl.CreateSchool(name, country, address);
            List<SchoolTbl> schools = SchoolTbl.GetSchools();
            RefreshLists();
            CancelButton_Click(null, null);
        }

        protected void BackBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void EditSchoolSummit_Click(object sender, EventArgs e)
        {

            string name = EditSchoolName.Text;
            string country = EditSchoolCountry.Text;
            string address = EditSchoolAddress.Text;

            SchoolTbl school = SchoolTbl.EditSchool(name, country, address, int.Parse(schoolIdLabel.Text));
            RefreshLists();
            EditSchool.Visible = false;
        }

        protected void AddSubjectButton_Click(object sender, EventArgs e)
        {
            string newSubjectText = SubjectTextBox.Text;

            SubjectTbl.CreateSubject(newSubjectText);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void SubjectsDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DeleteSubject")
            {
                SubjectTbl.DeleteSubject(int.Parse((String)e.CommandArgument));
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
    }
}