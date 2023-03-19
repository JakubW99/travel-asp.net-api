using Microsoft.EntityFrameworkCore;
using travel_asp.net_api.Models;

namespace travel_asp.net_api
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {

        }
        public DbSet<Excursion> Excursions { get; set;}
        public  DbSet<Order> Orders { get; set;}

        public DbSet<UserExcursion> UserExcursions { get;set;}
    }
}
