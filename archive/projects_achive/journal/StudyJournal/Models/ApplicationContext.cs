using Microsoft.EntityFrameworkCore;

namespace StudyJournal.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Discipline> Disciplines { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
