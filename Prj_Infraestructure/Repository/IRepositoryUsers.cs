
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
        IEnumerable<RI_Users> getUsers();
        RI_Users Save(RI_Users ri_Users);
        RI_Users GetUserById(int? id);
        void Delete(int id);

    }
}
