using System.Collections.Generic;
using System.Linq;

namespace NoteShare.Models
{
    /// <summary>
    /// A class that represents a subject in the database.
    /// </summary>
    public partial class SubjectTbl
    {
        public SubjectTbl(int subjectId)
        {
            NoteShareContext context = new NoteShareContext();
            SubjectTbl subject = context.SubjectTbl.ToList().Find((SubjectTbl a) => a.SubjectId == subjectId);
            this.SubjectId = subjectId;
            this.Name = subject.Name;
        }
        /// <summary>
        /// using when no a notebook has no subject.
        /// </summary>
        public static SubjectTbl NONE_SUBJECT = GetSubjectByName("None");
        
        /// <summary>
        /// Get subject by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SubjectTbl GetSubjectByName(string name)
        {
            NoteShareContext context = new NoteShareContext();
            return context.SubjectTbl.ToList().Find(x => x.Name == name);
        }

        /// <summary>
        /// Get subject by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SubjectTbl GetSubjectByID(int id)
        {
            NoteShareContext context = new NoteShareContext();
            return context.SubjectTbl.ToList().Find(x => x.SubjectId == id);
        }
        
        /// <summary>
        /// Delete subject. 
        /// </summary>
        /// <param name="subjectId"></param>
        public static void DeleteSubject(int subjectId)
        {
            NoteShareContext db = new NoteShareContext();
            SubjectTbl subject = new SubjectTbl(subjectId);
            

            NoteShare.Models.NotebookTbl.GetNotebooksBySubject(subject.Name)
                .ForEach((NotebookTbl notebook) => { 
                    notebook.Subject = NONE_SUBJECT; 
                    notebook.SubjectId= NONE_SUBJECT.SubjectId;
                    db.Update(notebook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                });
           

            db.Remove(subject).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        // A function that deletes this subject.
        public void Delete()
        {
            DeleteSubject(this.SubjectId);
        }

        /// <summary>
        /// Creating a subject, and adding it to the database.
        /// </summary>
        /// <param name="name"></param>
        public static void CreateSubject(string name)
        {
            NoteShareContext db = new NoteShareContext();
            SubjectTbl subject = new SubjectTbl();
            {
                subject.Name = name;
            }
            db.Entry(subject).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            db.SaveChanges();
        }

        /// <summary>
        /// Get the number of subjects in the database.
        /// </summary>
        /// <returns></returns>
        public static int GetNumberOfSubjects()
        {
            NoteShareContext noteShareContext = new NoteShareContext();
            return noteShareContext.SubjectTbl.ToList().Count();
        }

        /// <summary>
        /// Get all subjects in the database.
        /// </summary>
        /// <returns></returns>
        public static List<SubjectTbl> GetSubjects()
        {
            NoteShareContext noteShareContext = new NoteShareContext();
            return noteShareContext.SubjectTbl.ToList();
        }
    }
}
