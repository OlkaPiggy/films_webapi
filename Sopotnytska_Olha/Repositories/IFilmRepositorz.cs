using Sopotnytska_Olha.Models;

namespace Sopotnytska_Olha.Repositories
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Member>> Get();
        Task<Member> Get(int id);
        Task<Member> Create(Member film);
        Task Update(Member film);
        Task Delete(int id);
    }
}
