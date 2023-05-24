using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoteShare.UI
{
    public partial class AdminPanel : System.Web.UI.Page
    {   
        // The user connected.
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

        /// <summary>
        /// The function refreshes all the lists in the admin panel.
        /// </summary>
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

        /// <summary>
        /// This function is called when an item command occures on the users DataList.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Users_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //Delete user item command.
            if (e.CommandName == "DeleteUser")
            {
                UserTbl userToDelete = new UserTbl(int.Parse((String)e.CommandArgument));
                userToDelete.Delete();

                RefreshLists();
            }
            //user click item command. logs you in as a user.
            if (e.CommandName == "UserClick")
            {
                UserTbl user = UserTbl.GetUserByUserId(int.Parse((String)e.CommandArgument));
                Session["UserFromAdmin"] = user;
                Response.Redirect("Home.aspx");
            }
        }

        /// <summary>
        /// This function is called when an item command occures on the schools DataList
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Schools_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //Delete school item command.
            if (e.CommandName == "DeleteSchool")
            {
                SchoolTbl.DeleteSchool(int.Parse((String)e.CommandArgument));
                RefreshLists();
            }
            //Edit school item command.
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

        /// <summary>
        /// Adds school.
        /// makes the addschool button visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddSchoolButton_Click(object sender, EventArgs e)
        {
            //makes the addschool button visible
            createSchool.Visible = true;
            AddSchoolButton.Visible = false;

        }

        /// <summary>
        /// Cancels the create school state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            createSchool.Visible = false;
            AddSchoolButton.Visible = true;
        }

        /// <summary>
        /// Submits the create school form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submitSchoolButton_Click(object sender, EventArgs e)
        {
            string name = CreateSchoolName.Text;
            string country = CreateSchoolCountry.Text;
            string address = CreateSchoolAddress.Text;

            //updates the database
            SchoolTbl school = SchoolTbl.CreateSchool(name, country, address);
            List<SchoolTbl> schools = SchoolTbl.GetSchools();
            RefreshLists();
            CancelButton_Click(null, null);
        }

        /// <summary>
        /// Returns to the home page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BackBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        /// <summary>
        /// Submits the edit school form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditSchoolSummit_Click(object sender, EventArgs e)
        {
            string name = EditSchoolName.Text;
            string country = EditSchoolCountry.Text;
            string address = EditSchoolAddress.Text;

            SchoolTbl school = SchoolTbl.EditSchool(name, country, address, int.Parse(schoolIdLabel.Text));
            RefreshLists();
            EditSchool.Visible = false;
        }

        /// <summary>
        /// Creating a subject.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddSubjectButton_Click(object sender, EventArgs e)
        {
            //Subject name.
            string newSubjectText = SubjectTextBox.Text;

            SubjectTbl.CreateSubject(newSubjectText);

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        /// <summary>
        /// Subjects list item commands.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void SubjectsDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //Delets a subject on click.
            if (e.CommandName == "DeleteSubject")
            {
                SubjectTbl.DeleteSubject(int.Parse((String)e.CommandArgument));
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        /// <summary>
        /// This function is called when the search text changes. and it filters the users list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Search_TextChanged(object sender, EventArgs e)
        {
            List<UserTbl> users;
            if (SearchText.Text == "")
            {
                users = UserTbl.GetAllUsers();
            }
            else
            {
                users = UserTbl.GetAllUsers().FindAll(t => t.Username.StartsWith(SearchText.Text));
            }
            
            UsersDataList.DataSource = users;
            UsersDataList.DataBind();
        }
    }
}