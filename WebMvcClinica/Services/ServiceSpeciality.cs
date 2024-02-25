using WebMvcClinica.Models;

namespace WebMvcClinica.Services
{
    public class ServiceSpeciality : IServiceSpeciality
    {
        private readonly BDClinicaContext _context;
        //SOLID interfaces y principios

        //Inyeccion de dependencia
        public ServiceSpeciality(BDClinicaContext context)
        {
            _context = context;
        }

        public IEnumerable<Especialidade>? getAll()
        {
            try
            {
                var result = _context.Especialidades.Where(esp => esp.EspStatus.Equals("A"));
                if (result.Any())
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en getAll: {ex}");
                return null;

            }
        }

        public Especialidade getById(int id)
        {
            try
            {
                var result = _context.Especialidades.Where(data => data.EspStatus.Equals("A") && data.EspId.Equals(id)).FirstOrDefault();
                if (result == null)
                { return null; }
                else { return result; }
            }
            catch
            {
                return null;
            }

        }
        public Especialidade getByName(string name)
        {
            try
            {
                var result = _context.Especialidades.Where(data => data.EspStatus.Equals("A") && data.EspName.Equals(name)).FirstOrDefault();
                if (result == null)
                { return null; }
                else { return result; }
            }
            catch
            {
                return null;
            }
        }
        public bool save(Especialidade especialidade)
        {
            try
            {

                var specilityExist = getByName(especialidade.EspName);
                if (specilityExist != null)
                {
                    return false;
                }
                else
                {
                    especialidade.EspAdd = DateTime.Now;
                    especialidade.EspStatus = "A";
                    _context.Add(especialidade);
                    return _context.SaveChanges() > 0;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool update(Especialidade especialidade)
        {
            try
            {
                _context.Entry(especialidade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                especialidade.EspUpdate = DateTime.Now;
                return _context.SaveChanges() > 0;

            }
            catch
            {
                return false;
            }
        }
        public bool delete(int id)
        {
            try
            {

                var specilityExist = getById(id);
                if (specilityExist == null)
                {
                    return false;
                }
                else
                {
                    specilityExist.EspDelete = DateTime.Now;
                    specilityExist.EspStatus = "I";
                    _context.Entry(specilityExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    return _context.SaveChanges() > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
