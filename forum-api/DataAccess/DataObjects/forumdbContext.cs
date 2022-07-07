using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace forum_api.DataAccess.DataObjects
{
    public partial class forumdbContext : DbContext
    {
        public forumdbContext()
        {
        }

        public forumdbContext(DbContextOptions<forumdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;password=root;database=forum-db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Idcomment)
                    .HasName("PRIMARY");

                entity.ToTable("comment");

                entity.Property(e => e.Idcomment).HasColumnName("idcomment");

                entity.Property(e => e.Author)
                    .HasMaxLength(45)
                    .HasColumnName("author");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreation");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateUpdate");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.Idtopic)
                    .HasName("PRIMARY");

                entity.ToTable("topic");

                entity.HasIndex(e => e.CommentId, "comment_commentId_idx");

                entity.Property(e => e.Idtopic).HasColumnName("idtopic");

                entity.Property(e => e.Author)
                    .HasMaxLength(45)
                    .HasColumnName("author");

                entity.Property(e => e.CommentId).HasColumnName("commentId");

                entity.Property(e => e.DateCreation)
                    .HasColumnType("datetime")
                    .HasColumnName("dateCreation");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("dateUpdate");

                entity.Property(e => e.Title)
                    .HasMaxLength(45)
                    .HasColumnName("title");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("comment_commentId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
