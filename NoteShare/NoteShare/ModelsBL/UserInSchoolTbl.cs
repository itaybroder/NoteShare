using System.Collections.Generic;
using System.Linq;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    /// <summary>
    /// A class tjat represents the UserInSchoolTbl table in the database
    /// </summary>
    public partial class UserInSchoolTbl
    {
        // A static instance of the database context
        public static NoteShareContext db = new NoteShareContext();

        /// <summary>
        /// Get school by user id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Get all users in school by user id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<UserInSchoolTbl> getAllUserInSchoolByUserId(int userId)
        {
            return db.UserInSchoolTbl.ToList().FindAll(x => x.UserId == userId);
        }

        /// <summary>
        /// Get all users in school by school id.
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public static List<UserInSchoolTbl> getAllUserInSchoolBySchoolId(int schoolId)
        {
            return db.UserInSchoolTbl.ToList().FindAll(x => x.SchoolId == schoolId);
        }

        /// <summary>
        /// get all users in school by school id.
        /// </summary>
        /// <param name="schoolId"></param>
        /// <returns></returns>
        public static List<UserInSchoolTbl> getAllUsersInSchoolBySchoolId(int schoolId)
        {
            return db.UserInSchoolTbl.ToList().FindAll(x => x.SchoolId == schoolId);
        }

        /// <summary>
        /// Deletes user in school by user id.
        /// </summary>
        /// <param name="userId"></param>
        public static void DeleteUserInSchool(int userId)
        {
            foreach (UserInSchoolTbl userInSchool in getAllUserInSchoolByUserId(userId))
            {
                db.Remove(userInSchool).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Delete user in school by school id.
        /// </summary>
        /// <param name="schoolId"></param>
        public static void DeleteUserInSchoolBySchool(int schoolId)
        {
            foreach (UserInSchoolTbl userInSchool in getAllUserInSchoolBySchoolId(schoolId))
            {
                db.Remove(userInSchool).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public static void AddUserInSchool(int schoolId, int userId)
        {
            UserInSchoolTbl userInSchool = new UserInSchoolTbl();
            {
                userInSchool.SchoolId = schoolId;
                userInSchool.UserId = userId;
            }
            db.Add(userInSchool).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            db.SaveChanges();
        }
    }
}