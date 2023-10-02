using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // Action Verbs
        //Mostrar la Vista - Mostrar Datos
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();

            usuario.Usuarios = new List<object>();
            ML.Result result = BL.Usuario.GetAllEF();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }

            //return View(result);
            return View(usuario);
        }

        //Mostrar el Formulario
        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {

            //Select Rol
            ML.Result resultRol = BL.Rol.GetAllLQ();

            ML.Usuario usuario = new ML.Usuario();

            usuario.Rol = new ML.Rol();

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            ML.Result resultPais = BL.Pais.GetAllEF();
            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

            //Agregar
            if (IdUsuario == null)
            {
                usuario.Rol.Roles = resultRol.Objects;
                return View(usuario);
            }
            //Actualizar
            else
            {
                //Get By Id
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                usuario.Rol.Roles = resultRol.Objects;

                usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                usuario.UserName = ((ML.Usuario)result.Object).UserName;
                usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                usuario.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
                usuario.Email = ((ML.Usuario)result.Object).Email;
                usuario.Password = ((ML.Usuario)result.Object).Password;
                usuario.Sexo = ((ML.Usuario)result.Object).Sexo;
                usuario.Telefono = ((ML.Usuario)result.Object).Telefono;
                usuario.Celular = ((ML.Usuario)result.Object).Celular;
                usuario.FechaNacimiento = ((ML.Usuario)result.Object).FechaNacimiento;
                usuario.CURP = ((ML.Usuario)result.Object).CURP;
                usuario.Status = ((ML.Usuario)result.Object).Status;
                usuario.Imagen = ((ML.Usuario)result.Object).Imagen;
                usuario.Rol.IdRol = ((ML.Usuario)result.Object).Rol.IdRol;

                usuario.Direccion.Calle = ((ML.Usuario)result.Object).Direccion.Calle;
                usuario.Direccion.NumeroInterior = ((ML.Usuario)result.Object).Direccion.NumeroInterior;
                usuario.Direccion.NumeroExterior = ((ML.Usuario)result.Object).Direccion.NumeroExterior;

                usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.Pais.IdPais;
                usuario.Direccion.Colonia.Municipio.Estado.IdEstado = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.Estado.IdEstado;
                usuario.Direccion.Colonia.Municipio.IdMunicipio = ((ML.Usuario)result.Object).Direccion.Colonia.Municipio.IdMunicipio;
                usuario.Direccion.Colonia.IdColonia = ((ML.Usuario)result.Object).Direccion.Colonia.IdColonia;

                usuario = FillDropDownList(usuario);

                return View(usuario);
            }
        }

        //Agregar - Actualizar
        //Guardar la Informacion
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario, HttpPostedFileBase imgUsuario)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["imgUsuario"];
                if (imgUsuario != null)
                {
                    usuario.Imagen = this.ConvertToBytes(imgUsuario);
                }

                //Agregar
                if (usuario.IdUsuario == 0)
                {
                    ML.Result result = BL.Usuario.AddEF(usuario);

                    if (result.Correct)
                    {
                        //Por medio del VIEWBAG se envian los datos
                        //Desde el Controlador hacia la Vista
                        ML.Result resultDireccion = BL.Direccion.AddEF(usuario.Direccion, (int)result.Object);
                        ViewBag.Message = "Se ha ingresado correctamente el usuario";
                        if (resultDireccion.Correct)
                        {
                            ViewBag.Message = "Se ha ingresado correctamente el usuario con su direccion";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un problema al registrar al usuario. Error: " + result.ErrorMessage;
                    }
                }
                //Actualizar
                else
                {
                    //usuario.Status = true;
                    ML.Result result = BL.Usuario.UpdateEF(usuario);

                    if (result.Correct)
                    {
                        //Mediante el VIEWBAG se envian los datos
                        //Desde el controlador para la vista
                        ML.Result resultDireccion = BL.Direccion.UpdateEF(usuario.Direccion, (int)result.Object);
                        ViewBag.Message = "Se ha actualizado correctamente el Usuario";
                        if (resultDireccion.Correct)
                        {
                            ViewBag.Message = "Se ha actualizado correctamente el Usuario con su direccion";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un problema al actualizar al Usuario. Error: " + result.ErrorMessage;
                    }
                }
                return PartialView("Modal");
            }
            else
            {
                usuario = FillDropDownList(usuario);
                return View(usuario);
            }
        }

        //Eliminar
        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Result resultDireccion = BL.Direccion.DeleteEF(IdUsuario);
            if (resultDireccion.Correct)
            {
                ViewBag.Message = "Se ha eliminado correctamente la Direccion";
                ML.Result result = BL.Usuario.DeleteEF(IdUsuario);

                if (result.Correct)
                {
                    ViewBag.Message = "Se ha eliminado correctamente el Usuario";
                }
            }
            else
            {
                ViewBag.Message = "Ocurrio un problema al eliminar al usuario. Error: " + resultDireccion.ErrorMessage;
            }
            return PartialView("Modal");
        }

        //Actualizar Status
        [HttpGet]
        public ActionResult UpdateStatus(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
            if (result.Correct)
            {
                usuario = ((ML.Usuario)result.Object);
                usuario.Status = (usuario.Status) ? false : true;

                ML.Result resultUpdate = BL.Usuario.UpdateEF(usuario);
                ViewBag.Message = "Se actualizo el estatus del usuario";
            }
            else
            {
                ViewBag.Message = "Ocurrio un problema al actualizar el estatus del usuario";
            }
            return PartialView("Modal");
        }
        
        //Imagen
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        //Json
        //Estado
        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = BL.Estado.GetByIdPais(IdPais);
            return Json(result.Objects);
        }

        //Municipio
        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(result.Objects);
        }

        //Colonia
        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects);
        }

        private ML.Usuario FillDropDownList(ML.Usuario usuario)
        {
            ML.Result resultPais = new ML.Result();
            resultPais = BL.Pais.GetAllEF();

            ML.Result resultEstado = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
            ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
            ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);

            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
            usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
            usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
            usuario.Direccion.Colonia.Colonias = resultColonia.Objects;

            ML.Result resultRoles = BL.Rol.GetAllLQ();
            usuario.Rol.Roles = resultRoles.Objects;

            return usuario;
        }

        public JsonResult Update(int? IdUsuario, bool Status)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
            if (result.Correct)
            {
                usuario = ((ML.Usuario)result.Object);
                usuario.Status = (usuario.Status) ? false : true;

                ML.Result resultUpdate = BL.Usuario.UpdateEF(usuario);
                ViewBag.Message = "Se actualizo el estatus del usuario";
            }
            else
            {
                ViewBag.Message = "Ocurrio un problema al actualizar el estatus del usuario";
            }
            return Json(result.Objects);
        }
    }
}