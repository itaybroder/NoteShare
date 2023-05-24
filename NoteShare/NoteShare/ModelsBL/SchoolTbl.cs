using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    /// <summary>
    /// A class that represents the SchoolTbl table in the database.
    /// </summary>
    public partial class SchoolTbl
    {
        /// <summary>
        /// Constructor for SchoolTbl.
        /// </summary>
        /// <param name="id"></param>
        public SchoolTbl(int id)
        {
            UserInSchoolTbl = new HashSet<UserInSchoolTbl>();
        }

        /// <summary>
        /// returns a list of all schools.
        /// </summary>
        /// <returns></returns>
        public static List<SchoolTbl> GetSchools()
        {
            NoteShareContext db = new NoteShareContext();
            return db.SchoolTbl.ToList();
        }

        /// <summary>
        /// Get school by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SchoolTbl GetSchoolByName(string name)
        {
            NoteShareContext db = new NoteShareContext();
            return db.SchoolTbl.ToList().Find(x => x.Name == name);
        }

        /// <summary>
        /// Returns a SchoolTbl object by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SchoolTbl GetSchoolByID(int id)
        {
            NoteShareContext db = new NoteShareContext();
            return db.SchoolTbl.ToList().Find(x => x.SchoolId == id);
        }


        /// <summary>
        /// create a school in the database.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="address"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete school from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

       

        /// <summary>
        /// Edit school. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="address"></param>
        /// <param name="schoolId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// A function that deletes this school.
        /// </summary>
        public void Delete()
        {
            DeleteSchool(this.SchoolId);
        }
        /// <summary>
        /// A function that edits this school.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="country"></param>
        /// <param name="address"></param>
        public void Edit(string name, string country, string address)
        {
            EditSchool(name, country, address, this.SchoolId);
        }
    }
}
