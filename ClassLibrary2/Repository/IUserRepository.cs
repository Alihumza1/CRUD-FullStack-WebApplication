using ClassLibrary2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUser();
        User AddUser(User user);
        User GetUser(User user);
    }
}
