using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.Data;
using SuperHero.Models;

namespace SuperHero.Controllers
{
    public class Super_HeroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Super_HeroController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: SuperHero
        public ActionResult Index()
        {
            List<Models.Hero> heroes = _context.SuperHeroes.ToList();
            return View(heroes);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int ID)
        {
            Hero heroDetails = _context.SuperHeroes.Where(s => s.ID == ID).FirstOrDefault();
            return View(heroDetails);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: SuperHero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hero hero)
        {
            try
            {
                // TODO: Add insert logic here

                _context.SuperHeroes.Add(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {

            Hero heroDetails = _context.SuperHeroes.Find(id);
            return View(heroDetails);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hero hero)
        {
            try
            {
                // TODO: Add update logic here
                Hero heroDetails = _context.SuperHeroes.Find(hero.ID);
                heroDetails.Name = hero.Name;
                heroDetails.PrimaryAbilty = hero.PrimaryAbilty;
                heroDetails.PrimaryAbilty = hero.SecondaryAbilty;
                heroDetails.AlterEgo = hero.AlterEgo;
                heroDetails.CatchPhrase = hero.AlterEgo;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            Hero hero = _context.SuperHeroes.Where(s => s.ID == id).FirstOrDefault();
            return View(hero);
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Hero hero)
        {
            try
            {
                _context.SuperHeroes.Remove(hero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}