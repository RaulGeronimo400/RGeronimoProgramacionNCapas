using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var query = context.EmpleadoAdd(
                        empleado.NumeroEmpleado,
                        empleado.RFC,
                        empleado.Nombre,
                        empleado.ApellidoPaterno,
                        empleado.ApellidoMaterno,
                        empleado.Email,
                        empleado.Telefono,
                        empleado.FechaNacimiento,
                        empleado.NSS,
                        empleado.FechaIngreso,
                        empleado.Foto,
                        empleado.Empresa.IdEmpresa
                        );

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo insertar";
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
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var query = context.EmpleadoUpdate(
                        empleado.NumeroEmpleado,
                        empleado.RFC,
                        empleado.Nombre,
                        empleado.ApellidoPaterno,
                        empleado.ApellidoMaterno,
                        empleado.Email,
                        empleado.Telefono,
                        empleado.FechaNacimiento,
                        empleado.NSS,
                        empleado.FechaIngreso,
                        empleado.Foto,
                        empleado.Empresa.IdEmpresa,
                        empleado.IdEmpleado
                        );

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un problema al actualizar";
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
        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var quey = context.EmpleadoDelete(IdEmpleado);
                    if (quey > 0)
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
        public static ML.Result GetAll(ML.Empleado empleadoBusqueda)
        {
            ML.Result result = new ML.Result();

            empleadoBusqueda.Nombre = (empleadoBusqueda.Nombre != null) ? empleadoBusqueda.Nombre : "";
            empleadoBusqueda.ApellidoPaterno = (empleadoBusqueda.ApellidoPaterno != null) ? empleadoBusqueda.ApellidoPaterno : "";
            empleadoBusqueda.ApellidoMaterno = (empleadoBusqueda.ApellidoMaterno != null) ? empleadoBusqueda.ApellidoMaterno : "";

            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var empleados = context.EmpleadoGetAll(
                        empleadoBusqueda.Nombre,
                        empleadoBusqueda.ApellidoPaterno,
                        empleadoBusqueda.ApellidoMaterno
                        ).ToList();

                    result.Objects = new List<object>();

                    if (empleados != null)
                    {
                        foreach (var obj in empleados)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.Empresa = new ML.Empresa();

                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.NumeroEmpleado = obj.NumeroEmpleado;
                            empleado.RFC = obj.RFC;
                            empleado.Nombre = obj.Empleado;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Email = obj.Email;
                            empleado.Telefono = obj.Telefono;
                            empleado.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd / MMMM / yyyy");
                            empleado.NSS = obj.NSS;
                            empleado.FechaIngreso = obj.FechaIngreso.Value.ToString("dd / MMMM / yyyy");
                            empleado.Foto = obj.Foto;

                            empleado.Empresa.IdEmpresa = (obj.IdEmpresa != null) ? int.Parse(obj.IdEmpresa.Value.ToString()) : 0;
                            empleado.Empresa.Nombre = obj.Empresa;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Lista vacia";
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
        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    result.Objects = new List<object>();
                    var obj = context.EmpleadoGetById(IdEmpleado).SingleOrDefault();
                    if (obj != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();
                        empleado.Empresa = new ML.Empresa();

                        empleado.IdEmpleado = obj.IdEmpleado;
                        empleado.NumeroEmpleado = obj.NumeroEmpleado;
                        empleado.RFC = obj.RFC;
                        empleado.Nombre = obj.Empleado;
                        empleado.ApellidoPaterno = obj.ApellidoPaterno;
                        empleado.ApellidoMaterno = obj.ApellidoMaterno;
                        empleado.Email = obj.Email;
                        empleado.Telefono = obj.Telefono;
                        empleado.FechaNacimiento = obj.FechaNacimiento.Value.ToString("yyyy-MM-dd");
                        empleado.NSS = obj.NSS;
                        empleado.FechaIngreso = obj.FechaIngreso.Value.ToString("yyyy-MM-dd");
                        empleado.Foto = obj.Foto;

                        empleado.Empresa.IdEmpresa = (obj.IdEmpresa != null) ? int.Parse(obj.IdEmpresa.Value.ToString()) : 0;
                        empleado.Empresa.Nombre = obj.Empresa;

                        result.Object = empleado;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el empleado";
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
        public static ML.Result GetAllView(ML.Empleado empleadoBusqueda)
        {
            ML.Result result = new ML.Result();

            empleadoBusqueda.Nombre = (empleadoBusqueda.Nombre != null) ? empleadoBusqueda.Nombre : "";
            empleadoBusqueda.ApellidoPaterno = (empleadoBusqueda.ApellidoPaterno != null) ? empleadoBusqueda.ApellidoPaterno : "";
            empleadoBusqueda.ApellidoMaterno = (empleadoBusqueda.ApellidoMaterno != null) ? empleadoBusqueda.ApellidoMaterno : "";
            empleadoBusqueda.Empresa.IdEmpresa = (empleadoBusqueda.Empresa.IdEmpresa != 0) ? empleadoBusqueda.Empresa.IdEmpresa : int.Parse("0");

            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var empleados = context.EmpleadoGetAllView(
                        empleadoBusqueda.Nombre,
                        empleadoBusqueda.ApellidoPaterno,
                        empleadoBusqueda.ApellidoMaterno,
                        empleadoBusqueda.Empresa.IdEmpresa
                        ).ToList();

                    result.Objects = new List<object>();

                    if (empleados != null)
                    {
                        foreach (var obj in empleados)
                        {
                            ML.Empleado empleado = new ML.Empleado();
                            empleado.Empresa = new ML.Empresa();

                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.NumeroEmpleado = obj.NumeroEmpleado;
                            empleado.RFC = obj.RFC;
                            empleado.Nombre = obj.Empleado;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Email = obj.Email;
                            empleado.Telefono = obj.Telefono;
                            empleado.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd / MMMM / yyyy");
                            empleado.NSS = obj.NSS;
                            empleado.FechaIngreso = obj.FechaIngreso.Value.ToString("dd / MMMM / yyyy");
                            empleado.Foto = obj.Foto;

                            empleado.Empresa.IdEmpresa = (obj.IdEmpresa != null) ? int.Parse(obj.IdEmpresa.Value.ToString()) : 0;
                            empleado.Empresa.Nombre = obj.Empresa;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Lista vacia";
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
