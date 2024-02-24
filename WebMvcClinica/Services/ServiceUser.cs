using WebMvcClinica.Models;

namespace WebMvcClinica.Services
{
    public class ServiceUser : IServiceUser
    {
        private readonly BDClinicaContext _context;

        public ServiceUser(BDClinicaContext context)
        {
            _context = context;
        }
        public IEnumerable<User>? GetAllUser()
        {
            try
            {
                var result = _context.Users.Where(user => user.UsuStatus.Equals("A"));
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

                Console.WriteLine($"Error en GetAllUser: {ex}");
                return null;
            }
        }

        public User? GetUserById(int id)
        {
            try
            {
                var result = _context.Users.Where(user => user.UsuId.Equals(id)).FirstOrDefault();
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
                Console.WriteLine($"Error en GetUserById: {ex}");
                return null;
            }
        }

        public bool SaveUser(User user)
        {
            try
            {
                user.UsuAdd = DateTime.Now;
                user.UsuStatus = "A";
                _context.Add(user);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en saveUser: {ex}");
                return false;
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                user.UsuUpdate = DateTime.Now;
                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en UpdateUser: {ex}");
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var userExist = GetUserById(id);
                if (userExist != null)
                {
                    userExist.UsuDelete = DateTime.Now;
                    userExist.UsuStatus = "I";
                    _context.Entry(userExist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return _context.SaveChanges() > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en DeleteUser: {ex}");
                return false;
            }
        }
    }
}
