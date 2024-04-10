using Prj_AplicationCore;
using Prj_AplicationCore.Service;
using Prj_Infraestructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Prj_eOBot.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult Create() 
        { 
            return View();
        }
        public async Task<ActionResult> List()
        {
            IEnumerable<Rl_Robot> olista = null;
            try
            {
                IServiceClient _servicioClient = new ServiceClient();

                RI_Users user = (RI_Users)Session["User"];

                if (user.Role == 1)
                {
                    olista = await _servicioClient.GetRobotClientAsync();
                   
                }
                else if (user.Role == 2)
                {
                    var robot = await _servicioClient.GetRobotClientByEmaildAsync(user.Email);
                    olista = new List<Rl_Robot> { robot };
                }
                return View(olista);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ActionResult> Edit(Guid? id)
        {
            try
            {
                IServiceClient _servicioClient = new ServiceClient();

                Rl_Robot ri_robot =await _servicioClient.GetRobotClientByIdAsync(id);
               
                // Envía una lista que contenga solo el usuario a la vista
                return View(new List<Rl_Robot> { ri_robot });
            }
            catch (Exception ex)
            {
                string mensaje = "Error al listar" + ex;
                throw new Exception(mensaje);
            }
        }
        public async Task<JsonResult> Save(Rl_Robot ri_robot)
        {
            IServiceClient _servicioClient = new ServiceClient();

            try
            {          

                await _servicioClient.SaveAsync(ri_robot);
                return Json(new { success = true, message = "Registro guardado con éxito" });
            }
            catch (Exception ex)
            {
                string errorMessage = "Error al guardar el registro: " + ex.Message;
                return Json(new { success = false, message = errorMessage });
            }

        }
    }
}