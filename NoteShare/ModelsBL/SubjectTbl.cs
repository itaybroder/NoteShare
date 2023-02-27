using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    public partial class SubjectTbl
    {
        public static SubjectTbl GetSubjectByName(string name)
        {
            NoteShareContext context = new NoteShareContext();
            return context.SubjectTbl.ToList().Find(x => x.Name == name);
        }

        public static SubjectTbl GetSubjectByID(int id)
        {
            NoteShareContext context = new NoteShareContext();
            return context.SubjectTbl.ToList().Find(x => x.SubjectId == id);
        }

        public static void DeleteSubject(int subjectId)
        {
            NoteShareContext db = new NoteShareContext();
            SubjectTbl subject = new SubjectTbl();
            {
                subject.SubjectId = subjectId;
            }
            db.Remove(subject).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

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

        public static int GetNumberOfSubjects()
        {
            NoteShareContext noteShareContext = new NoteShareContext();
            return noteShareContext.SubjectTbl.ToList().Count();
        }

        public static List<SubjectTbl> GetSubjects()
        {
            NoteShareContext noteShareContext = new NoteShareContext();
            return noteShareContext.SubjectTbl.ToList();
        }
    }
}
