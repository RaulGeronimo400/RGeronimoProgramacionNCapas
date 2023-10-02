using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEmpleado" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEmpleado
    {
        [OperationContract]
        SL_WCF.Result Add(ML.Empleado empleado);

        [OperationContract]
        SL_WCF.Result Update(ML.Empleado empleado);

        [OperationContract]
        SL_WCF.Result Delete(int IdEmpleado);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Empleado))]
        [ServiceKnownType(typeof(ML.Empresa))]
        SL_WCF.Result GetAll(ML.Empleado empleado);

        [OperationContract]
        [ServiceKnownType(typeof (ML.Empleado))]
        SL_WCF.Result GetById(int IdEmpleado);

    }
}
