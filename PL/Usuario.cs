using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Usuario
    {
        //CONSULTAS SQL
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Usuario: ");
            usuario.UserName = Console.ReadLine();

            Console.Write("Ingrese el Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Ingrese el Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.Write("Ingrese el Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.Write("Ingrese el Correo: ");
            usuario.Email = Console.ReadLine();

            Console.Write("Ingrese la Contraseña: ");
            usuario.Password = Console.ReadLine();

            Console.Write("Ingrese el Sexo (H o M): ");
            usuario.Sexo = Console.ReadLine();

            Console.Write("Ingrese el Telefono Fijo: ");
            usuario.Telefono = Console.ReadLine();

            Console.Write("Ingrese el Telefono Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.Write("Ingrese su Fecha de Nacimiento (AAAA-MM-DD): ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese su CURP: ");
            usuario.CURP = Console.ReadLine();

            //Console.Write("Ingrese una Imagen: ");
            //usuario.Imagen = Console.ReadLine();

            Console.Write("Ingrese el Rol: ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.Add(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al registrar al usuario: " + usuario.Nombre);
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Usuario: ");
            usuario.UserName = Console.ReadLine();

            Console.Write("Ingrese el Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Ingrese el Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.Write("Ingrese el Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.Write("Ingrese el Correo: ");
            usuario.Email = Console.ReadLine();

            Console.Write("Ingrese la Contraseña: ");
            usuario.Password = Console.ReadLine();

            Console.Write("Ingrese el Sexo (H o M): ");
            usuario.Sexo = Console.ReadLine();

            Console.Write("Ingrese el Telefono Fijo: ");
            usuario.Telefono = Console.ReadLine();

            Console.Write("Ingrese el Telefono Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.Write("Ingrese su Fecha de Nacimiento (AAAA-MM-DD): ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el CURP: ");
            usuario.CURP = Console.ReadLine();

            //Console.Write("Ingrese una Imagen: ");
            //usuario.Imagen = Console.ReadLine();

            Console.Write("Ingrese el Rol: ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.Update(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Actualizado");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al actualizar al usuario: " + usuario.Nombre);
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.Delete(usuario.IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Eliminado");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al eliminar al usuario: " + usuario.Nombre);
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();
            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {

                    Console.WriteLine("ID: " + usuario.IdUsuario);
                    Console.WriteLine("USERNAME: " + usuario.UserName);
                    Console.WriteLine("NOMBRE: " + usuario.Nombre);
                    Console.WriteLine("PATERNO: " + usuario.ApellidoPaterno);
                    Console.WriteLine("MATERNO: " + usuario.ApellidoMaterno);
                    Console.WriteLine("CORREO: " + usuario.Email);
                    Console.WriteLine("CONTRASEÑA: " + usuario.Password);
                    Console.WriteLine("SEXO: " + usuario.Sexo);
                    Console.WriteLine("TELEFONO FIJO: " + usuario.Telefono);
                    Console.WriteLine("TELEFONO CELULAR: " + usuario.Celular);
                    Console.WriteLine("FECHA NACIMIENTO: " + usuario.FechaNacimiento.ToString("dd / MMMM / yyyy"));
                    Console.WriteLine("CURP: " + usuario.CURP);
                    //Console.WriteLine("IMAGEN: " + usuario.Imagen);
                    Console.WriteLine("ROL: " + usuario.Rol.IdRol);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Lista vacia");
            }

        }

        public static void GetById()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetById(usuario.IdUsuario);

            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;
                Console.WriteLine("ID: " + usuario.IdUsuario);
                Console.WriteLine("USERNAME: " + usuario.UserName);
                Console.WriteLine("NOMBRE: " + usuario.Nombre);
                Console.WriteLine("PATERNO: " + usuario.ApellidoPaterno);
                Console.WriteLine("MATERNO: " + usuario.ApellidoMaterno);
                Console.WriteLine("CORREO: " + usuario.Email);
                Console.WriteLine("CONTRASEÑA: " + usuario.Password);
                Console.WriteLine("SEXO: " + usuario.Sexo);
                Console.WriteLine("TELEFONO FIJO: " + usuario.Telefono);
                Console.WriteLine("TELEFONO CELULAR: " + usuario.Celular);
                Console.WriteLine("FECHA NACIMIENTO: " + usuario.FechaNacimiento.ToString("dd / MMMM / yyyy"));
                Console.WriteLine("CURP: " + usuario.CURP);
                Console.WriteLine("ROL: " + usuario.Rol.IdRol);
                //Console.WriteLine("IMAGEN: " + usuario.Imagen);
                //Console.WriteLine(String.Format("| {0,2} | {1,5} | {2,10} | {3,10} | {4,10} | {5,10} | {6,10} | {7,10} | {8,10} | {9,10} | {10,10} | {11,10} | {12,10} |", usuario.IdUsuario, usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento.ToString("dd / MMMM / yyyy"), usuario.CURP, usuario.IdRol));

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No se encontro el usuario");
            }
        }

        //STORED PROCEDURES
        public static void AddProcedure()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.Write("Ingrese el Usuario: ");
            usuario.UserName = Console.ReadLine();

            Console.Write("Ingrese el Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Ingrese el Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.Write("Ingrese el Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.Write("Ingrese el Correo: ");
            usuario.Email = Console.ReadLine();

            Console.Write("Ingrese la Contraseña: ");
            usuario.Password = Console.ReadLine();

            Console.Write("Ingrese el Sexo (H o M): ");
            usuario.Sexo = Console.ReadLine();

            Console.Write("Ingrese el Telefono Fijo: ");
            usuario.Telefono = Console.ReadLine();

            Console.Write("Ingrese el Telefono Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.Write("Ingrese su Fecha de Nacimiento (AAAA-MM-DD): ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese su CURP: ");
            usuario.CURP = Console.ReadLine();

            //Console.WriteLine("Ingrese una Imagen: ");
            //usuario.Imagen = Console.ReadLine();

            Console.Write("Ingrese el Rol: ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.Add(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al insertar al Usuario: " + usuario.UserName);
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void UpdateProcedure()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Usuario: ");
            usuario.UserName = Console.ReadLine();

            Console.Write("Ingrese el Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Ingrese el Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.Write("Ingrese el Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.Write("Ingrese el Correo: ");
            usuario.Email = Console.ReadLine();

            Console.Write("Ingrese la Contraseña: ");
            usuario.Password = Console.ReadLine();

            Console.Write("Ingrese el Sexo (H o M): ");
            usuario.Sexo = Console.ReadLine();

            Console.Write("Ingrese el Telefono Fijo: ");
            usuario.Telefono = Console.ReadLine();

            Console.Write("Ingrese el Telefono Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.Write("Ingrese su Fecha de Nacimiento (AAAA-MM-DD): ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el CURP: ");
            usuario.CURP = Console.ReadLine();

            //Console.WriteLine("Ingrese una Imagen: ");
            //usuario.Imagen = Console.ReadLine();

            Console.Write("Ingrese el Rol: ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.UpdateProcedure(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Actualizado");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al insertar al Usuario: " + usuario.UserName);
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void DeleteProcedure()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.DeleteProcedure(usuario.IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Eliminado");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al eliminar al usuario: " + usuario.Nombre);
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void GetAllProcedure()
        {
            ML.Result result = BL.Usuario.GetAllProcedure();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("ID: " + usuario.IdUsuario);
                    Console.WriteLine("USERNAME: " + usuario.UserName);
                    Console.WriteLine("NOMBRE: " + usuario.Nombre);
                    Console.WriteLine("PATERNO: " + usuario.ApellidoPaterno);
                    Console.WriteLine("MATERNO: " + usuario.ApellidoMaterno);
                    Console.WriteLine("CORREO: " + usuario.Email);
                    Console.WriteLine("CONTRASEÑA: " + usuario.Password);
                    Console.WriteLine("SEXO: " + usuario.Sexo);
                    Console.WriteLine("TELEFONO FIJO: " + usuario.Telefono);
                    Console.WriteLine("TELEFONO CELULAR: " + usuario.Celular);
                    Console.WriteLine("FECHA NACIMIENTO: " + usuario.FechaNacimiento.ToString("dd / MMMM / yyyy"));
                    Console.WriteLine("CURP: " + usuario.CURP);
                    //Console.WriteLine("IMAGEN: " + usuario.Imagen);
                    Console.WriteLine("ROL: " + usuario.Rol.IdRol);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Lista Vacia");
            }
        }

        public static void GetByIdProcedure()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetByIdProcedure(usuario.IdUsuario);

            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;
                Console.WriteLine("ID: " + usuario.IdUsuario);
                Console.WriteLine("USERNAME: " + usuario.UserName);
                Console.WriteLine("NOMBRE: " + usuario.Nombre);
                Console.WriteLine("PATERNO: " + usuario.ApellidoPaterno);
                Console.WriteLine("MATERNO: " + usuario.ApellidoMaterno);
                Console.WriteLine("CORREO: " + usuario.Email);
                Console.WriteLine("CONTRASEÑA: " + usuario.Password);
                Console.WriteLine("SEXO: " + usuario.Sexo);
                Console.WriteLine("TELEFONO FIJO: " + usuario.Telefono);
                Console.WriteLine("TELEFONO CELULAR: " + usuario.Celular);
                Console.WriteLine("FECHA NACIMIENTO: " + usuario.FechaNacimiento.ToString("dd / MMMM / yyyy"));
                Console.WriteLine("CURP: " + usuario.CURP);
                //Console.WriteLine("IMAGEN: " + usuario.Imagen);
                Console.WriteLine("ROL: " + usuario.Rol.IdRol);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No se encontro el usuario");
            }
        }

        //ENTITY FRAMEWORK
        public static void AddEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Usuario: ");
            usuario.UserName = Console.ReadLine();

            Console.Write("Ingrese el Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Ingrese el Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.Write("Ingrese es Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.Write("Ingrese el Correo: ");
            usuario.Email = Console.ReadLine();

            Console.Write("Ingrese la Contraseña: ");
            usuario.Password = Console.ReadLine();

            Console.Write("Ingrese el Sexo (H o M): ");
            usuario.Sexo = Console.ReadLine();

            Console.Write("Ingrese el Telefono Fijo: ");
            usuario.Telefono = Console.ReadLine();

            Console.Write("Ingrese el Telefono Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.Write("Ingrese su Fecha de Nacimiento (AAAA-MM-DD): ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el CURP: ");
            usuario.CURP = Console.ReadLine();

            Console.Write("Ingrese el Rol: ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.AddEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al insertar al Usuario: " + usuario.UserName);
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void UpdateEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Usuario: ");
            usuario.UserName = Console.ReadLine();

            Console.Write("Ingrese el Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Ingrese el Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.Write("Ingrese el Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.Write("Ingrese el Correo: ");
            usuario.Email = Console.ReadLine();

            Console.Write("Ingrese la Contraseña: ");
            usuario.Password = Console.ReadLine();

            Console.Write("Ingrese el Sexo (H o M): ");
            usuario.Sexo = Console.ReadLine();

            Console.Write("Ingrese el Telefono Fijo: ");
            usuario.Telefono = Console.ReadLine();

            Console.Write("Ingrese el Telefono Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.Write("Ingrese su Fecha de Nacimiento (AAAA-MM-DD): ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el CURP: ");
            usuario.CURP = Console.ReadLine();

            //Console.WriteLine("Ingrese una Imagen: ");
            //usuario.Imagen = Console.ReadLine();

            Console.Write("Ingrese el Rol: ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.UpdateEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Actualizado");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al actualizar al Usuario: " + usuario.UserName);
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void DeleteEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.DeleteEF(usuario.IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Eliminado");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al eliminar al usuario: " + usuario.Nombre);
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void GetAllEF()
        {
            ML.Result result = BL.Usuario.GetAllEF();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("ID: " + usuario.IdUsuario);
                    Console.WriteLine("USERNAME: " + usuario.UserName);
                    Console.WriteLine("NOMBRE: " + usuario.Nombre);
                    Console.WriteLine("PATERNO: " + usuario.ApellidoPaterno);
                    Console.WriteLine("MATERNO: " + usuario.ApellidoMaterno);
                    Console.WriteLine("CORREO: " + usuario.Email);
                    Console.WriteLine("CONTRASEÑA: " + usuario.Password);
                    Console.WriteLine("SEXO: " + usuario.Sexo);
                    Console.WriteLine("TELEFONO FIJO: " + usuario.Telefono);
                    Console.WriteLine("TELEFONO CELULAR: " + usuario.Celular);
                    Console.WriteLine("FECHA NACIMIENTO: " + usuario.FechaNacimiento.ToString("dd / MMMM / yyyy"));
                    Console.WriteLine("CURP: " + usuario.CURP);
                    //Console.WriteLine("IMAGEN: " + usuario.Imagen);
                    Console.WriteLine("ROL: " + usuario.Rol.IdRol);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Lista Vacia");
            }
        }

        public static void GetByIdEF()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetByIdEF(usuario.IdUsuario);

            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;
                Console.WriteLine("ID: " + usuario.IdUsuario);
                Console.WriteLine("USERNAME: " + usuario.UserName);
                Console.WriteLine("NOMBRE: " + usuario.Nombre);
                Console.WriteLine("PATERNO: " + usuario.ApellidoPaterno);
                Console.WriteLine("MATERNO: " + usuario.ApellidoMaterno);
                Console.WriteLine("CORREO: " + usuario.Email);
                Console.WriteLine("CONTRASEÑA: " + usuario.Password);
                Console.WriteLine("SEXO: " + usuario.Sexo);
                Console.WriteLine("TELEFONO FIJO: " + usuario.Telefono);
                Console.WriteLine("TELEFONO CELULAR: " + usuario.Celular);
                Console.WriteLine("FECHA NACIMIENTO: " + usuario.FechaNacimiento.ToString("dd / MMMM / yyyy"));
                Console.WriteLine("CURP: " + usuario.CURP);
                //Console.WriteLine("IMAGEN: " + usuario.Imagen);
                Console.WriteLine("ROL: " + usuario.Rol.IdRol);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No se encontro el usuario");
            }
        }

        //LINQ
        public static void AddLQ()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Usuario: ");
            usuario.UserName = Console.ReadLine();

            Console.Write("Ingrese el Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Ingrese el Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.Write("Ingrese es Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.Write("Ingrese el Correo: ");
            usuario.Email = Console.ReadLine();

            Console.Write("Ingrese la Contraseña: ");
            usuario.Password = Console.ReadLine();

            Console.Write("Ingrese el Sexo (H o M): ");
            usuario.Sexo = Console.ReadLine();

            Console.Write("Ingrese el Telefono Fijo: ");
            usuario.Telefono = Console.ReadLine();

            Console.Write("Ingrese el Telefono Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.Write("Ingrese su Fecha de Nacimiento (AAAA-MM-DD): ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese el CURP: ");
            usuario.CURP = Console.ReadLine();

            Console.Write("Ingrese el Rol: ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.AddLQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Exitoso");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al registrar al usuario: " + usuario.Nombre);
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void UpdateLQ()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Usuario: ");
            usuario.UserName = Console.ReadLine();

            Console.Write("Ingrese el Nombre: ");
            usuario.Nombre = Console.ReadLine();

            Console.Write("Ingrese el Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.Write("Ingrese el Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.Write("Ingrese el Correo: ");
            usuario.Email = Console.ReadLine();

            Console.Write("Ingrese la Contraseña: ");
            usuario.Password = Console.ReadLine();

            Console.Write("Ingrese el Sexo (H o M): ");
            usuario.Sexo = Console.ReadLine();

            Console.Write("Ingrese el Telefono Fijo: ");
            usuario.Telefono = Console.ReadLine();

            Console.Write("Ingrese el Telefono Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.Write("Ingrese su Fecha de Nacimiento (AAAA-MM-DD): ");
            usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese su CURP: ");
            usuario.CURP = Console.ReadLine();

            //Console.Write("Ingrese una Imagen: ");
            //usuario.Imagen = Console.ReadLine();

            Console.Write("Ingrese el Rol: ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.UpdateLQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Actualizado");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al actualizar al Usuario: " + usuario.UserName);
                Console.WriteLine(result.ErrorMessage);
            }
        }

        public static void DeleteLQ()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.DeleteLQ(usuario.IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro Eliminado");
            }
            else
            {
                Console.WriteLine("Ocurrio un problema al eliminar al usuario: " + usuario.Nombre);
                Console.WriteLine(result.ErrorMessage);
            }

        }

        public static void GetAllLQ()
        {
            ML.Result result = BL.Usuario.GetAllLQ();

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("ID: " + usuario.IdUsuario);
                    Console.WriteLine("USERNAME: " + usuario.UserName);
                    Console.WriteLine("NOMBRE: " + usuario.Nombre);
                    Console.WriteLine("PATERNO: " + usuario.ApellidoPaterno);
                    Console.WriteLine("MATERNO: " + usuario.ApellidoMaterno);
                    Console.WriteLine("CORREO: " + usuario.Email);
                    Console.WriteLine("CONTRASEÑA: " + usuario.Password);
                    Console.WriteLine("SEXO: " + usuario.Sexo);
                    Console.WriteLine("TELEFONO FIJO: " + usuario.Telefono);
                    Console.WriteLine("TELEFONO CELULAR: " + usuario.Celular);
                    Console.WriteLine("FECHA NACIMIENTO: " + usuario.FechaNacimiento.ToString("dd / MMMM / yyyy"));
                    Console.WriteLine("CURP: " + usuario.CURP);
                    //Console.WriteLine("IMAGEN: " + usuario.Imagen);
                    Console.WriteLine("ROL: " + usuario.Rol.IdRol);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Lista Vacia");
            }
        }

        public static void GetByIdLQ()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Id: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine();

            ML.Result result = BL.Usuario.GetByIdLQ(usuario.IdUsuario);

            if (result.Correct)
            {
                usuario = (ML.Usuario)result.Object;
                Console.WriteLine("ID: " + usuario.IdUsuario);
                Console.WriteLine("USERNAME: " + usuario.UserName);
                Console.WriteLine("NOMBRE: " + usuario.Nombre);
                Console.WriteLine("PATERNO: " + usuario.ApellidoPaterno);
                Console.WriteLine("MATERNO: " + usuario.ApellidoMaterno);
                Console.WriteLine("CORREO: " + usuario.Email);
                Console.WriteLine("CONTRASEÑA: " + usuario.Password);
                Console.WriteLine("SEXO: " + usuario.Sexo);
                Console.WriteLine("TELEFONO FIJO: " + usuario.Telefono);
                Console.WriteLine("TELEFONO CELULAR: " + usuario.Celular);
                Console.WriteLine("FECHA NACIMIENTO: " + usuario.FechaNacimiento.ToString("dd / MMMM / yyyy"));
                Console.WriteLine("CURP: " + usuario.CURP);
                //Console.WriteLine("IMAGEN: " + usuario.Imagen);
                Console.WriteLine("ROL: " + usuario.Rol.IdRol);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No se encontro el usuario");
            }
        }
    }
}
