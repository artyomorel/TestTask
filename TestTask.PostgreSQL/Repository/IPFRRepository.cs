using TestTask.PostgreSQL.Entities;

namespace TestTask.PostgreSQL.Repository
{
    public interface IPFRRepository
    {
        PFR Get(string Snils);
    }
}