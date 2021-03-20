using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestTask.MVC.Models;
using TestTask.PostgreSQL.Repository;

namespace TestTask.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPFRRepository _pfrRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public HomeController(IPFRRepository pfrRepository, IPersonRepository personRepository, IMapper mapper)
        {
            _pfrRepository = pfrRepository;
            _personRepository = personRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Info", "Home", person);
            }
            return View(person);

        }

        public async Task<IActionResult> Info(Person personDto)
        {
            var Pfr = await _pfrRepository.Get(personDto.Snils);
            PostgreSQL.Entities.Person personDb;
            if (Pfr == null)
            {
                var personEntitiesDb = _mapper.Map<PostgreSQL.Entities.Person>(personDto);
                await _personRepository.Add(personEntitiesDb);

                personDb = await _personRepository.Get(personEntitiesDb.LastName);
                var personDbId = personDb.PersonId;
                await _pfrRepository.Add(new PostgreSQL.Entities.PFR { Snils = personDto.Snils ,PersonId = personDbId});
            }

            Pfr = await _pfrRepository.Get(personDto.Snils);
            personDb = await _personRepository.GetById(Pfr.PersonId);
            var newPfr = _mapper.Map<PFR>(Pfr);
            var newPerson = _mapper.Map<Person>(personDb);
            Tuple<Person, PFR> tuple = new Tuple<Person, PFR>(newPerson, newPfr);
            return View(tuple);

        }
    }
}
