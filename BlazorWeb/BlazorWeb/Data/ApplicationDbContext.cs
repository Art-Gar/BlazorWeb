using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BlazorWeb.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentVote> CommentVotes { get; set; }
        public DbSet<PostVote> PostVotes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Post>(post =>
            {
                post.ToTable("Posts");
                post.HasKey(p => p.Id);
                post.Property<string>(p => p.Body);
                post.Property<string>(p => p.Title);
                post.Property<DateTime?>(p => p.CreatedAt).HasDefaultValue(DateTime.Now);
                post.HasOne(p => p.Author).WithMany(a => a.Posts).HasForeignKey("UserId").OnDelete(DeleteBehavior.Restrict);
                post.HasMany(p => p.Comments).WithOne(u => u.Post);
                post.HasMany(p => p.Votes).WithOne(v => v.Post).HasForeignKey("PostId");
            });

            builder.Entity<Comment>(
                com =>
                {
                    com.ToTable("Comments");
                    com.HasKey(c => c.Id);
                    com.Property(c => c.Body).HasColumnName("body");
                    com.HasOne(c => c.Author).WithMany(u => u.Comments).HasForeignKey("UserId").OnDelete(DeleteBehavior.Restrict);
                    com.HasMany(c => c.Votes).WithOne(v => v.Comment).HasForeignKey("CommentId");
                });
                        builder.Entity<CommentVote>(
                vote =>
                {
                    vote.ToTable("CommentVotes");
                    vote.HasKey(v => v.Id);
                    vote.Property(v => v.Liked).HasColumnName("Liked");
                    vote.HasOne(vote => vote.User).WithMany(u => u.CommentVotes).HasForeignKey("UserId").OnDelete(DeleteBehavior.Restrict);

                });
            builder.Entity<PostVote>(
                vote =>
                {
                    vote.ToTable("PostVotes");
                    vote.HasKey(v => v.Id);
                    vote.Property(v => v.Liked).HasColumnName("Liked");
                    vote.HasOne(vote => vote.User).WithMany(u => u.PostVotes).HasForeignKey("UserId").OnDelete(DeleteBehavior.Restrict);

                });
        }
    }
}
 