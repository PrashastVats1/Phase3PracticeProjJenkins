using Microsoft.AspNetCore.Mvc;
using Phase3JenkinsProj.Models;
using System.Collections.Generic;
using System.Linq;

namespace Phase3JenkinsProj.Controllers
{
    public class PizzasController : Controller
    {
        // Existing list of pizzas
        static List<Pizza> pizzas = new List<Pizza>
        {
            new Pizza(){ Id = 1, Name="Margherita", Description="A cheesy Pizza", Price=150 },
            new Pizza(){ Id = 2, Name="Farmhouse", Description="A Pizza with cheese, tomatoes, and onions", Price=200 },
            new Pizza(){ Id = 3, Name="Pepperoni", Description="A Pizza with cheese and pepperoni", Price=250 },
            new Pizza(){ Id = 4, Name="Spaghetti", Description="White sauce pasta", Price=160 },
            new Pizza(){ Id = 5, Name="Chicken Tikka Pizza", Description="A cheesy Pizza with chicken tikka cubes", Price=300 }
        };

        public IActionResult Index()
        {
            return View(pizzas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Pizza());
        }

        [HttpPost]
        public IActionResult Create(Pizza model)
        {
            if (ModelState.IsValid)
            {
                pizzas.Add(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // Find the pizza by ID
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);

            if (pizza == null)
            {
                return NotFound(); // Return a 404 Not Found response if not found
            }

            return View(pizza);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Find the pizza by ID
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);

            if (pizza == null)
            {
                return NotFound(); // Return a 404 Not Found response if not found
            }

            return View(pizza);
        }

        [HttpPost]
        public IActionResult Edit(Pizza model)
        {
            if (ModelState.IsValid)
            {
                // Find the pizza in the list and update its properties
                var pizzaToUpdate = pizzas.FirstOrDefault(p => p.Id == model.Id);

                if (pizzaToUpdate != null)
                {
                    pizzaToUpdate.Name = model.Name;
                    pizzaToUpdate.Description = model.Description;
                    pizzaToUpdate.Price = model.Price;
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Find the pizza by ID
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);

            if (pizza == null)
            {
                return NotFound(); // Return a 404 Not Found response if not found
            }

            return View(pizza);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Find and remove the pizza by ID
            var pizzaToDelete = pizzas.FirstOrDefault(p => p.Id == id);

            if (pizzaToDelete != null)
            {
                pizzas.Remove(pizzaToDelete);
            }

            return RedirectToAction("Index");
        }
    }
}
