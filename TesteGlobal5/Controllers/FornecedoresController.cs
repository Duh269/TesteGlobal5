using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteGlobal5.Business;
using TesteGlobal5.Models;

namespace TesteGlobal5.Controllers
{
    public class FornecedoresController : Controller
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
            Fornecedor CadFornecedor = new Fornecedor();
           var Model = CadFornecedor.Consultar();

            return PartialView("Grid", Model);
        }

        public ActionResult Salvar(CadFornecedorDto model)
        {

            try
            {
                Fornecedor fornecedor = new Fornecedor();
                
                if (model.id != 0)
                {
                    fornecedor.Editar(model);
                }
                else
                {
                    fornecedor.Incluir(model);
                }
                

                return Json(new { result = "success"  });
            }
            catch (Exception ex)
            {

                return Json(new { result = "error" });
            }

          
        }


        public ActionResult Excluir(string id)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Excluir(Convert.ToInt64(id));

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