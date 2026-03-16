using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using okruhy_pujcovnaMVCAPP.Data;
using okruhy_pujcovnaMVCAPP.Entities;
using System.Globalization;
using System.Linq;
using okruhy_pujcovnaMVCAPP.Models;
using Microsoft.EntityFrameworkCore;


namespace okruhy_pujcovnaMVCAPP.Controllers
{
    [Authorize]
    public class CircuitsController : Controller
    {
        public AppDbContext DbContext { get; set; }

        public CircuitsController()
        {
            DbContext = new AppDbContext();
        }

        
        public IActionResult Index()
        {
            var circuits = DbContext.Circuits.ToList();
            return View(circuits);
        }

      
        public IActionResult Detail(int id)
        {
            var circuit = DbContext.Circuits.FirstOrDefault(x => x.CircuitId == id);
            if (circuit == null) return NotFound();

            // vezmeme dostupná auta z tabulky CircuitCars pro tento okruh
            var cars = DbContext.CircuitCars
                .Include(x => x.Car)
                .Where(x => x.circuit_id == id && x.is_available)
                .Select(x => x.Car)
                .ToList();

            var vm = new CircuitDetailVM
            {
                Circuit = circuit,
                AvailableCars = cars
            };

            return View(vm);
        }


       
        [HttpGet]
        public IActionResult Create()
        {
            if (User.Identity.Name != "Admin")
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string name, string country, string lengthKm)
        {
            if (User.Identity.Name != "Admin")
            {
                return RedirectToAction("Index");
            }
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    ViewBag.Error = "Vyplň název okruhu.";
                    return View();
                }

                decimal length = 0;
                if (!decimal.TryParse(lengthKm?.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out length))
                    length = 0;

                var c = new circuit
                {
                    Name = name,
                    country = country,
                    lenghtkm = length
                };

                DbContext.Circuits.Add(c);
                DbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = "Chyba při ukládání: " + ex.Message;
                return View();
            }
        }

        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (User.Identity.Name != "Admin")
            {
                return RedirectToAction("Index");
            }
            var c = DbContext.Circuits.FirstOrDefault(x => x.CircuitId == id);
            if (c == null) return NotFound();
            return View(c);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string name, string country, string lengthKm)
        {
            if (User.Identity.Name != "Admin")
            {
                return RedirectToAction("Index");
            }
            try
            {
                var c = DbContext.Circuits.FirstOrDefault(x => x.CircuitId == id);
                if (c == null) return NotFound();

                if (string.IsNullOrWhiteSpace(name))
                {
                    ViewBag.Error = "Vyplň název okruhu.";
                    return View(c);
                }

                decimal length = c.lenghtkm ?? 0m;

                if (decimal.TryParse(lengthKm?.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal parsed))
                {
                    length = parsed;
                }

                c.Name = name;
                c.country = country;
                c.lenghtkm = length;

                DbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (System.Exception ex)
            {
                ViewBag.Error = "Chyba při ukládání: " + ex.Message;
                var c = DbContext.Circuits.FirstOrDefault(x => x.CircuitId == id);
                return View(c);
            }
        }

       
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (User.Identity.Name != "Admin")
            {
                return RedirectToAction("Index");
            }
            var c = DbContext.Circuits.FirstOrDefault(x => x.CircuitId == id);
            if (c == null) return NotFound();
            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.Name != "Admin")
            {
                return RedirectToAction("Index");
            }
            var c = DbContext.Circuits.FirstOrDefault(x => x.CircuitId == id);
            if (c == null) return NotFound();

            DbContext.Circuits.Remove(c);
            DbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
