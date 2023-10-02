using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class EmpleadoController : ApiController
    {
        //[HttpGet]
        //[Route("api/empleado")]
        //public IHttpActionResult Get()
        //{
        //    ML.Empleado empleado = new ML.Empleado();
        //    empleado.Empresa = new ML.Empresa();
        //    ML.Result result = BL.Empleado.GetAllView(empleado);
        //    if (result.Correct)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        [HttpPost]
        [Route("api/empleados")]
        public IHttpActionResult Get(ML.Empleado empleado)
        {
            //empleado.Empresa = new ML.Empresa();
            ML.Result result = BL.Empleado.GetAllView(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/empleado/{IdEmpleado}")]
        public IHttpActionResult GetById(int IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            ML.Result result = BL.Empleado.GetById(IdEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/empleado")]
        public IHttpActionResult Post([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("api/empleado/{IdEmpleado}")]
        public IHttpActionResult Put(int IdEmpleado, [FromBody] ML.Empleado empleado)
        {
            empleado.IdEmpleado = IdEmpleado;
            ML.Result result = BL.Empleado.Update(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("api/empleado/{IdEmpleado}")]
        public IHttpActionResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(IdEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
