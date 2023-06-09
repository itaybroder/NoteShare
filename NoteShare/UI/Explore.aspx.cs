﻿using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace NoteShare.UI
{
    public partial class Explore : System.Web.UI.Page
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

            if (!IsPostBack)
            {

                if (user.Permission == "admin")
                {
                    MostLikedDataList.DataSource = MostLikeNotebookList(10);
                    RecentlyAddedNotebooks.DataSource = RecentlyAddedNotebookList(10);
                }
                else
                {
                    //show only public notebooks for regular users.
                    MostLikedDataList.DataSource = MostLikeNotebookList(10).FindAll(x => x.Accessibility == "public" || x.UserId == user.UserId);
                    RecentlyAddedNotebooks.DataSource = RecentlyAddedNotebookList(10).FindAll(x => x.Accessibility == "public" || x.UserId == user.UserId);
                }
                MostLikedDataList.DataBind();
                RecentlyAddedNotebooks.DataBind();
            }
        }

        //returns and k's most liked notebooks
        public static List<NotebookTbl> MostLikeNotebookList(int number)
        {
            List<LikeTbl> likedNotebooks = LikeTbl.GetAllLikes();
            Dictionary<int, int> mostLikedNotebooksIds = new Dictionary<int, int>();
            foreach (NotebookTbl notebook in NotebookTbl.getAllNotebooks())
            {
                //notebookd ID, number of likes.
                mostLikedNotebooksIds.Add(notebook.NotebookId, likedNotebooks.FindAll(x => x.NotebookId == notebook.NotebookId).Count());

            }

            var sortedDict = from entry in mostLikedNotebooksIds orderby entry.Value ascending select entry;

            List<NotebookTbl> mostLikedNotebooks = new List<NotebookTbl>();

            for (int i = 0; i < number; i++)
            {
                if (i >= sortedDict.Count())
                {
                    break;
                }
                mostLikedNotebooks.Add(NotebookTbl.getNotebookByNotebookID(sortedDict.ElementAt(i).Key));
            }

            return mostLikedNotebooks;
        }


        public static List<NotebookTbl> RecentlyAddedNotebookList(int number)
        {
            List<NotebookTbl> recentlyAddedNotebooks = NotebookTbl.getAllNotebooks();
            recentlyAddedNotebooks.Sort((x, y) => DateTime.Compare(y.CreatedDate, x.CreatedDate));
            return (List<NotebookTbl>)recentlyAddedNotebooks.GetRange(0, number);
        }

        protected void Notebooks_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "NotebookClick")
            {
                Session["url"] = Request.UrlReferrer.AbsoluteUri.ToString();
                Response.Redirect($"ViewNotebook.aspx?id={e.CommandArgument}");
            }
        }

        protected void MostLikeNotebooks_ItemCommand(object source, DataListCommandEventArgs e)
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
        protected void SearchButton_Click(object sender, EventArgs e)
        {

            List<NotebookTbl> searchedNotebooks = NotebookTbl.getAllNotebooks();
            if (UserTB.Text != "")
            {
                searchedNotebooks = NotebookTbl.getNotebooksFromListAndVar(searchedNotebooks, 0, UserTB.Text);
            }
            if (SubjectTB.Text != "")
            {
                searchedNotebooks = NotebookTbl.getNotebooksFromListAndVar(searchedNotebooks, 1, SubjectTB.Text);
            }
            if (SchoolTB.Text != "")
            {
                searchedNotebooks = NotebookTbl.getNotebooksFromListAndVar(searchedNotebooks, 2, SchoolTB.Text);
            }
            if (DescripionTB.Text != "")
            {
                searchedNotebooks = NotebookTbl.getNotebooksFromListAndVar(searchedNotebooks, 3, DescripionTB.Text);
            }

            if (searchedNotebooks != null)
            {
                if (searchedNotebooks.Count == 0)
                {
                    Notebooks.Visible = false;
                    NotFoundLabel.Visible = true;
                }
                else
                {
                    if (user.Permission == "admin")
                    {
                        Notebooks.DataSource = searchedNotebooks;
                    }
                    else
                    {

                        Notebooks.DataSource = searchedNotebooks.FindAll(x => x.Accessibility == "public" || x.UserId == user.UserId);
                    }
                    Notebooks.DataBind();
                    NotFoundLabel.Visible = false;
                    Notebooks.Visible = true;
                }
            }
            else
            {
                Notebooks.Visible = false;
                NotFoundLabel.Visible = true;
            }

        }
    }
}