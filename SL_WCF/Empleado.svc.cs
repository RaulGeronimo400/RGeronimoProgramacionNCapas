using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Empleado" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Empleado.svc o Empleado.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Empleado : IEmpleado
    {
        public SL_WCF.Result Add(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            SL_WCF.Result resultSL = new SL_WCF.Result();

            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.Ex = result.Ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public SL_WCF.Result Update(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);
            SL_WCF.Result resultSL = new SL_WCF.Result();

            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.Ex = result.Ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public SL_WCF.Result Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(IdEmpleado);
            SL_WCF.Result resultSL = new SL_WCF.Result();

            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.Ex = result.Ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public SL_WCF.Result GetAll(ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.GetAllView(empleado);
            SL_WCF.Result resultSL = new SL_WCF.Result();

            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.Ex = result.Ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }

        public SL_WCF.Result GetById(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(IdEmpleado);
            SL_WCF.Result resultSL = new SL_WCF.Result();

            resultSL.Correct = result.Correct;
            resultSL.ErrorMessage = result.ErrorMessage;
            resultSL.Ex = result.Ex;
            resultSL.Object = result.Object;
            resultSL.Objects = result.Objects;

            return resultSL;
        }
    }
}
