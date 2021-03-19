using System.Threading.Tasks;
using TestTask.PostgreSQL.Entities;

namespace TestTask.PostgreSQL.Repository
{
    public interface IPersonRepository
    {
        Task<Person> Get(string LastName);
        Task<bool> Add(Person person);
    }
}