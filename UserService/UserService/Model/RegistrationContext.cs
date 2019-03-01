using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class RegistrationContext : DbContext
    {

        public RegistrationContext(DbContextOptions<RegistrationContext> options)
            : base(options)
        {
        }

        public DbSet<Registration> _RegestrationDb { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().HasData(new Registration
            {
                id = 1,
                forename = "Conor",
                surename = "ONeill",
                email = "conor@version1.com",
                password = "conor123"

            }, new Registration
            {
                id=2,
                forename = "Uncle",
                surename  = "Bob",
                email = "uncle.bob@gmail.com",
                password = "bob123"
            });
        }


    }
}
