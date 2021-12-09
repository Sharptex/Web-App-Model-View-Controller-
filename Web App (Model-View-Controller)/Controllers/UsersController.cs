using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web_App__Model_View_Controller_.Models;
using Web_App__Model_View_Controller_.Models.Db;
using Web_App__Model_View_Controller_.Models.Repositories;

namespace Web_App__Model_View_Controller_.Controllers
{
    public class UsersController : Controller
    {
        // ссылка на репозиторий
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _repo.GetUsers();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            // Добавим в базу
            await _repo.AddUser(user);
            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
