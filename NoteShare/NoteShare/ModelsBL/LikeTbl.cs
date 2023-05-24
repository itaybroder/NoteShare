using NoteShare.ModelsBL;
using System;
using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    /// <summary>
    /// A class that represents the LikeTbl table in the database.
    /// </summary>
    public partial class LikeTbl
    {
        /// <summary>
        /// Checks of a notebook is liked by userId and notebookId.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="notebookId"></param>
        /// <returns></returns>
        public static bool IsLiked(int userId, int notebookId)
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList().Find(x => x.UserId == userId && x.NotebookId == notebookId) != null ? true : false;
        }

        /// <summary>
        /// Removes a like from notebook by likeId.
        /// </summary>
        /// <param name="likeId"></param>
        public static void UnLikeByLikeId(int likeId)
        {
            NoteShareContext db = new NoteShareContext();
            LikeTbl like = new LikeTbl();
            {
                like.LikeId = likeId;
            }

            db.Remove(like).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }

        /// <summary>
        /// A class function for unliking this notebook.
        /// </summary>
        public void UnLike()
        {
            UnLikeByLikeId(this.LikeId);
        }

        /// <summary>
        /// Reutrns a list of all the likes in the LikeTbl.
        /// </summary>
        /// <returns></returns>
        public static List<LikeTbl> GetAllLikes()
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList();
        }
    }
}
