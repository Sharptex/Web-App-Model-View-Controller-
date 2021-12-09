using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_App__Model_View_Controller_.Models.Db;
using Web_App__Model_View_Controller_.Models.Repositories;

namespace Web_App__Model_View_Controller_.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        // ссылка на репозиторий
        private readonly ILoggerRepository _repo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, ILoggerRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            // Добавим в базу
            await _repo.AddLog(new Request { Url = $"http://{context.Request.Host.Value + context.Request.Path}"} );

            //// Для логирования данных о запросе используем свойста объекта HttpContext
            //Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
