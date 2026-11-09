using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RaceDayy.Models;   // <-- change if your model classes are in a different namespace

namespace RaceDayy.Data  // <-- keep whatever namespace your original file had
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Fix the decimal warning
            builder.Entity<Event>()
                .Property(e => e.DistanceKm)
                .HasPrecision(8, 2);

            // Fix "multiple cascade paths": make every non-Identity relationship Restrict...
            foreach (var fk in builder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()))
            {
                var ns = fk.DeclaringEntityType.ClrType.Namespace ?? "";
                if (ns.StartsWith("Microsoft.AspNetCore.Identity")) continue;

                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // ...except Event -> Category and Event -> Enrolment, which cascade
            // (deleting an event removes its categories and enrolments)
            foreach (var fk in builder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()))
            {
                if (fk.PrincipalEntityType.ClrType == typeof(Event) &&
                    (fk.DeclaringEntityType.ClrType == typeof(Category) ||
                     fk.DeclaringEntityType.ClrType == typeof(Enrolment)))
                {
                    fk.DeleteBehavior = DeleteBehavior.Cascade;
                }
            }
        }
    }
}