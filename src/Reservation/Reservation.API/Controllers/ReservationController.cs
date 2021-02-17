using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reservation.Application.Commands;
using Reservation.Application.Queries;
using Reservation.Application.Responses;

namespace Reservation.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IMediator mediator, ILogger<ReservationController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReservationResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ReservationResponse>>> GetReservations()
        {
            var query = new GetRezervationsWithProductsQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ReservationResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateReservation([FromBody] CreateReservationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
