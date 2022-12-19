using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Code.Models;
using code.Models;

namespace code.DataModels
{

    public class CharacterContext : DbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> options) : base(options)
        {

        }

        public DbSet<Characters> Characters => Set<Characters>();





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Characters>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Characters>().ToTable("characters", schema: "character");


        }
    }
}