using CrudEmpleadoEF.Data;
using CrudEmpleadoEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudEmpleadoEF.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public EmpleadoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> ListaEmpleados()
        {
            List<Empleado> lista = await _appDbContext.Empleados.ToListAsync();
            return View(lista);
        }
        [HttpGet]
        public IActionResult NuevoEmpl()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NuevoEmpl(Empleado empleado)
        {
            await _appDbContext.Empleados.AddAsync(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(ListaEmpleados));
        }
        [HttpGet]
        public async Task<IActionResult> EditarEmpl(int id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(e=> e.IdEmpleado == id);
            return View(empleado);
        }
        [HttpPost]
        public async Task<IActionResult> EditarEmpl(Empleado empleado)
        {
            _appDbContext.Empleados.Update(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(ListaEmpleados));
        }
        [HttpGet]
        public async Task<IActionResult> EliminarEmpl(int id)
        {
            Empleado empleado = await _appDbContext.Empleados.FirstAsync(e => e.IdEmpleado == id);
            _appDbContext.Empleados.Remove(empleado);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(ListaEmpleados));
        }

    }
}
