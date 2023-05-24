using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace NoteShare.UI
{
    public partial class WebsiteStats : System.Web.UI.Page
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
            NumberOfSchoolsLabel.Text = "" + SchoolTbl.GetSchools().Count;
            NumberOfUsersLabel.Text = "" + UserTbl.GetAllUsers().Count;
            NumberOfNotebooksLabel.Text = "" + NotebookTbl.getAllNotebooks().Count;
            NumberOfSubjectsLabel.Text = "" + SubjectTbl.GetNumberOfSubjects();
            NumberOfLikesLabel.Text = "" + LikeTbl.GetAllLikes().Count;
            NumberOfAdminsLabel.Text = "" + UserTbl.GetAllUsers().FindAll(x=>x.Permission == "admin").Count;

            List<NotebookTbl> allNotebooks = NotebookTbl.getAllNotebooks();
            List<string> subjectsList = new List<string>();
            foreach (NotebookTbl notebook in allNotebooks)
            {
                if (notebook.Subject != null)
                {
                    subjectsList.Add(SubjectTbl.GetSubjectByID(notebook.SubjectId).Name);
                }

            }

         



            if (!IsPostBack)
            {
                List<LikeTbl> likedNotebooks = LikeTbl.GetAllLikes();
                Dictionary<int, int> mostLikedNotebooksIds = new Dictionary<int, int>();
                foreach (NotebookTbl notebook in NotebookTbl.getAllNotebooks())
                {
                    //notebookd ID, number of likes.
                    mostLikedNotebooksIds.Add(notebook.NotebookId, likedNotebooks.FindAll(x => x.NotebookId == notebook.NotebookId).Count());

                }

                var sortedDict = from entry in mostLikedNotebooksIds orderby entry.Value descending select entry;

                List<NotebookTbl> mostLikedNotebooks = new List<NotebookTbl>();

                for (int i = 0; i < 10; i++)
                {
                    if (i >= sortedDict.Count())
                    {
                        break;
                    }
                    mostLikedNotebooks.Add(NotebookTbl.GetNotebookByNotebookID(sortedDict.ElementAt(i).Key));
                }
                MostLikedDataList.DataSource = mostLikedNotebooks;
                MostLikedDataList.DataBind();




                List<UserTbl> activeUsers = UserTbl.GetAllUsers();
                var sortedUsers = activeUsers.OrderBy(user => NotebookTbl.GetNumberOfNotebooksByUserId(user.UserId)).ToList();


                ActiveUsersDataList.DataSource = sortedUsers.Take(10).ToList();
                ActiveUsersDataList.DataBind();
            }

        }

        protected void BackBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        protected void MostLikeNotebooks_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "NotebookClick")
            {
                Session["url"] = Request.UrlReferrer.AbsoluteUri.ToString();
                Response.Redirect($"ViewNotebook.aspx?id={e.CommandArgument}");
            }
        }

        protected void Notebooks_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "NotebookClick")
            {
                Session["url"] = Request.UrlReferrer.AbsoluteUri.ToString();
                Response.Redirect($"ViewNotebook.aspx?id={e.CommandArgument}");
            }
        }

        protected void Users_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "DeleteUser")
            {
                UserTbl userToDelete = new UserTbl(int.Parse((String)e.CommandArgument));
                userToDelete.Delete();

                Response.Redirect(Request.RawUrl);
            }
            if (e.CommandName == "UserClick")
            {
                UserTbl user = UserTbl.GetUserByUserId(int.Parse((String)e.CommandArgument));
                Session["UserFromAdmin"] = user;
                Response.Redirect("Home.aspx");
            }
        }
    }
}