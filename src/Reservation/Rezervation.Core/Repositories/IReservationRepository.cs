using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservation.Core.Entities;
using Rezervation.Core.Repositories.Base;

namespace Reservation.Core.Repositories
{
    public interface IReservationRepository : IRepository<Reserve>
    {
        Task<IEnumerable<Reserve>> GetRezervationsWithProducts();
    }
}
