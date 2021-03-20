using System.Threading.Tasks;
using TestTask.PostgreSQL.Entities;

namespace TestTask.PostgreSQL.Repository
{
    public interface IPersonRepository
    {
        Task<Person> Get(string lastName);
        Task<Person> GetById(int Id);
        Task<bool> Add(Person person);
    }
}