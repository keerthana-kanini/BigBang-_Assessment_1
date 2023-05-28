using Big_Bang__Assessment_1.Repository;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Big_Bang__Assessment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Room>> Get()
        {
            try
            {
                var rooms = roomRepository.GetRooms();
                return Ok(rooms);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while retrieving rooms.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Room> Get(int id)
        {
            try
            {
                var room = roomRepository.GetRoomById(id);
                if (room == null)
                {
                    return NotFound();
                }
                return room;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while retrieving the room.");
            }
        }

        [HttpPost]
        public ActionResult<Room> Post(Room room)
        {
            try
            {
                var createdRoom = roomRepository.CreateRoom(room);
                return CreatedAtAction("Get", new { id = createdRoom.Room_Id }, createdRoom);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while creating the room.");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Room> Put(int id, Room room)
        {
            try
            {
                if (id != room.Room_Id)
                {
                    return BadRequest();
                }
                var updatedRoom = roomRepository.UpdateRoom(id, room);
                if (updatedRoom == null)
                {
                    return NotFound();
                }
                return updatedRoom;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while updating the room.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                roomRepository.DeleteRoom(id);
                return NoContent();
            }
            catch (Exception)
            {
                // Log the exception or handle it as needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred while deleting the room.");
            }
        }


    }

}
