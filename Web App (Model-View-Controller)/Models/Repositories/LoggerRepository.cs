using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_App__Model_View_Controller_.Models.Db;

namespace Web_App__Model_View_Controller_.Models.Repositories
{
    public class LoggerRepository : ILoggerRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public LoggerRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddLog(Request log)
        {
            log.Date = DateTime.Now;
            log.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _context.Entry(log);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(log);

            // Сохранение изменений
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetLogs()
        {
            // Получим всех активных пользователей
            return await _context.Requests.ToArrayAsync();
        }
    }
}
