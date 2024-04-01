
using Prj_Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prj_Infraestructure.Repositorys
{
    public interface  IRepositoryUsers
    {
        Task<RI_Users> Login(string userName, string userPassword);
    }
}
