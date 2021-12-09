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
    public class LogsController : Controller
    {
        // ссылка на репозиторий
        private readonly ILoggerRepository _repo;

        public LogsController(ILoggerRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _repo.GetLogs();
            return View(logs);
        }
    }
}
