using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MN_SO_APS_PROJECT.Areas.Identity.Data;
using MN_SO_APS_PROJECT.Models;

namespace MN_SO_APS_PROJECT.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    public DbSet<CommentModel> Comment { get; set; }
    public DbSet<CityModel> City { get; set; }
    public DbSet<CountryModel> Coutry { get;set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CityModel>().HasData(
            new CityModel() { Id = 1, CityName = "Kraków"},
            new CityModel() { Id = 2, CityName = "Wrocław" },
            new CityModel() { Id = 3, CityName = "Warszawa" }
            );

        builder.Entity<CountryModel>().HasData(
            new CountryModel() { Id = 1, CountryName = "Poland" },
            new CountryModel() { Id = 2, CountryName = "United Kingdom" },
            new CountryModel() { Id = 3, CountryName = "Czech Republic" }
            );

        base.OnModelCreating(builder);
    }

    private class ApplicationUserEntityConfiguration :
        IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Email).HasMaxLength(255);
            builder.Property(x => x.Login).HasMaxLength(255);
            builder.Property(x => x.Password).HasMaxLength(255);
        }
    }
}
