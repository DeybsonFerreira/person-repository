using app.Data;
using app.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private ProjectContext _context { get; set; }
        public PersonRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Person> GetAsync(int Id)
        {
            var query = _context.Person.Where(i => i.Id == Id).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Person>> GetAsync(IEnumerable<int> Ids)
        {
            var query = _context.Person.Where(i => Ids.Contains(i.Id));
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<Person> AddAsync(Person person)
        {
            await _context.Person.AddAsync(person);
            return person;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}