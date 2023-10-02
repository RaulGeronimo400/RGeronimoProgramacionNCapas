using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BL
{
    public class Text
    {
        public static void ReadText()
        {
            List<string> listResult = new List<string>();
            using (StreamReader file = new StreamReader("C://Users//digis//Desktop//Carga.txt"))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    if (counter > 0)
                    {
                        var datos = ln.Split('|');
                        Console.WriteLine(ln);

                        ML.Empleado empleado = new ML.Empleado();
                        empleado.Empresa = new ML.Empresa();

                        empleado.NumeroEmpleado = datos[0];
                        empleado.RFC = datos[1];
                        empleado.Nombre = datos[2];
                        empleado.ApellidoPaterno = datos[3];
                        empleado.ApellidoMaterno = datos[4];
                        empleado.Email = datos[5];
                        empleado.Telefono = datos[6];
                        empleado.FechaNacimiento = datos[7].ToString();
                        empleado.NSS = datos[8];
                        empleado.FechaIngreso = datos[9].ToString();
                        empleado.Empresa.IdEmpresa = (datos[10] != null) ? int.Parse(datos[10]) : int.Parse("0");

                        ML.Result result = BL.Empleado.Add(empleado);

                        if (result.Correct)
                        {
                            listResult.Add("La insersión del Empleado: " + empleado.Nombre + " fue exitosa");
                        }
                        else
                        {
                            listResult.Add("La insersión del Empleado: " + empleado.Nombre + " fue erronea. Error: " + result.ErrorMessage);
                        }
                    }
                    counter++;
                }
                file.Close();
            }
        }
    }
}
