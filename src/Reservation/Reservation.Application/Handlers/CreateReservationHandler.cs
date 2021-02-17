using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands;
using Reservation.Application.Mapper;
using Reservation.Application.Responses;
using Reservation.Core.Entities;
using Reservation.Core.Repositories;

namespace Reservation.Application.Handlers
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand, ReservationResponse>
    {
        private readonly IReservationRepository _repository;

        public CreateReservationHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReservationResponse> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationEntity = ReservationMapper.Mapper.Map<Reserve>(request);
            if (reservationEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newOrder = await _repository.AddAsync(reservationEntity);

            var reservationResponse = ReservationMapper.Mapper.Map<ReservationResponse>(newOrder);
            return reservationResponse;
        }
    }
}
