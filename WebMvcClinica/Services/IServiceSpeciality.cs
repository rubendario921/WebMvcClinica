using WebMvcClinica.Models;

namespace WebMvcClinica.Services
{
    public interface IServiceSpeciality
    {
        IEnumerable<Especialidade> getAll();
        Especialidade getById(int id);
        Especialidade getByName(string name);
        bool save(Especialidade especialidade);
        bool update(Especialidade especialidade);
        bool delete(int id);
    }
}
