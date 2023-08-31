using app.Data;

namespace app.Interfaces
{
    public interface ILoginRepository
    {
        Task<Login> GetAsync(int Id);
        Task<List<Login>> GetAsync(IEnumerable<int> Ids);
        Task<Login> AddAsync(Login login);
        Task SaveChangesAsync();
    }
}