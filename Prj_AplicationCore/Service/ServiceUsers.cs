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
    }
}
