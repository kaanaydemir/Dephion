using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Reservation.Core.Entities;

namespace Reservation.Infrastructure.Data
{
    public class ReservationContextSeed
    {
        public static async Task SeedAsync(ReservationContext reservationContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                reservationContext.Database.Migrate();
                //reservationContext.Database.EnsureCreated();

                if (!reservationContext.Reserves.Any())
                {
                    reservationContext.Reserves.AddRange(GetPreconfiguredOrders());
                    await reservationContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<ReservationContextSeed>();
                    log.LogError(exception.Message);
                    System.Threading.Thread.Sleep(2000);
                    await SeedAsync(reservationContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Reserve> GetPreconfiguredOrders()
        {
            return new List<Reserve>()
            {
                new Reserve() {
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(2),
                    Name = "MyReservation",
                    RoomId = "RoomId",
                    //Products = new List<Product>()
                    //    { new Product()
                    //        { Name = "myProduct", Category = 1, Type = 1
                    //    }
                    //}
                },
            };
        }
    }
}
