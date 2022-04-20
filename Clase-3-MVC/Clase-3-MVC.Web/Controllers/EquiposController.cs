using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Clase_3_MVC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clase_3_MVC.Web.Controllers
{
    public class EquiposController : Controller
    {

        private static List<EquipoViewModel> _equipos = new List<EquipoViewModel>()
        {
            new EquipoViewModel() {Id=1, Nombre="Boca", Pais="Argentina"},
            new EquipoViewModel() {Id=2, Nombre="Milan", Pais="Italia"},
            new EquipoViewModel(){Id=3, Nombre="Barcelona", Pais="España"}
        };

        // GET: EquiposController
        public ActionResult Lista()
        {
            return View(_equipos);
        }

        // GET: PartidosController/Nuevo
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: EquiposController/Nuevo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo(EquipoViewModel equipo)
        {
            try
            {
                _equipos.Add(equipo);
                return RedirectToAction(nameof(Lista));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquiposController/Eliminar/5
        public ActionResult Eliminar(int id)
        {
            if (Request.Form["Confirmar"] == "Cancelar")
            {
                return RedirectToAction(nameof(Lista));
            }
            _equipos.RemoveAll(o => o.Id == id);
            return RedirectToAction(nameof(Lista));
        }

        // GET: EquiposController/EliminarConfirmacion/5
        public ActionResult EliminarConfirmacion(int id)
        {
            EquipoViewModel equipo = _equipos.Find(o => o.Id == id);
            return View(equipo);
        }


    }
}
