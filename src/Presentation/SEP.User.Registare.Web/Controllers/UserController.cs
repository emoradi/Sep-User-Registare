using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SEP.User.Registare.Service.DTOs;
using SEP.User.Registare.Service.Services.Users.Contracts;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SEP.User.Registare.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: UserController
        public ActionResult Index(CancellationToken cancellationToken)
        {
            var model = _userService.GetAll(cancellationToken).Result;
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            var model = new UserDTO();
            return View(model);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDTO model, IFormCollection collection, CancellationToken cancellationToken)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _userService.Create(model, cancellationToken);
            return RedirectToAction(nameof(Index));

        }

        // GET: UserController/Edit/5
        public ActionResult Edit(string email, CancellationToken cancellationToken)
        {
            var user = _userService.GetByEmail(email, cancellationToken).Result;
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserDTO model, IFormCollection collection, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _userService.Update(model, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
