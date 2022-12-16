using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sopotnytska_Olha.Models;
using Sopotnytska_Olha.Repositories;

namespace Sopotnytska_Olha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository filmRepository1;
        public FilmsController(IFilmRepository hotelRepository)
        {
            filmRepository1 = hotelRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Member>> GetFilms()
        {
            return await filmRepository1.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetFilms(int id)
        {
            return await filmRepository1.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Member>> PostFilms([FromBody] Member hotel)
        {
            var newFilm = await filmRepository1.Create(hotel);
            return CreatedAtAction(nameof(GetFilms), new { id = newFilm.Id }, newFilm);
        }

        [HttpPut]
        public async Task<ActionResult<Member>> UpdateFilms(int id, [FromBody] Member hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }
            await filmRepository1.Update(hotel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filmtoDelete = await filmRepository1.Get(id);
            if (filmtoDelete == null)
                return NotFound();
            await filmRepository1.Delete(filmtoDelete.Id);
            return NoContent();
        }
    }
}
