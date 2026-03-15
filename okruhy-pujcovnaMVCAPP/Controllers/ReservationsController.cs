using Microsoft.AspNetCore.Mvc;
using okruhy_pujcovnaMVCAPP.Data;
using okruhy_pujcovnaMVCAPP.Entities;
using System.Linq;

public class ReservationsController : Controller
{
    AppDbContext DbContext = new AppDbContext();

    public IActionResult SelectCar(int circuitId)
    {
        var cars = DbContext.CircuitCars
            .Where(x => x.circuit_id == circuitId && x.is_available)
            .Select(x => x.Car)
            .ToList();

        ViewBag.CircuitId = circuitId;

        return View(cars);
    }

    public IActionResult Create(int carId, int circuitId)
    {
        ViewBag.CarId = carId;
        ViewBag.CircuitId = circuitId;

        return View();
    }

    [HttpPost]
    public IActionResult Create(int carId, int circuitId, DateTime startDate, DateTime endDate)
    {
        int userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value);

        var r = new reservation
        {
            user_id = userId,
            car_id = carId,
            circuit_id = circuitId,
            start_date = startDate,
            end_date = endDate
        };

        DbContext.Reservations.Add(r);
        DbContext.SaveChanges();

        TempData["success"] = "Rezervace byla uspesne vytvorena!";

        return RedirectToAction("Index", "Home");
    }
}
