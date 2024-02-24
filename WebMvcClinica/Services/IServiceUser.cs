using WebMvcClinica.Models;

namespace WebMvcClinica.Services
{
    public interface IServiceUser
    {
        IEnumerable<User>? GetAllUser();
        User? GetUserById(int id);
        bool SaveUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
