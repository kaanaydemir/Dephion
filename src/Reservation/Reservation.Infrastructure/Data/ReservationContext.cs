using System;
using Microsoft.EntityFrameworkCore;
using Reservation.Core.Entities;

namespace Reservation.Infrastructure.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options):base(options)
        {

        }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
