using ApplicationCore.Services;
using prj_Infraestructure.Repositorys;
using Prj_Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_AplicationCore
{
    public class ServiceUsers : IServicioUsers
    {
        private IRepositoryUsers repository;
        public ServiceUsers()
        {
            repository = new RepositoryUsers();
        }
        public async Task<RI_Users> Login(string usermail, string userPassword)
        {
            //string codifiedPass = Security.EncrypthAES(userPassword);
            return await repository.Login(usermail, userPassword);
        }
        
        public IEnumerable<RI_Users> GetUsers()
        {
            return repository.getUsers();
        }
        public RI_Users Save(RI_Users ri_Users)
        {
            return repository.Save(ri_Users);
        }
        public RI_Users GetUserById(int id)
        {
            return repository.GetUserById(id);
        }
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
