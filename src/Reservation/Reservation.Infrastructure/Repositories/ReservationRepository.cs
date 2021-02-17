using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservation.Core.Entities;
using Reservation.Core.Repositories;
using Reservation.Infrastructure.Data;
using Reservation.Infrastructure.Repositories.Base;

namespace Reservation.Infrastructure.Repositories
{
    public class ReservationRepository : Repository<Reserve>, IReservationRepository
    {

        public ReservationRepository(ReservationContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Reserve>> GetRezervationsWithProducts()
        {
            var reservationList = await _dbContext
                                            .Reserves
                                            .Include(r => r.Products)
                                            .ToListAsync();

            return reservationList;
        }
    }
}
