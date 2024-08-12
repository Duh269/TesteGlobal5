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
    public class Fornecedor
    {

        public List<CadFornecedorDto> Consultar()
        {
            try
            {
                List<CadFornecedorDto> list = new List<CadFornecedorDto>();
                DbContext dbContext = new DbContext();
                DataTable dt = dbContext.GetDataTable("sp_ConsultaFornecedor");

                foreach (DataRow dr in dt.Rows)
                {

                    CadFornecedorDto forn = new CadFornecedorDto();
                    forn.id = Convert.ToInt64(dr["id"]);
                    forn.cnpj = dr["cnpj"].ToString();
                    forn.razaosocial = dr["razaosocial"].ToString();
                    list.Add(forn);
                }

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Incluir(CadFornecedorDto model)
      {
            try
            {
                DbContext dbContext = new DbContext();
                List<SqlParameter> list = new List<SqlParameter>();
                SqlParameter parms = new SqlParameter();
                parms.ParameterName = "@CNPJ";
                parms.Value = model.cnpj;
                list.Add(parms);
                parms = new SqlParameter();
                parms.ParameterName = "@RAZAOSOCIAL";
                parms.Value = model.razaosocial;
                list.Add(parms);

                var retorno = dbContext.ExecuteQuery("sp_IncluirFornecedor", list);

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
      }

        public int Excluir(long id)
        {
            try
            {
                DbContext dbContext = new DbContext();
                List<SqlParameter> list = new List<SqlParameter>();
                SqlParameter parms = new SqlParameter();

                parms.Value = id;
                parms.ParameterName = "@ID";
                list.Add(parms);

                var retorno = dbContext.ExecuteQuery("sp_DeleteFornecedor", list);
                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Editar(CadFornecedorDto model)
        {
            try
            {
                DbContext dbContext = new DbContext();
                List<SqlParameter> list = new List<SqlParameter>();

                SqlParameter parms = new SqlParameter();
                parms.ParameterName = "@ID";
                parms.Value = model.id;
                list.Add(parms);

                parms = new SqlParameter();
                parms.ParameterName = "@CNPJ";
                parms.Value = model.cnpj;
                list.Add(parms);

                parms = new SqlParameter();
                parms.ParameterName = "@RAZAOSOCIAL";
                parms.Value = model.razaosocial;

                list.Add(parms);

                var retorno = dbContext.ExecuteQuery("sp_EditarFornecedor", list);

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }
    }
}