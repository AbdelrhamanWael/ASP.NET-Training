using Microsoft.AspNetCore.Mvc;
using ApiRoutingDrills.Models;
using ApiRoutingDrills.DTOs;
using System;
using System.Collections.Generic;

namespace ApiRoutingDrills.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        //Drill 06 - Create Note Endpoint

        private static readonly List<Note> _notes = new List<Note>();
        private static int _nextId = 1;


        [HttpPost]
        public IActionResult CreateNote([FromBody] CreateNoteRequest request)
        {
            var newNote = new Note
            {
                Id = _nextId++,
                Title = request.Title,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow
            };

            // Save to our in-memory storage list
            _notes.Add(newNote);

            // Requirement: Return 201 Created with the generated object
            // You can use CreatedAtAction or simply return StatusCode(201, object)
            return StatusCode(201, newNote);
        }

        //Drill 07 - Get Notes List
        [HttpGet]
        public IActionResult GetNotes()
        {
            if (!_notes.Any())
            {
                return NotFound(new
                {
                    success = false,
                    message = "No notes found in the database"
                });
            }
            return Ok(new
            {
                notes = _notes,
                success = true,
                message = "Notes found in the database"
            });
        }
        //Drill 08 - Get Note By Id
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var note = _notes.FirstOrDefault(n => n.Id == id);
            if (note == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Note not found in the database"
                });
            }
            return Ok(new
            {
                note = note,
                success = true,
                message = "Note found in the database"
            });
        }
        //Drill 09 - Update Note Endpoint

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, [FromBody] UpdateNoteRequest request)
        {
            // 1. Search the in-memory static list to find the existing note
            var existingNote = _notes.FirstOrDefault(n => n.Id == id);

            // 2. Requirement: Return 404 Not Found if the note is missing
            // Hint: Do not create a new note when the id does not exist (No "Upsert")
            if (existingNote == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"Note with ID {id} was not found."
                });
            }

            // 3. Update the values of the existing note in memory
            existingNote.Title = request.Title;
            existingNote.Content = request.Content;

            // 4. Requirement: Return the updated note with a 200 OK status code
            return Ok(existingNote);
        }

        //Drill 10 - Delete Note Endpoint
        [HttpDelete("{id:int}")]
        public IActionResult DeleteNote(int id)
        {
            var note = _notes.FirstOrDefault(n => n.Id == id);
            if (note == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = $"Note with ID {id} was not found."
                });
            }
            _notes.Remove(note);
            return NoContent();
        }

        //Drill 11 - Search Notes
        [HttpGet("search")]
        public IActionResult SearchNotes([FromQuery] string query)
        {
            var notes = _notes.Where(n => n.Title.Contains(query) || n.Content.Contains(query)).ToList();
            return Ok(notes);
        }
        //Drill 12 - Pagination Demo
        [HttpGet("paged")]
        public IActionResult GetNotes([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            // 1. Requirement: Validate pageNumber > 0
            if (pageNumber <= 0)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Validation Error",
                    errors = new[] { "pageNumber must be greater than 0." }
                });
            }

            // 2. Requirement: Validate pageSize between 1 and 50
            if (pageSize < 1 || pageSize > 50)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Validation Error",
                    errors = new[] { "pageSize must be between 1 and 50." }
                });
            }

            
            int totalCount = _notes.Count;

            
            var pagedItems = _notes
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // 4. Requirement: Return items, pageNumber, pageSize, and totalCount
            return Ok(new
            {
                items = pagedItems,
                pageNumber = pageNumber,
                pageSize = pageSize,
                totalCount = totalCount
            });
        }
        //Drill 13 - Header Reader Endpoint
        [HttpGet("request-info")]
        public IActionResult GetRequestInfo()
        {
            
            
            var studentName = Request.Headers["X-Student-Name"].FirstOrDefault();

            
            if (string.IsNullOrWhiteSpace(studentName))
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Validation Error",
                    errors = new[] { "The required custom header 'X-Student-Name' is missing." }
                });
            }

            // Requirement: Return header value and request path. Do not hardcode student name. [cite: 615, 616]
            return Ok(new
            {
                studentName = studentName,
                requestPath = HttpContext.Request.Path.Value
            });
        }


        // DRILL 14: Status Code Practice
        [HttpGet("status-200")]
        public IActionResult GetValidData()
        {
            return Ok(new { success = true, message = "Data retrieved successfully." });
        }

        // 2. Returns 201 Created
        [HttpPost("status-201")]
        public IActionResult CreateMockResource()
        {
            return StatusCode(201, new { id = 101, status = "Created", createdAt = DateTime.UtcNow });
        }

        // 3. Returns 204 No Content
        [HttpDelete("status-204")]
        public IActionResult DeleteMockResource()
        {
            return NoContent(); // Successfully deleted, returning empty body with status 204
        }

        // 4. Returns 400 Bad Request
        [HttpGet("status-400")]
        public IActionResult GetInvalidRequest()
        {
            return BadRequest(new { success = false, message = "The request payload or format is malformed." });
        }

        // 5. Returns 404 Not Found
        [HttpGet("status-404")]
        public IActionResult GetMissingResource()
        {
            return NotFound(new { success = false, message = "The requested entity could not be found on the server." });
        }
        // DRILL 15: Standard Error Shape
        [HttpGet("errors/demo")]
        public IActionResult GetErrorDemo([FromQuery] string type)
        {
        
            if (string.Equals(type, "notfound", StringComparison.OrdinalIgnoreCase))
            {
                return NotFound(new
                {
                    success = false,
                    message = "Resource Not Found",
                    errors = new[] { "The requested entity ID 999 does not exist in our system database." }
                });
            }

            
            return BadRequest(new
            {
                success = false,
                message = "Invalid request",
                errors = new[] { "Name is required", "Age must be a positive integer." }
            });
        }


    }
}
