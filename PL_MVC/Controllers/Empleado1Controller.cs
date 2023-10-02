using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class Empleado1Controller : Controller
    {
        // GET: Empleado1
        [HttpGet]
        public ActionResult GetAll()
        {
            return View();
        }

        public JsonResult Get()
        {
            ML.Result result = BL.Empleado.GetAll(new ML.Empleado());


            return Json(result, JsonRequestBehavior.AllowGet);
        }



        //Form
        public JsonResult GetEmpresas()
        {
            ML.Result result = BL.Empresa.GetAll();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(ML.Rol rol)
        {
            ML.Result result = new ML.Result();

           // ML.Result result = BL.Empleado.Add(empleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}