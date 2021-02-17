using System;
using AutoMapper;
using Reservation.Application.Commands;
using Reservation.Application.Responses;
using Reservation.Core.Entities;

namespace Reservation.Application.Mapper
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<Reserve, ReservationResponse>().ReverseMap();
            CreateMap<Reserve, CreateReservationCommand>().ReverseMap();
            CreateMap<Commands.Product, Core.Entities.Product>().ReverseMap();
            CreateMap<Commands.Product, ProductResponse>().ReverseMap();
            CreateMap<Core.Entities.Product, ProductResponse>().ReverseMap();
        }
    }
}
