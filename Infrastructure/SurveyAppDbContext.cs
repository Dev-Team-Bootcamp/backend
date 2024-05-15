using Domain.Model;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Infrastructure;

public class SurveyAppDbContext : DbContext
{
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<Vote> Votes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new NpgsqlDataSourceBuilder("Server=localhost;Port=5432;Database=survey;Userid=postgres;Password=123456;Include Error Detail=True;");
        builder.EnableDynamicJson(); 
        var dataSource = builder.Build();
        optionsBuilder.UseNpgsql(dataSource);
        base.OnConfiguring(optionsBuilder);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SurveyConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}