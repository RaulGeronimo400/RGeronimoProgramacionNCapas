using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var colonias = context.ColoniaGetByIdMunicipio(IdMunicipio).ToList();

                    result.Objects = new List<object>();
                    if (colonias != null)
                    {
                        foreach (var objColonia in colonias)
                        {
                            ML.Colonia colonia = new ML.Colonia();

                            colonia.IdColonia = objColonia.IdColonia;
                            colonia.Nombre = objColonia.Nombre;

                            result.Objects.Add(colonia);
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
