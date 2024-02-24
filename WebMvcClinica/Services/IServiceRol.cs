using WebMvcClinica.Models;

namespace WebMvcClinica.Services
{
    public interface IServiceRol
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRolbyID(int id);
        Role GetRolbyDetails(string details);
        bool SaveRol(Role rol);
        bool Update(Role rol);
        bool Delete(int id);

    }
}
