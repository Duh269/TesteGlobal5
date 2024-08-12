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
    public class EstoqueController : Controller
    {
        public ActionResult Index()
        {

            Fornecedor fornecedor = new Fornecedor();
            var listFornecedor = fornecedor.Consultar();
            Material material =  new Material();
           var listMaterial =  material.Consultar();

            ViewBag.fornecedor = new SelectList(listFornecedor,"id","razaosocial");
            ViewBag.material = new SelectList(listMaterial,"id","nome");


            return View();
        }

        public ActionResult GridResult() {
        
            Estoque estoque = new Estoque();
            var list = estoque.Consultar();

            return PartialView("Grid", list);
        }

        public ActionResult Salvar(CadEstoqueDto model)
        {

            try
            {
                Estoque estoque = new Estoque();
                if (model.id != 0)
                {
                    estoque.Editar(model);
                }
                else
                {
                    estoque.Incluir(model);
                }
                
               


                return Json(new { result = "success" });
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
                Estoque estoque = new Estoque();
                estoque.Excluir(id);

                return Json(new { result = "success" });
            }
            catch (Exception ex)
            {

                return Json(new { result = "error" });
            }
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}