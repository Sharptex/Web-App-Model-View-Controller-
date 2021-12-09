using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_App__Model_View_Controller_.Models.Db;

namespace Web_App__Model_View_Controller_.Models.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
