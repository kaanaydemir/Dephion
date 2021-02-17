using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Mapper;
using Reservation.Application.Queries;
using Reservation.Application.Responses;
using Reservation.Core.Repositories;

namespace Reservation.Application.Handlers
{
    public class GetRezervationsWithProductsHandler : IRequestHandler<GetRezervationsWithProductsQuery, IEnumerable<ReservationResponse>>
    {

        private readonly IReservationRepository _repository;

        public GetRezervationsWithProductsHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReservationResponse>> Handle(GetRezervationsWithProductsQuery request, CancellationToken cancellationToken)
        {
            var reservationList = await _repository.GetRezervationsWithProducts();

            var reservationResponseList = ReservationMapper.Mapper.Map<IEnumerable<ReservationResponse>>(reservationList);

            return reservationResponseList;
        }
    }
}
