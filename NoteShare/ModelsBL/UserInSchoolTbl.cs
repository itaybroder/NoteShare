using System.Collections.Generic;
using System.Linq;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    public partial class UserInSchoolTbl
    {
        public static NoteShareContext db = new NoteShareContext();
        public static List<SchoolTbl> GetSchoolsByUserId(int id)
        {
            List<UserInSchoolTbl> usersInSchool = db.UserInSchoolTbl.ToList().FindAll(x => x.UserId == id);
            List<SchoolTbl> schoolTbls = new List<SchoolTbl>();
            foreach (UserInSchoolTbl userInSchool in usersInSchool)
            {
                schoolTbls.Add(SchoolTbl.GetSchoolByID(userInSchool.SchoolId));
            }
            return schoolTbls;
        }

        public static List<UserInSchoolTbl> getAllUserInSchoolByUserId(int userId)
        {
            return db.UserInSchoolTbl.ToList().FindAll(x => x.UserId == userId);
        }

        public static List<UserInSchoolTbl> getAllUserInSchoolBySchoolId(int schoolId)
        {
            return db.UserInSchoolTbl.ToList().FindAll(x => x.SchoolId == schoolId);
        }

        public static List<UserInSchoolTbl> getAllUsersInSchoolBySchoolId(int schoolId)
        {
            return db.UserInSchoolTbl.ToList().FindAll(x => x.SchoolId == schoolId);
        }


        public static void DeleteUserInSchool(int userId)
        {
            foreach (UserInSchoolTbl userInSchool in getAllUserInSchoolByUserId(userId))
            {
                db.Remove(userInSchool).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public static void DeleteUserInSchoolBySchool(int schoolId)
        {
            foreach (UserInSchoolTbl userInSchool in getAllUserInSchoolBySchoolId(schoolId))
            {
                db.Remove(userInSchool).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}