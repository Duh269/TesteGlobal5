using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteGlobal5.Models
{
    public class RelatorioDto
    {
        public string data_inicial { get;set; }
        public string data_final { get; set; }

        public CadFornecedorDto fornecedor_id { get; set; }
        public CadMaterialDto material_id { get; set; }    
     
        public string tipo_entrada { get; set; }

    }
}