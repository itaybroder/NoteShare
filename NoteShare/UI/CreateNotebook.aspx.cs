﻿using NoteShare.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
namespace NoteShare.UI
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public static UserTbl user;

        public static string GetIDFromUrl()
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
            return desiredValue;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Home.aspx");
            }

            user = ((UserTbl)Session["User"]);
            if (!IsPostBack)
            {

                string desiredValue = GetIDFromUrl();
                if (desiredValue != "")
                {
                    Session["CurrentNotebook"] = NotebookTbl.getNotebookByNotebookID(Int32.Parse(desiredValue));
                    NotebookTbl notebook = (NotebookTbl)Session["CurrentNotebook"];
                    TitleLBL.Text = notebook.Title;
                    Description.Text = notebook.Description;
                    ColorsList.SelectedValue = notebook.Color;
                    FormatList.SelectedValue = notebook.Format;
                    SubjectsDropdownlist.SelectedValue = SubjectTbl.GetSubjectByID(notebook.SubjectId).Name;
                    ModeLabel.Text = "Update notebook";
                    accessibilityList.SelectedValue = notebook.Accessibility;
                    SubmitButton.Text = "Update notebook";
                }
            }
            if (user.Permission == "admin")
            {

                if (Session["UserFromAdmin"] != null)
                {
                    user = ((UserTbl)Session["UserFromAdmin"]);
                }

            }

            FormatList_SelectedIndexChanged(null, null);
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void SubmitData(object sender, EventArgs e)
        {
            NotebookTbl notebook = (NotebookTbl)Session["CurrentNotebook"];
            int userID = user.UserId;
            string title = TitleLBL.Text;
            string description = Description.Text;
            string color = ColorsList.SelectedValue;
            string format = FormatList.SelectedValue;
            string accessibility = accessibilityList.SelectedValue;
            string subject = SubjectsDropdownlist.SelectedValue;
            int schoolId = 0;
            if (SchoolsDropDownList.SelectedValue != null && SchoolsDropDownList.SelectedValue != "")
            {
                schoolId = int.Parse(SchoolsDropDownList.SelectedValue);
            }

            if (notebook == null)
            {
                notebook = NotebookTbl.CreateNewNotebook(userID, title, description, color, format, "", accessibility, schoolId, subject);
            }
            else
            {
                notebook = NotebookTbl.UpdateNotebook(notebook.NotebookId, userID, title, description, color, format, notebook.Path, accessibility, schoolId, subject);
            }

            if (format == "document")
            {
                if (DocumentUpload.HasFile)
                {
                    string[] tmp = DocumentUpload.FileName.Split('.');
                    string ext = tmp[tmp.Length - 1];
                    string path = $"notebookfiles/notebook-{notebook.NotebookId}.{ext}";
                    DocumentUpload.SaveAs(Server.MapPath(path));
                    NotebookTbl.UpdatePath(notebook, path);
                }
            }

            Response.Redirect("Home.aspx");
        }
        protected void BackBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void FormatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormatList.SelectedValue == "document")
            {
                DocumentUpload.Visible = true;
            }
            else
            {
                DocumentUpload.Visible = false;
            }
        }
        public static List<SubjectTbl> GetSubjects()
        {
            return SubjectTbl.GetSubjects();
        }
        public static List<SchoolTbl> GetUserSchools()
        {
            return UserInSchoolTbl.GetSchoolsByUserId(user.UserId);
        }
    }
}