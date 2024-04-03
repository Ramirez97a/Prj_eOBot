using Prj_Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_AplicationCore
{
    public interface IServicioUsers
    {
        Task<RI_Users> Login(string usermail, string userPassword);        
        IEnumerable<RI_Users> GetUsers();
        RI_Users Save(RI_Users ri_Users);
        RI_Users GetUserById(int id);
        void Delete(int id);
    }
}
