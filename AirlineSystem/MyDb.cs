using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirlineSystem
{
    public class MyDb : DbContext
    {
        public MyDb():base("Belalstr")
        {
        }
        public DbSet<ScheduleTrip> ScheduleTrips { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Trip> trips { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }

    }
}
