using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental_Services.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<AuthDetails> Authtable { get; set; } // 

        public DbSet<VehicleDetails> Vehicletable { get; set; }

        public DbSet<BookingDetails> Bookingtable { get; set; }

        public DbSet<HubDetails> Hubtable { get; set; }

        public DbSet<ProfileDetails> ProfileDetailstables { get; set; }
    }
}
