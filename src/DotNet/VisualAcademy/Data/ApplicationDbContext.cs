using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Models.Buffets;

namespace VisualAcademy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pizza>? Pizzas { get; set; }
        public DbSet<Topping>? Toppings { get; set; }
        public DbSet<Sauce>? Sauces { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    //builder.Entity<Pizza>()
        //    //    .HasMany(e => e.Toppings)
        //    //    .WithMany(e => e.Pizzas)
        //    //    .UsingEntity<Dictionary<string, object>>(
        //    //        "PizzasToppings",
        //    //        b => b.HasOne<Topping>().WithMany().HasForeignKey("ToppingId"),
        //    //        b => b.HasOne<Pizza>().WithMany().HasForeignKey("PizzaId") 
        //    //    );
        //}
    }
}