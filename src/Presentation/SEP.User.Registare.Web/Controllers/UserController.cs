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
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var model = await _userService.GetAll(cancellationToken);
            return View(model);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(string email, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByEmail(email, cancellationToken);
            return View(user);
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
        public async Task<ActionResult> Create(UserDTO model, IFormCollection collection, CancellationToken cancellationToken)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _userService.Create(model, cancellationToken);
            return RedirectToAction(nameof(Index));

        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(string email, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByEmail(email, cancellationToken);
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserDTO model, IFormCollection collection, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _userService.Update(model, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Delete/5
        public async Task<ActionResult> Delete(string email, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByEmail(email, cancellationToken);
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(UserDTO model, IFormCollection collection, CancellationToken cancellationToken)
        {
            await _userService.Delete(model.Email, cancellationToken);
            return RedirectToAction(nameof(Index));

        }
    }
}
