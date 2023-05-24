using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NoteShare.Models
{
    public partial class NoteShareContext : DbContext
    {
        public NoteShareContext()
        {
        }

        public NoteShareContext(DbContextOptions<NoteShareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CommentTbl> CommentTbl { get; set; }
        public virtual DbSet<LikeTbl> LikeTbl { get; set; }
        public virtual DbSet<NotebookTbl> NotebookTbl { get; set; }
        public virtual DbSet<SchoolTbl> SchoolTbl { get; set; }
        public virtual DbSet<SubjectTbl> SubjectTbl { get; set; }
        public virtual DbSet<UserInSchoolTbl> UserInSchoolTbl { get; set; }
        public virtual DbSet<UserTbl> UserTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-4HM8G1O\\SQLEXPRESS;Database=NoteShare;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommentTbl>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.ToTable("CommentTBL");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.NotebookId).HasColumnName("NotebookID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Notebook)
                    .WithMany(p => p.CommentTbl)
                    .HasForeignKey(d => d.NotebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentTBL_NotebookTBL");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentTbl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentTBL_UserTBL");
            });

            modelBuilder.Entity<LikeTbl>(entity =>
            {
                entity.HasKey(e => e.LikeId);

                entity.ToTable("LikeTBL");

                entity.Property(e => e.LikeId).HasColumnName("LikeID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.NotebookId).HasColumnName("NotebookID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Notebook)
                    .WithMany(p => p.LikeTbl)
                    .HasForeignKey(d => d.NotebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LikeTBL_NotebookTBL");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LikeTbl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LikeTBL_UserTBL");
            });

            modelBuilder.Entity<NotebookTbl>(entity =>
            {
                entity.HasKey(e => e.NotebookId);

                entity.ToTable("NotebookTBL");

                entity.Property(e => e.NotebookId).HasColumnName("NotebookID");

                entity.Property(e => e.Accessibility).HasMaxLength(50);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OnlineNotebookFormat).HasMaxLength(4000);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.NotebookTbl)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_NotebookTBL_SchoolTBL");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.NotebookTbl)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotebookTBL_SubjectTBL");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.NotebookTbl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotebookTBL_UserTBL");
            });

            modelBuilder.Entity<SchoolTbl>(entity =>
            {
                entity.HasKey(e => e.SchoolId);

                entity.ToTable("SchoolTBL");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SubjectTbl>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.ToTable("SubjectTBL");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInSchoolTbl>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SchoolId });

                entity.ToTable("UserInSchoolTBL");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.UserInSchoolTbl)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInSchoolTBL_SchoolTBL");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInSchoolTbl)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInSchoolTBL_UserTBL");
            });

            modelBuilder.Entity<UserTbl>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserTBL");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIrstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
