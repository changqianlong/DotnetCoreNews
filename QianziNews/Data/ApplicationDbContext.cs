using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QianziNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QianziNews.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<NewsImage> NewsImage { get; set; }
        public DbSet<NewsDetail> NewsDetail { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<News>(
                e =>
                {
                    e.Property(p => p.PostTime)
                    .HasDefaultValueSql("getDate()");
                }
                );

            builder.Entity<News>()
                .Property(n => n.Author)
                .HasDefaultValue("匿名");

            builder.Entity<News>()
                .Property(n => n.Source)
                .HasDefaultValue("无");

            //设置NewsImage外键关联News
            builder.Entity<NewsImage>()
                .HasOne(n => n.News)
                .WithMany(p => p.Images)
                .HasForeignKey(p => p.NewsId)
                .HasConstraintName("ForeignKey_NewsImage_News");



            //设置NewsDetail外键关联News
            builder.Entity<NewsDetail>()
                .HasOne(d => d.News)
                .WithOne(n => n.Detail)
                .HasForeignKey("NewsDetail", "NewsId")
                .HasConstraintName("ForeignKey_NewsDetail_News");

            //设置Comment外键关联News
            builder.Entity<Comment>()
                .HasOne(c => c.News)
                .WithMany(n => n.Comments)
                .HasForeignKey(c => c.NewsId)
                .HasConstraintName("ForeignKey_Comment_News");
            builder.Entity<Comment>()
                .Property(p => p.Zan)
                .HasDefaultValue(0);
        }

    }
}
