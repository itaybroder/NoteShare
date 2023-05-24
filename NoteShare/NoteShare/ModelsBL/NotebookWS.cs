using NoteShare.Models;
using System;

namespace NoteShare.ModelsBL
{
    /// <summary>
    /// A class that represents a notebook in the web service.
    /// </summary>
    public class NotebookWS
    {
        
        public NotebookWS(int notebookId, int userId, string title, string description, string color, string format, string path, DateTime createdDate, DateTime updateDate, string accessibility, int? schoolId, int subjectId, string onlineNotebookFormat)
        {
            NotebookId = notebookId;
            UserId = userId;
            Title = title;
            Description = description;
            Color = color;
            Format = format;
            Path = path;
            CreatedDate = createdDate;
            UpdateDate = updateDate;
            Accessibility = accessibility;
            SchoolId = schoolId;
            SubjectId = subjectId;
            OnlineNotebookFormat = onlineNotebookFormat;
        }
        public NotebookWS()
        {

        }
        public NotebookWS(NotebookTbl notebook)
        {
            NotebookId = notebook.NotebookId;
            UserId = notebook.UserId;
            Title = notebook.Title;
            Description = notebook.Description;
            Color = notebook.Color;
            Format = notebook.Format;
            Path = notebook.Path;
            CreatedDate = notebook.CreatedDate;
            UpdateDate = notebook.UpdateDate;
            Accessibility = notebook.Accessibility;
            SchoolId = notebook.SchoolId;
            SubjectId = notebook.SubjectId;
            OnlineNotebookFormat = notebook.OnlineNotebookFormat;
        }
        public int NotebookId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Format { get; set; }
        public string Path { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Accessibility { get; set; }
        public int? SchoolId { get; set; }
        public int SubjectId { get; set; }
        public string OnlineNotebookFormat { get; set; }
    }
}