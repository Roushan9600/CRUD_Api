using Crud.Web.Api.Data;
using Crud.Web.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Web.Api.Repository {
    public class UserRepository : IUserRepository {

        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }


        public Users? GetUserById(int id) {
            //_appDbContext.Users.FromSqlInterpolated($"SELECT * FROM Users WHERE Id = {id}");
            return _appDbContext.Users.FirstOrDefault(u => u.Id == id);
            
        }

        public Users AddUser(Users user) {

         var result = GetUserById(user.Id);
            if (result == null) {

                _appDbContext.Users.Add(user);
                _appDbContext.SaveChanges();
                return user;
            }
            else
            {
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Email = user.Email;
               // _appDbContext.Users.Update(result);  // No need for _appDbContext.Update(result)
                _appDbContext.SaveChanges();
            }
            return user;
        }

    }
}



