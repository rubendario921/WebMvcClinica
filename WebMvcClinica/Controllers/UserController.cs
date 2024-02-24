using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using WebMvcClinica.Models;
using WebMvcClinica.Services;

namespace WebMvcClinica.Controllers
{
    public class UserController : Controller
    {
        private readonly IServiceUser _serviceUser;

        public UserController(IServiceUser serviceUser)
        {
            _serviceUser = serviceUser;
        }

        //GET
        public IActionResult Index()
        {
            var result = _serviceUser.GetAllUser();
            return View(result);
        }

        //GET
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var result = _serviceUser.GetUserById(Convert.ToInt32(id));
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(result);
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
        public IActionResult Create(User user, IFormFile file)
        {
            //Ingresar imagen
            if (file != null)
            {
                if (file.Length > 0)
                {
                    long length = file.Length;
                    if (length < 0)
                    {
                        return BadRequest();
                    }
                    using var fileStream = file.OpenReadStream();
                    //Convertir en binary
                    byte[] bytes = new byte[length];
                    fileStream.Read(bytes, 0, (int)file.Length);
                    user.UsuImage = bytes;
                }
            }

            var resultSave = _serviceUser.SaveUser(user);
            if (resultSave)
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
