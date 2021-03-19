using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestTask.PostgreSQL.Entities;

namespace TestTask.PostgreSQL.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Person> Get(string Snils)
        {
            return await _context.People.AsNoTracking().FirstOrDefaultAsync(x=>x.Snils == Snils);
        }

        public async Task<bool> Add(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
