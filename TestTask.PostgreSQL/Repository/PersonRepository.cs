using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Person Get(string LastName)
        {
            return _context.People.FirstOrDefault(x=>x.LastName == LastName);
        }

        public void Add(Person person)
        {

        }
    }
}
