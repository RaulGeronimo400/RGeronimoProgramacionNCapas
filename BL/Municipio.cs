using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetByIdEstado(int IdEstado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var municipios = context.MunicipioGetByIdEstado(IdEstado).ToList();

                    result.Objects = new List<object>();
                    if (municipios != null)
                    {
                        foreach (var objMunicipio in municipios)
                        {
                            ML.Municipio municipio = new ML.Municipio();

                            municipio.IdMunicipio = objMunicipio.IdMunicipio;
                            municipio.Nombre = objMunicipio.Nombre;

                            result.Objects.Add(municipio);
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
