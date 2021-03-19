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

        public async Task<IActionResult> Info(Person person)
        {

            var personDb = await _personRepository.Get(person.LastName);
            if (personDb == null)
            {
                var newPerson = _mapper.Map<PostgreSQL.Entities.Person>(person);
                await _personRepository.Add(newPerson);
            }

            var Pfr = await _pfrRepository.Get(person.Snils);
            var newPfr = _mapper.Map<PFR>(Pfr);
            Tuple<Person, PFR> tuple = new Tuple<Person, PFR>(person, newPfr);
            return View(tuple);

        }
    }
}
