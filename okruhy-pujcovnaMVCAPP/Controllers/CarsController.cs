using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using okruhy_pujcovnaMVCAPP.Data;
using okruhy_pujcovnaMVCAPP.Entities;
using System.Linq;

namespace okruhy_pujcovnaMVCAPP.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        public AppDbContext DbContext { get; set; }

        public CarsController()
        {
            DbContext = new AppDbContext();
        }

        public IActionResult Index()
        {
            var cars = DbContext.Cars.OrderBy(c => c.brand).ThenBy(c => c.model).ToList();
            return View(cars);
        }

        public IActionResult Detail(int id)
        {
            var car = DbContext.Cars.FirstOrDefault(x => x.car_id == id);
            if (car == null) return NotFound();
            return View(car);
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
        public IActionResult Create(string brand, string model, int powerHp, decimal pricePerDay, string detail, string transmision)
        {
            if(User.Identity.Name != "Admin")
            {
                return RedirectToAction("Index");
            }
            if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model))
            {
                ViewBag.Error = "Vyplň značku a model.";
                return View();
            }

            var c = new car
            {
                brand = brand,
                model = model,
                power_hp = powerHp,
                price_per_day = pricePerDay,
                detail = detail,
                transmision = transmision
            };

            DbContext.Cars.Add(c);
            DbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (User.Identity.Name != "Admin")
            {
                return RedirectToAction("Index");
            }
            var car = DbContext.Cars.FirstOrDefault(x => x.car_id == id);
            if (car == null) return NotFound();
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string brand, string model, int powerHp, decimal pricePerDay, string detail, string transmision)
        {
            if (User.Identity.Name != "Admin")
            {
                return RedirectToAction("Index");
            }
            var car = DbContext.Cars.FirstOrDefault(x => x.car_id == id);
            if (car == null) return NotFound();

            if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model))
            {
                ViewBag.Error = "Vyplň značku a model.";
                return View(car);
            }

            car.brand = brand;
            car.model = model;
            car.power_hp = powerHp;
            car.price_per_day = pricePerDay;
            car.detail = detail;
            car.transmision = transmision;

            DbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (User.Identity.Name != "Admin")
            {
                return RedirectToAction("Index");
            }
            var car = DbContext.Cars.FirstOrDefault(x => x.car_id == id);
            if (car == null) return NotFound();
            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.Name != "Admin")
            {
                return RedirectToAction("Index");
            }
            var car = DbContext.Cars.FirstOrDefault(x => x.car_id == id);
            if (car == null) return NotFound();

            DbContext.Cars.Remove(car);
            DbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
