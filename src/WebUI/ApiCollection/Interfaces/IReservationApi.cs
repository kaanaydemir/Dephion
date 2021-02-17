using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.ApiCollection.Interfaces
{
    public interface IReservationApi
    {
        Task<IEnumerable<ReservationModel>> GetReservations();
        Task<ReservationModel> CreateReservation(ReservationModel model);
    }
}
