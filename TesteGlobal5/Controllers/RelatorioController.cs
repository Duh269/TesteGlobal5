using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteGlobal5.Business;
using TesteGlobal5.Models;

namespace TesteGlobal5.Controllers
{
    public class RelatorioController : Controller
    {
        public ActionResult Index()
        {
            Fornecedor fornecedor = new Fornecedor();
            var listFornecedor = fornecedor.Consultar();
            Material material = new Material();
            var listMaterial = material.Consultar();
            listMaterial.Add(new Models.CadMaterialDto { id = 0, nome = "TODOS" });
            listFornecedor.Add(new Models.CadFornecedorDto { id = 0, razaosocial = "TODOS" });

            ViewBag.fornecedor = new SelectList(listFornecedor, "id", "razaosocial");
            ViewBag.material = new SelectList(listMaterial, "id", "nome");


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Gerar(RelatorioDto relatorio)
        {
            try
            {
                if (relatorio.data_inicial != null && relatorio.data_final != null)
                {
                    Relatorio OPrelatorio = new Relatorio();
                    var list = OPrelatorio.Consultar(relatorio);

                    return PartialView("Grid", list);
                }
                else
                {
                    return Json("Preencha as datas Inicial e Final!");
                }

                
            }
            catch (Exception)
            {

                throw;
            }
        }
       

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}