using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Code.Models;
using code.Models;

namespace code.DataModels

{

    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
       
        }

        public DbSet<Players> Players => Set<Players>();

    

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        
            modelBuilder.Entity<Players>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Players>().ToTable("players", schema: "character");
         
        
        }
    

    
    }
}





