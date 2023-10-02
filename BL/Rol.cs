using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllLQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var query = (from rolLQ in context.Rols
                                 select rolLQ);
                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var objRol in query)
                        {
                            ML.Rol rol = new ML.Rol();
                            rol.IdRol = objRol.IdRol;
                            rol.Nombre = objRol.Nombre;

                            result.Objects.Add(rol);
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
