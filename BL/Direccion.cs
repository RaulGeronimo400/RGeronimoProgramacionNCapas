using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {
        public static ML.Result AddEF(ML.Direccion direccion, int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {

                    var query = context.DireccionAdd(
                        direccion.Calle,
                        direccion.NumeroInterior,
                        direccion.NumeroExterior,
                        direccion.Colonia.IdColonia,
                        IdUsuario);

                    if (query > 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo añadir el registro de direccion";
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

        public static ML.Result UpdateEF(ML.Direccion direccion, int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var query = context.DireccionUpdate(
                        direccion.Calle,
                        direccion.NumeroInterior,
                        direccion.NumeroExterior,
                        direccion.Colonia.IdColonia,
                        IdUsuario);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el registro de direccion";
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

        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var resultQuery = context.DireccionDelete(IdUsuario);
                    if(resultQuery > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
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

        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var objDireccion = context.DireccionGetByIdUsuario(IdUsuario).SingleOrDefault();
                    result.Objects = new List<object>();
                    if (objDireccion != null)
                    {
                        ML.Direccion direccion = new ML.Direccion();
                        direccion.Colonia = new ML.Colonia();

                        direccion.IdDireccion = objDireccion.IdDireccion;
                        direccion.Calle = objDireccion.Calle;
                        direccion.NumeroInterior = objDireccion.NumeroInterior;
                        direccion.NumeroExterior = objDireccion.NumeroExterior;
                        direccion.Colonia.IdColonia = objDireccion.IdColonia.Value;

                        result.Object = direccion;
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
