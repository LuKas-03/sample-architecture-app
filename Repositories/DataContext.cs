using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DataContext : DbContext
    {
        internal DbSet<UserEntity> Users { get; set; }
        internal DbSet<NoteEntity> Notes { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Notes.db"); ;
        }
    }
}
