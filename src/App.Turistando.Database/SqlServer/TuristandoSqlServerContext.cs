using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using App.Turistando.Database.SqlServer.Entities;

namespace App.Turistando.Database.SqlServer
{
    public class TuristandoSqlServerContext : DbContext
    {

        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
            new LoggerFactory(new[] {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        });

        public TuristandoSqlServerContext(DbContextOptions<TuristandoSqlServerContext> options)
            : base(options)
        {}

        //ordem alfabética
        public DbSet<UsuariosCadastradosEntity> UsuariosCadastrados { get; set; }      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuariosCadastradosEntity>()
            .Property(s => s.Id)
            .HasColumnName("usc_id")
            .HasDefaultValue(0)
            .IsRequired();
        }
    }
}
