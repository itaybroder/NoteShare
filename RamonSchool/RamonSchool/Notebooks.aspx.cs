using RamonSchool.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RamonSchool
{
    public partial class Notebooks : System.Web.UI.Page
    {
        public static int RAMON_SCHOOL_ID = 12;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            // loadinng a noteShareWS instance
            NoteShareWS context = new NoteShareWS();
            

            // Getting the notebooks
            NotebookWS[] notebooksArray = context.GetAllNotebooks();
            List<NotebookWS> notebooks = new List<NotebookWS>();
            foreach (NotebookWS notebook in notebooksArray)
            {
                notebooks.Add(notebook);
            }

            if (!IsPostBack)
            {
                //show only public, and online notebooks from ramon school.
                NotebooksDataList.DataSource = notebooks.FindAll(x => 
                    x.Accessibility == "public" &&
                    x.Format == "online" &&
                    x.SchoolId == RAMON_SCHOOL_ID);
                NotebooksDataList.DataBind();
            }
        }

        protected void NotebooksDataList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            // if the user clicked on the notebook, sending him to the notebook page.
            if (e.CommandName == "NotebookClick")
            {
                Session["url"] = Request.UrlReferrer.AbsoluteUri.ToString();
                Response.Redirect($"ViewNotebook.aspx?id={e.CommandArgument}");
            }
        }
    }
}