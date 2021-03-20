using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestTask.PostgreSQL.Entities;

namespace TestTask.PostgreSQL.Repository
{
    public class PFRRepository : IPFRRepository
    {
        private readonly DataContext _context;

        public PFRRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PFR> Get(string Snils)
        {
            return await _context.PFRs.FirstOrDefaultAsync(x => x.Snils == Snils);
        }

        public async Task<bool> Add(PFR Pfr)
        {
            await _context.PFRs.AddAsync(Pfr);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
