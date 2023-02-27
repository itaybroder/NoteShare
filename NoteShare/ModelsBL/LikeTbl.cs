using NoteShare.ModelsBL;
using System;
using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    public partial class LikeTbl
    {
        public static bool IsLiked(int userId, int notebookId)
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList().Find(x => x.UserId == userId && x.NotebookId == notebookId) != null ? true : false;
        }

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
       
        public static List<LikeTbl> GetAllLikes()
        {
            NoteShareContext db = new NoteShareContext();
            return db.LikeTbl.ToList();
        }

      
    }
}
