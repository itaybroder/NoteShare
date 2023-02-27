using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    public partial class SchoolTbl
    {
        public SchoolTbl(int id)
        {
            UserInSchoolTbl = new HashSet<UserInSchoolTbl>();
        }
        public static List<SchoolTbl> GetSchools()
        {
            NoteShareContext db = new NoteShareContext();
            return db.SchoolTbl.ToList();
        }

        public static SchoolTbl GetSchoolByName(string name)
        {
            NoteShareContext db = new NoteShareContext();
            return db.SchoolTbl.ToList().Find(x => x.Name == name);
        }
        public static SchoolTbl GetSchoolByID(int id)
        {
            NoteShareContext db = new NoteShareContext();
            return db.SchoolTbl.ToList().Find(x => x.SchoolId == id);
        }



        public static SchoolTbl CreateSchool(string name, string country, string address)
        {
            NoteShareContext db = new NoteShareContext();
            SchoolTbl school = new SchoolTbl();
            {
                school.Name = name;
                school.Address = address;
                school.Country = country;
            }
            db.Entry(school).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            db.SaveChanges();
            return school;
        }

        public static SchoolTbl DeleteSchool(int id)
        {
            NoteShare.Models.UserInSchoolTbl.DeleteUserInSchoolBySchool(id);
            NoteShareContext db = new NoteShareContext();
            SchoolTbl school = new SchoolTbl();
            {
                school.SchoolId = id;
            }
            db.Remove(school).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
            return school;
        }

        public static SchoolTbl EditSchool(string name, string country, string address, int schoolId)
        {
            NoteShareContext db = new NoteShareContext();
            SchoolTbl school = new SchoolTbl();
            {
                school.SchoolId = schoolId;
                school.Name = name;
                school.Address = address;
                school.Country = country;
            }
            db.Update(school).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return school;
        }
    }
}
