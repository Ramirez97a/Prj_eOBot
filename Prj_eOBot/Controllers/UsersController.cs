using Prj_AplicationCore;
using Prj_Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Prj_eOBot.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public ActionResult Create()
        {
            return View();
        }
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                IServicioUsers _servicioUsers = new ServiceUsers();
                RI_Users user =  await _servicioUsers.GetUserByIdAsync(id);

                // Envía una lista que contenga solo el usuario a la vista
                return View(new List<RI_Users> { user });
            }
            catch (Exception ex)
            {
                string mensaje = "Error al listar" + ex;
                throw new Exception(mensaje);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                IServicioUsers _servicioUsers = new ServiceUsers();
                RI_Users user = await _servicioUsers.GetUserByIdAsync(id);

                // Envía una lista que contenga solo el usuario a la vista
                return View(new List<RI_Users> { user });
            }
            catch (Exception ex)
            {
                string mensaje = "Error al listar" + ex;
                throw new Exception(mensaje);
            }
        }

        public async Task<ActionResult> list()
        {
            IEnumerable<RI_Users> olista = null;
            try
            {
                IServicioUsers _servicioUsers = new ServiceUsers();
                olista = await _servicioUsers.GetUsersAsync();
                return View(olista);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<JsonResult> Save(RI_Users ri_users)
        {
            IServicioUsers _servicioUsers = new ServiceUsers();      

            try
            {
                 await _servicioUsers.SaveAsync(ri_users);
                return Json(new { success = true, message = "Registro guardado con éxito" });
            }
            catch (Exception ex)
            {
                string errorMessage = "Error al guardar el registro: " + ex.Message;
                return Json(new { success = false, message = errorMessage });
            }

        }
        public async Task<JsonResult> DeleteUser(int id)
        {
            IServicioUsers _servicioUsers = new ServiceUsers();

            try
            {
               await _servicioUsers.DeleteAsync(id);
                return Json(new { success = true, message = "Eliminado correctamente" });
            }
            catch (Exception ex)
            {
                string errorMessage = "Error al eliminar: " + ex.Message;
                return Json(new { success = false, message = errorMessage });
            }

        }
    }
}