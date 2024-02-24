using Microsoft.AspNetCore.Mvc;
using WebMvcClinica.Models;
using WebMvcClinica.Services;

namespace WebMvcClinica.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly IServiceSpeciality _serviceSpeciality;

        public EspecialidadController(IServiceSpeciality serviceSpeciality)
        {
            _serviceSpeciality = serviceSpeciality;
        }
        //Get
        public IActionResult Index()
        {
            var res = _serviceSpeciality.getAll();
            return View(res);
        }

        //Get
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var especialidad = _serviceSpeciality.getById(Convert.ToInt32(id));

                if (especialidad == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(especialidad);
                }
            }
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Especialidade especialidade)
        {
            var resultSave = _serviceSpeciality.save(especialidade);
            if (resultSave)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        //GET
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var especialidad = _serviceSpeciality.getById(Convert.ToInt32(id));
                if (especialidad == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(especialidad);
                }
            }
        }
        [HttpPost]
        public IActionResult Edit(Especialidade especialidade)
        {
            var resultSave = _serviceSpeciality.update(especialidade);
            if (resultSave)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        //GET
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var especialidad = _serviceSpeciality.getById(Convert.ToInt32(id));
                if (especialidad == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(especialidad);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Especialidade especialidade)
        {
            var resultDelete = _serviceSpeciality.delete(especialidade.EspId);
            if (resultDelete)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

    }
}
