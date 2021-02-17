using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Room.API.Entities;
using Room.API.Repositories.Interfaces;

namespace Room.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _repository;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IRoomRepository repository, ILogger<RoomController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MeetingRoom>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> GetMeetingRooms()
        {
            var meetingRooms = await _repository.GetMeetingRooms();
            return Ok(meetingRooms);
        }

        [HttpGet("{id:length(24)}", Name = "GetMeetingRoom")]
        [ProducesResponseType(typeof(MeetingRoom), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(MeetingRoom), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> GetMeetingRoom(string id)
        {
            var meetingRoom = await _repository.GetMeetingRoom(id);
            if (meetingRoom == null)
            {
                _logger.LogError($"MeetingRoom with id: {id}, hasn't been found in database.");
                return NotFound();
            }

            return Ok(meetingRoom);
        }

        [Route("[action]/{capacity}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MeetingRoom>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> GetMeetingRoomByCapacity(int capacity)
        {
            var meetingRooms = await _repository.GetMeetingRoomByCapacity(capacity);
            return Ok(meetingRooms);
        }

        [Route("[action]/{location}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MeetingRoom>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MeetingRoom>>> GetMeetingRoomByLocation(int location)
        {
            var meetingRooms = await _repository.GetMeetingRoomsByLocation(location);
            return Ok(meetingRooms);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MeetingRoom), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<MeetingRoom>> CreateMeetingRoom([FromBody] MeetingRoom meetingRoom)
        {
            await _repository.Create(meetingRoom);

            return CreatedAtRoute("GetMeetingRoom", new { id = meetingRoom.Id }, meetingRoom);
        }

        [HttpPut]
        [ProducesResponseType(typeof(MeetingRoom), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMeetingRoom([FromBody] MeetingRoom value)
        {
            return Ok(await _repository.Update(value));
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMeetingRoomById(string id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
