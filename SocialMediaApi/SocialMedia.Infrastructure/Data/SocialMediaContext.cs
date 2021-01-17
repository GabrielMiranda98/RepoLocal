using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SocialMedia.Core.Entities;
using SocialMedia.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SocialMedia.Infrastructure.Data
{
    public partial class SocialMediaContext : DbContext
    {
        #region Ctor
        public SocialMediaContext()
        {
        }

        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options)
        {
        }
        #endregion

        #region DbSet
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Security> Securities { get; set; }

        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());

            modelBuilder.ApplyConfiguration(new CommentConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        #endregion
    }
}
