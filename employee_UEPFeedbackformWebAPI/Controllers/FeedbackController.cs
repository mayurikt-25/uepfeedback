using employee_UEPFeedbackformWebAPI.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employee_UEPFeedbackformWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly UepFeedbackContext _context;

        public FeedbackController(UepFeedbackContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("QuestionDetails")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return question;
        }

        [HttpPost]
        public async Task<ActionResult<Question>> Post(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestion", new { id = question.QuestionId }, question);
        }

        [HttpGet]
        [Route("CategoryDetails")]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return await _context.Categories.ToListAsync();
        }



        [HttpGet]
        [Route("CourseDetails")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        [HttpGet]
        [Route("ResponseDetails")]
        public async Task<ActionResult<IEnumerable<Response>>> GetRespons()
        {
            return await _context.Responses.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetResponse(int id)
        {
            var response = await _context.Responses.FindAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }
        [HttpPost]
        [Route("PostResponse")]
        public async Task<ActionResult<Response>> PostResponse(Response response)
        {
            _context.Responses.Add(response);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResponse", new { id = response.ResponseId }, response);
        }
    }
}
