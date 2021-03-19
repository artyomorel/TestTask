using TestTask.PostgreSQL.Entities;

namespace TestTask.PostgreSQL.Repository
{
    public interface IPersonRepository
    {
        Person Get(string LastName);
        void Add(Person person);
    }
}