using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TesteGlobal5.Business;
using TesteGlobal5.Models;

namespace TesteGlobal5.Controllers
{
    public class MateriaisController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult GridResult()
        {
            Material Material = new Material();
            var Model = Material.Consultar();

            return PartialView("Grid", Model);
        }


        public ActionResult Excluir(string id)
        {
            try
            {
                Material material = new Material();
                material.Excluir(id);

                return Json(new { result = "success" });
            }
            catch (Exception ex)
            {
                return Json(new { result = "error" });
            }
        }
        public ActionResult Salvar(CadMaterialDto model)
        {

            try
            {
                Material material = new Material();
                if (model.id != 0)
                {
                    material.Editar(model);

                }
                else
                {
                    material.Incluir(model);
                }
               
                return Json(new { result = "success" });
            }
            catch (Exception ex)
            {

                return Json(new { result = "error" });
            }


        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}