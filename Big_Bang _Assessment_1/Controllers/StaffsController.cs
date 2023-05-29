using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Big_Bang__Assessment_1.DB;
using ClassLibrary.Models;
using Big_Bang__Assessment_1.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Big_Bang__Assessment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   [Authorize]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;

        public StaffsController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        // GET: api/Staffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            var staffs = await _staffRepository.GetStaffs();
            return Ok(staffs);
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _staffRepository.GetStaff(id);
            if (staff == null)
                return NotFound();

            return Ok(staff);
        }

        // PUT: api/Staffs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            var success = await _staffRepository.UpdateStaff(id, staff);
            if (!success)
                return NotFound();

            return NoContent();
        }

        // POST: api/Staffs
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            var createdStaff = await _staffRepository.CreateStaff(staff);
            if (createdStaff == null)
                return Problem("Failed to create staff.");

            return CreatedAtAction("GetStaff", new { id = createdStaff.StaffId }, createdStaff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var success = await _staffRepository.DeleteStaff(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}

