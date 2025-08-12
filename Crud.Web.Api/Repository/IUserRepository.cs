using Crud.Web.Api.Models;

namespace Crud.Web.Api.Repository {
    public interface IUserRepository {

        Users? GetUserById(int userId);
        Users AddUser(Users user);
    }
}
