using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using TesteGlobal5.Models;

namespace TesteGlobal5.Business
{
    public class Relatorio : DbContext
    {
        public List<CadEstoqueDto> Consultar(RelatorioDto relatorio)
        {
            List<CadEstoqueDto> list = new List<CadEstoqueDto>();
            DbContext dbContext = new DbContext();
            List<SqlParameter> parms = new List<SqlParameter>();
            SqlParameter parm = new SqlParameter();
            parm.ParameterName = "@FORNECEDOR_ID";
            parm.Value = relatorio.fornecedor_id.id;
            parms.Add(parm);
            SqlParameter parm2 = new SqlParameter();
            parm2.ParameterName = "@MATERIAL_ID";
            parm2.Value = relatorio.material_id.id;
            parms.Add(parm2);
            parm2 = new SqlParameter();
            parm2.ParameterName = "@TIPO_ENTRADA";
            parm2.Value = relatorio.tipo_entrada;
            parms.Add(parm2);
            parm2 = new SqlParameter();
            parm2.ParameterName = "@DATA_INICIAL";
            parm2.Value = relatorio.data_inicial;
            parms.Add(parm2);
            parm2 = new SqlParameter();
            parm2.ParameterName = "@DATA_FINAL";
            parm2.Value = relatorio.data_final;
            parms.Add(parm2);

            var dt = dbContext.GetDataTable("sp_Relatorio", parms);

            foreach (DataRow row in dt.Rows)
            {
                CadEstoqueDto cadEstoqueDto = new CadEstoqueDto();
                cadEstoqueDto.id = Convert.ToInt64(row["id"]);
                cadEstoqueDto.material_id = new CadMaterialDto() { id = Convert.ToInt64(row["material_id"]), nome = row["nome"].ToString() };
                cadEstoqueDto.fornecedor_id = new CadFornecedorDto() { id = Convert.ToInt64(row["fornecedor_id"]), razaosocial = row["razaosocial"].ToString() };
                cadEstoqueDto.quantidade = Convert.ToInt32(row["quantidade"]);
                cadEstoqueDto.valor = row["valor"].ToString();

                if (row["data_entrada"] != DBNull.Value)
                {
                    cadEstoqueDto.data_entrada = Convert.ToDateTime(row["data_entrada"]);
                }
               
                cadEstoqueDto.tipo_entrada = Convert.ToString(row["tipo_entrada"]);
           
                list.Add(cadEstoqueDto);
            }


            return list;
        }

        
    }
}