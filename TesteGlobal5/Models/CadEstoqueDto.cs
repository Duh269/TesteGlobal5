using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteGlobal5.Models
{
    public class CadEstoqueDto
    {
        public long id { get; set; }
        
        public DateTime? data_entrada { get;set; }
        public CadFornecedorDto fornecedor_id { get; set; }
        public CadMaterialDto material_id { get; set; }    
        public string valor { get; set; }

        public int quantidade { get; set; }
        public string tipo_entrada { get; set; }

    }
}