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

        public async Task<Person> Get(string lastName)
        {
            return await _context.People.AsNoTracking().FirstOrDefaultAsync(x=>x.LastName == lastName);
        }

        public async Task<Person> GetById(int Id)
        {
            return await _context.People.AsNoTracking().FirstOrDefaultAsync(x => x.PersonId == Id);
        }

        public async Task<bool> Add(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
