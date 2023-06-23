using ClassLibrary2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Repository
{
    public class UserRepository :IUserRepository
    {
        public readonly DbContextcs db;
        public UserRepository(DbContextcs dataBase)
        {
            db = dataBase; 
        }
        public List<User> GetAllUser()
        {
            var user = db.User.ToList();
            return user;
        }
       public User AddUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return user;
        }
       public User GetUser(User user)
        {
            return db.User.FirstOrDefault(z => z.UserName == user.UserName && z.PassWord == user.PassWord);
        }
    }
}
