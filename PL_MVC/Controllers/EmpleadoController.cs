using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.OleDb;
using System.Net.Http;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        string urlAPI = System.Configuration.ConfigurationManager.AppSettings["API_URI"];

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            empleado.Empleados = new List<Object>();

            empleado = FillEmpresa(empleado);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);

                var responseTask = client.PostAsJsonAsync("empleados", empleado);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Empleado empleadoItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empleado>(resultItem.ToString());
                        empleado.Empleados.Add(empleadoItem);
                    }
                }
            }
            return View(empleado);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Empleado empleado)
        {
            empleado = FillEmpresa(empleado);
            empleado.Empleados = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);

                var responseTask = client.PostAsJsonAsync("empleados", empleado);
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Empleado empleadoItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empleado>(resultItem.ToString());
                        empleado.Empleados.Add(empleadoItem);
                    }
                }
            }
            return View(empleado);
        }

        [HttpGet]
        public ActionResult Form(int? IdEmpleado)
        {
            ML.Result resultEmpresa = BL.Empresa.GetAll();
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();

            //AGREGAR
            if (IdEmpleado == null)
            {
                empleado.Empresa.Empresas = resultEmpresa.Objects;
                return View(empleado);
            }
            else
            {
                //GET BY ID
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    var responseTask = client.GetAsync("empleado/" + IdEmpleado);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Empleado resultItemList = new ML.Empleado();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empleado>(readTask.Result.Object.ToString());

                        empleado.Empresa.Empresas = resultEmpresa.Objects;
                        empleado = resultItemList;
                    }
                    empleado = FillEmpresa(empleado);
                    return View(empleado);
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Empleado empleado, HttpPostedFileBase imgEmpleado)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["imgEmpleado"];
                if (imgEmpleado != null)
                {
                    empleado.Foto = this.ConvertToBites(imgEmpleado);
                }

                //AGREGAR
                if (empleado.IdEmpleado == 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(urlAPI);

                        var postTask = client.PostAsJsonAsync<ML.Empleado>("empleado", empleado);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("GetAll");
                            //ViewBag.Message = "Se ha insertado correctamente el empleado";
                        }
                        else
                        {
                            ViewBag.Message = "Ocurrio un problema al insertar el Empleado";
                        }
                    }
                    return View("GetAll");
                }
                //ACTUALIZAR
                else
                {
                    using (var client = new HttpClient())
                    {
                        int id = empleado.IdEmpleado;
                        client.BaseAddress = new Uri(urlAPI);

                        var postTasks = client.PutAsJsonAsync<ML.Empleado>("empleado/" + id, empleado);
                        postTasks.Wait();
                        var result = postTasks.Result;

                        if (result.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "Se ha actualizado correctamente el empleado";
                        }
                        else
                        {
                            ViewBag.Message = "Ocurrio un problema al actualizar el Empleado";
                        }
                    }
                }
                return PartialView("Modal");
            }
            empleado = FillEmpresa(empleado);
            return View(empleado);
        }

        [HttpGet]
        public ActionResult Delete(int IdEmpleado)
        {
            ML.Result resultListEmpleado = new ML.Result();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(urlAPI);

                var postTasks = client.DeleteAsync("empleado/" + IdEmpleado);
                postTasks.Wait();

                var result = postTasks.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se ha eliminado el Empleado correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un problema al eliminar al empleado. Error: ";
                }
                return PartialView("Modal");
            }

        }

        //CARGA MASIVA
        public ActionResult CargaMasiva()
        {
            ML.Empleado empleado = new ML.Empleado();
            return View(empleado);
        }

        //TXT
        public static ML.Empleado Previsualizar(ML.Empleado empleado, HttpPostedFileBase fuTxtCargaMasivaEmpleado)
        {
            empleado.Empleados = new List<object>();
            using (StreamReader file = new StreamReader(fuTxtCargaMasivaEmpleado.InputStream))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    if (counter > 0)
                    {
                        var datos = ln.Split('|');
                        //Console.WriteLine(ln);

                        ML.Empleado empleadoItem = new ML.Empleado();
                        empleadoItem.Empresa = new ML.Empresa();

                        empleadoItem.NumeroEmpleado = datos[0];
                        empleadoItem.RFC = datos[1];
                        empleadoItem.Nombre = datos[2];
                        empleadoItem.ApellidoPaterno = datos[3];
                        empleadoItem.ApellidoMaterno = datos[4];
                        empleadoItem.Email = datos[5];
                        empleadoItem.Telefono = datos[6];
                        empleadoItem.FechaNacimiento = datos[7].ToString();
                        empleadoItem.NSS = datos[8];
                        empleadoItem.FechaIngreso = datos[9].ToString();
                        empleadoItem.Empresa.IdEmpresa = (datos[10] != null) ? int.Parse(datos[10]) : int.Parse("0");

                        empleado.Empleados.Add(empleadoItem);
                    }
                    counter++;
                }
            }
            return empleado;
        }

        public void CargarDatos(ML.Empleado empleado)
        {
            List<string> listResult = new List<string>();
            int counter = 1;

            foreach (ML.Empleado empleadoItem in empleado.Empleados)
            {
                ML.Result result = BL.Empleado.Add(empleadoItem);

                //ServiceEmpleado.EmpleadoClient service = new ServiceEmpleado.EmpleadoClient();
                //var result = service.Add(empleadoItem);

                if (result.Correct)
                {
                    listResult.Add("La insercción del Empleado: " + empleadoItem.Nombre + " fue exitosa");
                }
                else
                {
                    listResult.Add("Hubo un error al insertar el Empleado: " + empleadoItem.Nombre + " Error: " + result.ErrorMessage);
                }
                counter++;
            }

            var fecha = DateTime.Now.ToString("dd-MM-yyyy HHmmss");
            string path = Server.MapPath("~/CargaMasiva/Reportes/" + "CargaMasiva_" + fecha + ".txt");

            using (StreamWriter archivo = System.IO.File.CreateText(path))
            {
                foreach (string mensaje in listResult)
                {
                    archivo.WriteLine(mensaje);
                }
            }

        }

        [HttpPost]
        public ActionResult CargaMasiva(ML.Empleado empleado, HttpPostedFileBase fuTxtCargaMasivaEmpleado)
        {
            if (Session["ListEmpleados"] == null)
            {
                //Validar extension del Archivo (xlsx, txt)
                if (fuTxtCargaMasivaEmpleado == null)
                {
                    ViewBag.Message = "No se selecciono un archivo";
                    return PartialView("Modal");
                }
                else
                {
                    string extension = Path.GetExtension(fuTxtCargaMasivaEmpleado.FileName);
                    if (extension == ".txt")
                    {

                        var fecha = DateTime.Now.ToString("dd-MM-yyyy HHmmss");
                        string direccionTxt = Server.MapPath("~/CargaMasiva/TXT/" + Path.GetFileNameWithoutExtension(fuTxtCargaMasivaEmpleado.FileName) + "-" + fecha + ".txt");
                        fuTxtCargaMasivaEmpleado.SaveAs(direccionTxt);

                        empleado = Previsualizar(empleado, fuTxtCargaMasivaEmpleado);

                        //Lista de Empleados
                        //Guardar un SESSION
                        Session["ListEmpleados"] = empleado.Empleados;

                    }
                    else
                    {
                        if (extension == ".xlsx")
                        {
                            string conexionExcel = System.Configuration.ConfigurationManager.AppSettings["ConexionExcel"];

                            var fecha = DateTime.Now.ToString("dd-MM-yyyy HHmmss");
                            string direccionExcel = Server.MapPath("~/CargaMasiva/Excel/" + Path.GetFileNameWithoutExtension(fuTxtCargaMasivaEmpleado.FileName) + "-" + fecha + ".xlsx");

                            fuTxtCargaMasivaEmpleado.SaveAs(direccionExcel);
                            empleado = PrevisualizarExcel(empleado, direccionExcel, conexionExcel);

                            //Lista de Empleados
                            //Guardar un SESSION
                            Session["ListEmpleados"] = empleado.Empleados;
                        }
                        else
                        {
                            ViewBag.Message = "Archivo no valido";
                            return PartialView("Modal");
                        }
                    }
                }
            }
            else
            {
                if (fuTxtCargaMasivaEmpleado != null)
                {
                    Session["ListEmpleados"] = null;
                    CargaMasiva(empleado, fuTxtCargaMasivaEmpleado);
                }
                else
                {
                    var x = (List<object>)Session["ListEmpleados"];
                    empleado.Empleados = x;

                    CargarDatos(empleado);

                    //Vaciar el Session
                    Session["ListEmpleados"] = null;

                    ViewBag.Message = "Se han insertado los registros";
                    return PartialView("Modal");
                }
            }

            return View(empleado);
        }

        //Excel
        public ML.Empleado PrevisualizarExcel(ML.Empleado empleado, string RutaExcel, string CadenaConexion)
        {
            using (OleDbConnection context = new OleDbConnection(CadenaConexion + RutaExcel))
            {

                string query = "SELECT * FROM [Sheet1$]";
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection = context;

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.SelectCommand = cmd;

                    DataTable tableEmpleado = new DataTable();
                    da.Fill(tableEmpleado);

                    if (tableEmpleado.Rows.Count > 0)
                    {
                        empleado.Empleados = new List<object>();

                        foreach (DataRow row in tableEmpleado.Rows)
                        {
                            ML.Empleado empleadoItem = new ML.Empleado();
                            empleadoItem.Empresa = new ML.Empresa();

                            empleadoItem.NumeroEmpleado = row[0].ToString();
                            empleadoItem.RFC = row[1].ToString();
                            empleadoItem.Nombre = row[2].ToString();
                            empleadoItem.ApellidoPaterno = row[3].ToString();
                            empleadoItem.ApellidoMaterno = row[4].ToString();
                            empleadoItem.Email = row[5].ToString();
                            empleadoItem.Telefono = row[6].ToString();
                            empleadoItem.FechaNacimiento = row[7].ToString();
                            empleadoItem.NSS = row[8].ToString();
                            empleadoItem.FechaIngreso = row[9].ToString();
                            empleadoItem.Empresa.IdEmpresa = (row[10].ToString() != null) ? int.Parse(row[10].ToString()) : int.Parse("0");

                            empleado.Empleados.Add(empleadoItem);
                        }
                    }
                }
            }

            return empleado;
        }

        ////IMAGEN
        public byte[] ConvertToBites(HttpPostedFileBase img)
        {
            byte[] imgBites = null;
            BinaryReader reader = new BinaryReader(img.InputStream);
            imgBites = reader.ReadBytes((int)img.ContentLength);
            return imgBites;
        }

        private ML.Empleado FillEmpresa(ML.Empleado empleado)
        {
            ML.Result resultEmpresa = BL.Empresa.GetAll();
            empleado.Empresa.Empresas = resultEmpresa.Objects;

            return empleado;
        }
    }
}