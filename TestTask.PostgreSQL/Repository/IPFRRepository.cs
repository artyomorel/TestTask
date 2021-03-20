using System.Threading.Tasks;
using TestTask.PostgreSQL.Entities;

namespace TestTask.PostgreSQL.Repository
{
    public interface IPFRRepository
    {
        Task<PFR> Get(string Snils);
        Task<bool> Add(PFR Pfr);
    }
}