using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreRecord.Models
{

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
    }

    public class RssBlog : Blog
    {
        public string RssUrl { get; set; }
    }


    public class DotNetCoreRecordContext : DbContext
    {
        public DotNetCoreRecordContext(DbContextOptions opt) : base(opt)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Persion> Persions { get; set; }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<RssBlog> RssBlogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(e =>
            {
                e.HasIndex(x => x.UserName);
                e.HasIndex(x => x.Sex);
                e.Ignore(z => z.AddTime);
                e.HasAlternateKey(z => z.Address);
            });
            modelBuilder.Entity<Account>().Property(z => z.LastLoginTime)
                //.ValueGeneratedOnAdd()
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Persion>().Property<Sex>("Sex").HasColumnName("sex");


            modelBuilder.Entity<RssBlog>().ToTable("RssBlog", schema: "RssBlog");
            modelBuilder.Entity<Blog>()
            .HasDiscriminator<string>("blog_type")
            .HasValue<Blog>("blog_base")
            .HasValue<RssBlog>("blog_rss");
            modelBuilder.Entity<Blog>().HasIndex(z => z.Url)
                .IsUnique(unique: true);
        }
    }
}
