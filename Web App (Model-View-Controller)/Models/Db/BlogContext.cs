﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_App__Model_View_Controller_.Models.Db
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public class BlogContext : DbContext
    {
        /// Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }

        /// Ссылка на таблицу UserPosts
        public DbSet<UserPost> UserPosts { get; set; }

        /// Ссылка на таблицу Requests
        public DbSet<Request> Requests { get; set; }

        // Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
