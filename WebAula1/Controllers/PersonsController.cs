using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAula1.Models;

namespace WebAula1.Controllers
{
    public class PersonsController : Controller
    {
        private readonly Context _context;

        public PersonsController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Atualizar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var person = _context.Persons.Find(id);
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Atualizar(int id, Person person)
        {
            if(id == null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                _context.Update(person);
                _context.SaveChanges();
                return RedirectToAction(nameof(ExibirCadastros));
            }

            return View(person);
        }

        public IActionResult Detalhes(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var person = _context.Persons.FirstOrDefault(x => x.PersonId == id);

            return View(person);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _context.Persons.FirstOrDefault(x => x.PersonId == id);

            return View(person);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExcluir(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var person = _context.Persons.FirstOrDefault(x => x.PersonId == id);
            _context.Remove(person);
            _context.SaveChanges();
            return RedirectToAction(nameof(ExibirCadastros));
        }

        [HttpGet]
        public IActionResult ExibirCadastros()
        {
            return View(_context.Persons.ToList());
        }

        [HttpGet]
        public IActionResult NewPerson()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }
    }
}
