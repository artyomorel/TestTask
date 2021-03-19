using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using TestTask.MVC.Models;
using TestTask.PostgreSQL.Repository;

namespace TestTask.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPFRRepository _pfrRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public HomeController(IPFRRepository pfrRepository, IPersonRepository personRepository,IMapper mapper)
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

        public IActionResult Info(Person person)
        {
            if(_personRepository.Get(person.LastName) == null)
            {
                var newPerson = _mapper.Map<PostgreSQL.Entities.Person>(person);
                _personRepository.Add(newPerson);
            }
            var Pfr = _mapper.Map<PFR>(_pfrRepository.Get(person.Snils));

            Tuple<Person,PFR> tuple = new Tuple<Person, PFR>(person, Pfr);
            return View(tuple);
        }
    }
}
