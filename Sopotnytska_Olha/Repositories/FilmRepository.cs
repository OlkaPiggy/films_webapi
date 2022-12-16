using System.Data.Entity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Sopotnytska_Olha.Models;

namespace Sopotnytska_Olha.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly FilmsContext _context;
        public FilmRepository(FilmsContext context)
        {
            this._context = context;
        }
        public async Task<Member> Create(Member film)
        {
            _context.Members.Add(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task Delete(int id)
        {
            var filmToDelete = await _context.Members.FindAsync(id);
            _context.Members.Remove(filmToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Member>> Get()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> Get(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task Update(Member film)
        {
            _context.Entry(film).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
