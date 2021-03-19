using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public PFR Get(string Snils)
        {
            return _context.PFRs.FirstOrDefault(x => x.Snils == Snils);
        }
    }
}
