using Microsoft.EntityFrameworkCore;
using SportData.Models;

namespace SportData.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Coach> Coach { get; set; }
    
        public DbSet<Sport> Sport { get; set; }

        public DbSet<Organisation> Organisation { get; set; }

        public DbSet<Evenement> Evenement { get; set; }

        public DbSet<SpecificiteEvenement> SpecificiteEvenement { get; set; }

        public DbSet<Administrateur> Administrateur { get; set; }

        public DbSet<Employe> Employe { get; set; }


        //public DbSet<Utilisateur> Utilisateur { get; set; }
    }
}
