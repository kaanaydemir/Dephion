using System;
using System.Collections;
using System.Collections.Generic;
using MediatR;
using Reservation.Application.Responses;

namespace Reservation.Application.Queries
{
    public class GetRezervationsWithProductsQuery : IRequest<IEnumerable<ReservationResponse>>
    {
        
        public GetRezervationsWithProductsQuery()
        {
        }
    }
}
