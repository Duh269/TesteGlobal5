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
    public class Estoque : DbContext
    {
        public List<CadEstoqueDto> Consultar()
        {
            List<CadEstoqueDto> list = new List<CadEstoqueDto>();
            DbContext dbContext = new DbContext();
            var dt = dbContext.GetDataTable("sp_ConsultaEstoque");

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

        public int Incluir(CadEstoqueDto model)
        {

            try
            {
                DbContext dbContext = new DbContext();
              
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter parms = new SqlParameter();
                parms.ParameterName = "@DATA_ENTRADA";
                parms.Value = model.data_entrada;
                sqlParameters.Add(parms);
                parms = new SqlParameter();
                parms.ParameterName = "@MATERIAL_ID";
                parms.Value = model.material_id.id;
                sqlParameters.Add(parms);
                parms = new SqlParameter();
                parms.ParameterName = "@FORNECEDOR_ID";
                parms.Value = model.fornecedor_id.id;
                sqlParameters.Add(parms);
                parms = new SqlParameter();
                parms.ParameterName = "@VALOR";
                parms.Value = model.valor;
                parms.DbType = DbType.Decimal;
                sqlParameters.Add(parms);
                parms = new SqlParameter();
                parms.ParameterName = "@QUANTIDADE";
                parms.Value = model.quantidade;
                sqlParameters.Add(parms);
                parms = new SqlParameter();
                parms.ParameterName = "@TIPO_ENTRADA";
                parms.Value = model.tipo_entrada;
                sqlParameters.Add(parms);

               
                 var retorno = dbContext.ExecuteQuery("Sp_IncluirEstoque", sqlParameters);
                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Excluir(string id)
        {


            try
            {
                DbContext dbContext = new DbContext();

                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                SqlParameter parms = new SqlParameter();
                parms.ParameterName = "@ID";
                parms.Value = id;
                sqlParameters.Add(parms);

                var retorno = dbContext.ExecuteQuery("sp_DeleteEstoque", sqlParameters);
                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Editar(CadEstoqueDto model)
        {
            DbContext dbContext = new DbContext();

            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            SqlParameter parms = new SqlParameter();
            parms.ParameterName = "@ID";
            parms.Value = model.id;
            sqlParameters.Add(parms);

             parms = new SqlParameter();
            parms.ParameterName = "@DATA_ENTRADA";
            parms.Value = model.data_entrada;
            sqlParameters.Add(parms);

            parms = new SqlParameter();
            parms.ParameterName = "@MATERIAL_ID";
            parms.Value = model.material_id.id;
            sqlParameters.Add(parms);
            parms = new SqlParameter();
            parms.ParameterName = "@FORNECEDOR_ID";
            parms.Value = model.fornecedor_id.id;
            sqlParameters.Add(parms);
            parms = new SqlParameter();
            parms.ParameterName = "@VALOR";
            parms.Value = model.valor;
            sqlParameters.Add(parms);
            parms = new SqlParameter();
            parms.ParameterName = "@QUANTIDADE";
            parms.Value = model.quantidade;
            sqlParameters.Add(parms);
            parms = new SqlParameter();
            parms.ParameterName = "@TIPO_ENTRADA";
            parms.Value = model.tipo_entrada;
            sqlParameters.Add(parms);

            var retorno = dbContext.ExecuteQuery("Sp_EditarEstoque", sqlParameters);
            return retorno;
        }
    }
}