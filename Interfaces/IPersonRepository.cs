using app.Data;

namespace app.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetAsync(int Id);
        Task<List<Person>> GetAsync(IEnumerable<int> Ids);
        Task<Person> AddAsync(Person person);
        Task SaveChangesAsync();
    }
}