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
    public class Material
    {

        public List<CadMaterialDto> Consultar()
        {
            try
            {
                List<CadMaterialDto> list = new List<CadMaterialDto>();
                DbContext dbContext = new DbContext();
                DataTable dt = dbContext.GetDataTable("sp_ConsultaMaterial");

                foreach (DataRow dr in dt.Rows)
                {

                    CadMaterialDto material = new CadMaterialDto();
                    material.id = Convert.ToInt64(dr["id"]);
                    material.nome = dr["nome"].ToString();
                    material.codigo = dr["codigo"].ToString();
                    list.Add(material);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public int Incluir(CadMaterialDto model)
        {
            try
            {
                DbContext dbContext = new DbContext();
                List<SqlParameter> list = new List<SqlParameter>();
                SqlParameter parms = new SqlParameter();
                parms.ParameterName = "@CODIGO";
                parms.Value = model.codigo;
                list.Add(parms);
                parms = new SqlParameter();
                parms.ParameterName = "@NOME";
                parms.Value = model.nome;
                list.Add(parms);

                var retorno = dbContext.ExecuteQuery("sp_IncluirMaterial", list);


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
                List<SqlParameter> list = new List<SqlParameter>();
                SqlParameter parms = new SqlParameter();
                parms.ParameterName = "@ID";
                parms.Value = id;
                list.Add(parms);

                var retorno = dbContext.ExecuteQuery("sp_DeleteMaterial", list);

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           ;
        }

        public int Editar(CadMaterialDto model)
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
                parms.ParameterName = "@CODIGO";
                parms.Value = model.codigo;
                list.Add(parms);
                parms = new SqlParameter();
                parms.ParameterName = "@NOME";
                parms.Value = model.nome;
                list.Add(parms);

                var retorno = dbContext.ExecuteQuery("sp_EditarMaterial", list);

                return retorno;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }
    }
}