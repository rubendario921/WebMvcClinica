using WebMvcClinica.Models;

namespace WebMvcClinica.Services
{
    public class ServiceRol : IServiceRol
    {
        private readonly BDClinicaContext _context;

        public ServiceRol(BDClinicaContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            try
            {
                var result = _context.Roles.Where(rol => rol.RolStatus.Equals("A")).ToList();
                if (result.Count > 0)
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
                Console.WriteLine($"Error en getAllRoles: {ex.ToString()}");
                return null;
            }
        }

        public Role GetRolbyID(int id)
        {
            try
            {
                var result = _context.Roles.Where(rol => rol.RolId.Equals(id)).FirstOrDefault();
                if (result != null)
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
                Console.WriteLine($"Error en getRolbyID: {ex.ToString()}");
                return null;
            }
        }
        public Role GetRolbyDetails(string details)
        {
            try
            {
                var result = _context.Roles.Where(rol => rol.RolId.Equals(details)).FirstOrDefault();
                if (result != null)
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
                Console.WriteLine($"Error en getRolbyDetails: {ex.Message}");
                return null;
            }
        }

        public bool SaveRol(Role rol)
        {
            try
            {
                var rolExist = GetRolbyDetails(rol.RolDetails);
                if (rolExist != null)
                {
                    return false;
                }
                else
                {
                    _context.Add(rol);
                    return _context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en saveRol:{ex.Message}");
                return false;
            }
        }

        public bool Update(Role rol)
        {
            try
            {
                _context.Entry(rol).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en updateRol:{ex.Message}");
                return false;
            }
        }
        public bool Delete(int id)
        {
            try {
                var rolExist = GetRolbyID(id);
                if (rolExist != null)
                {
                    rolExist.RolStatus = "I";
                    _context.Entry(rolExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return _context.SaveChanges() > 0;
                }
                else {
                    return false;
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error en deleteRol: {ex.Message}");
                return false;
            }
        }
    }
}
