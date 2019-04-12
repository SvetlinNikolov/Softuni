using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new GameStoreDbContext())
            {
                var allGames = db.Games.ToList();
                return View(allGames);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            Game currentGame = new Game
            {
                Name = game.Name,
                Dlc = game.Dlc,
                Price = game.Price,
                Platform = game.Platform
            };
            using (var db = new GameStoreDbContext())
            {
                db.Games.Add(currentGame);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new GameStoreDbContext())
            {
                var gameToEdit = db.Games.FirstOrDefault(t => t.Id == id);
                if (gameToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(gameToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new GameStoreDbContext())
            {
                var gameToEdit = db.Games.FirstOrDefault(t => t.Id == game.Id);
                gameToEdit.Name = game.Name;
                gameToEdit.Price = game.Price;
                gameToEdit.Platform = game.Platform;
                gameToEdit.Dlc = game.Dlc;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (var db = new GameStoreDbContext())
            {
                var gameToDelete = db.Games.FirstOrDefault(t => t.Id == id);
                if (gameToDelete == null)
                {
                    RedirectToAction("Index");
                }
                db.Games.Remove(gameToDelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Game game)
        {
            using (var db = new GameStoreDbContext())
            {
                var gameToDelete = db.Games.FirstOrDefault(t => t.Id == game.Id);
                if (gameToDelete == null)
                {
                    return RedirectToAction("Index");
                }
                return View(gameToDelete);
            }

        }
    }

}

