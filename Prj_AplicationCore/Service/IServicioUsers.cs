using Prj_Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_AplicationCore
{
    public interface IServicioUsers
    {
        Task<RI_Users> Login(string usermail, string userPassword);

    }
}
