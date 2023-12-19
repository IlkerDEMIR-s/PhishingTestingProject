using Entitites.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Reflection;

namespace Repositories;
  public class RepositoryContext : IdentityDbContext<IdentityUser>
  {
      public DbSet<Campaign> Campaign { get; set; }
      public DbSet<SubmissionProfile> SubmissionProfile { get; set; }
      public DbSet<EmailTemplate> EmailTemplate { get; set; }
      public DbSet<SocialMediaLogin> SocialMediaLogin { get; set; }
      public DbSet<EmailLog> EmailClickLog { get; set; }




    public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
      {
                  
      }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Campaign>()
            .ToTable("Campaign");  // "Campaign" tablosunu kullanacağımızı belirtiyoruz
        modelBuilder.Entity<SubmissionProfile>()
            .ToTable("SubmissionProfile");  // "SubmissionProfile" tablosunu kullanacağımızı belirtiyoruz
        modelBuilder.Entity<EmailTemplate>()
            .ToTable("EmailTemplate");  // "EmailTemplate" tablosunu kullanacağımızı belirtiyoruz
        modelBuilder.Entity<SocialMediaLogin>()
            .ToTable("SocialMediaLogin");  // "InstagramLogin" tablosunu kullanacağımızı belirtiyoruz
        modelBuilder.Entity<EmailLog>()
            .ToTable("EmailLog");  // "EmailClickLog" tablosunu kullanacağımızı belirtiyoruz

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
    }

}
