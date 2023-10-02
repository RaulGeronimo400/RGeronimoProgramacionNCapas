using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IOperaciones
    {
        public double Suma(double Numero1, double Numero2)
        {
            return Numero1 + Numero2;
        }

        public double Resta(double Numero1, double Numero2)
        {
            return Numero1 - Numero2;
        }

        public double Multiplicacion(double Numero1, double Numero2)
        {
            return Numero1 * Numero2;
        }

        public double Division(double Numero1, double Numero2)
        {
            return Numero1 / Numero2;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
