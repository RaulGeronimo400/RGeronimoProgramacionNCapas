using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        public static ML.Result Delete(int IdEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var query = context.EmpresaDelete(IdEmpresa);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un problema al eliminar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var empresas = context.EmpresaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (empresas != null)
                    {
                        foreach (var obj in empresas)
                        {
                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = obj.IdEmpresa;
                            empresa.Nombre = obj.Nombre;

                            result.Objects.Add(empresa);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Lista Vacia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
