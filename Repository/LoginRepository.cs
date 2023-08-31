using app.Data;
using app.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private ProjectContext _context { get; set; }
        public LoginRepository(ProjectContext context)
        {
            _context = context;
        }

        public async Task<Login> GetAsync(int Id)
        {
            var query = _context.Login.Where(i => i.Id == Id).AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Login>> GetAsync(IEnumerable<int> Ids)
        {
            var query = _context.Login.Where(i => Ids.Contains(i.Id));
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<Login> AddAsync(Login login)
        {
            await _context.Login.AddAsync(login);
            return login;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}