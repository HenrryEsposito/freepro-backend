using System.Threading.Tasks;
using FreePro.Domain;
using FreePro.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreePro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private IFreeProRepository _repo { get; }
        public MeetingController(IFreeProRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {             
                var results = await _repo.GetAllMeetings(true);
                return Ok(results);                
            }
            catch (System.Exception err)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, err);
            }
        }

        [HttpGet("{MeetingId}")]
        public async Task<IActionResult> Get(int MeetingId)
        {
            try
            {             
                var results = await _repo.GetMeetingById(MeetingId, true);
                return Ok(results);                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("getByTheme/{theme}")]
        public async Task<IActionResult> Get(string theme)
        {
            try
            {             
                var results = await _repo.GetAllMeetingsByTheme(theme, true);
                return Ok(results);                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Meeting meeting)
        {
            try
            {             
                _repo.Add(meeting);

                if(await _repo.SaveChanges()){
                    return Created($"/api/evento/{meeting.Id}", meeting);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int MeetingId, Meeting meeting)
        {
            try
            {  
                var tryFindMeeting = await _repo.GetMeetingById(MeetingId, false);
                _repo.Update(meeting);

                if(tryFindMeeting == null){
                    return NotFound();
                }

                if(await _repo.SaveChanges()){
                    return Created($"/api/evento/{meeting.Id}", meeting);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int MeetingId)
        {
            try
            {  
                var tryFindMeeting = await _repo.GetMeetingById(MeetingId, false);
                _repo.Delete(tryFindMeeting);

                if(tryFindMeeting == null){
                    return NotFound();
                }

                if(await _repo.SaveChanges()){
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

            return BadRequest();
        }
    }
}