using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        //CONSULTAS SQL
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    //SqlCommand cmd = new SqlCommand("INSERT INTO Usuario (Nombre, Apellidos, Correo, Contrasenia, Rol) VALUES (@Nombre, @Apellidos, @Correo, @Contrasenia, @Rol)", conn);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO Usuario (UserName, Nombre, ApellidoPaterno, ApellidoMaterno, Email, Password, Sexo, Telefono, Celular, FechaNacimiento, CURP, IdRol) VALUES(@UserName, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Email, @Password, @Sexo, @Telefono, @Celular, @FechaNacimiento, @CURP, @IdRol)";
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("CURP", usuario.CURP);
                    //cmd.Parameters.AddWithValue("@Imagen", usuario.Imagen);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un problema al insertar";
                    }
                }

            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Usuario SET UserName = @UserName, Nombre = @Nombre, ApellidoPaterno = @ApellidoPaterno, @ApellidoMaterno = ApellidoMaterno, Email = @Email, Password = @Password,Sexo = @Sexo,Telefono = @Telefono, Celular = @Celular, FechaNacimiento = @FechaNacimiento, CURP = @CURP, IdRol = @IdRol WHERE IdUsuario = @IdUsuario", conn);

                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@CURP", usuario.CURP);
                    //cmd.Parameters.AddWithValue("@Imagen", usuario.Imagen);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
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
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;

        }

        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario", conn);
                    //SqlCommand cmd = new SqlCommand("EXEC DeleteUser @IdUsuario = @IdUsuario", conn);
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
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
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT IdUsuario, UserName, Nombre, ApellidoPaterno, ApellidoMaterno, Email, Password, Sexo, Telefono, Celular, CAST(FORMAT(FechaNacimiento, 'dd / MMMM / yyyy') AS VARCHAR(30)) AS FechaNacimiento, CURP, IdRol FROM Usuario ORDER BY Nombre DESC";
                    //cmd.CommandText = "EXEC GetAllUsers";
                    cmd.Connection = conn;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd); //Puente de la Base de Datos y el Programa que obtiene los datos
                    DataTable tablaUsuario = new DataTable();

                    adapter.Fill(tablaUsuario);

                    if (tablaUsuario.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (DataRow row in tablaUsuario.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Rol = new ML.Rol();

                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.UserName = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.Sexo = row[7].ToString();
                            usuario.Telefono = row[8].ToString();
                            usuario.Celular = row[9].ToString();
                            usuario.FechaNacimiento = DateTime.Parse(row[10].ToString());
                            usuario.CURP = row[11].ToString();
                            //usuario.Imagen = row[12].ToString();
                            usuario.Rol.IdRol = int.Parse(row[12].ToString());

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT IdUsuario, UserName, Nombre, ApellidoPaterno, ApellidoMaterno, Email, Password, Sexo, Telefono, Celular, CAST(FORMAT(FechaNacimiento, 'dd / MMMM / yyyy') AS VARCHAR(30)) AS FechaNacimiento, CURP, IdRol FROM Usuario WHERE IdUsuario = @IdUsuario";
                    //cmd.CommandText = "EXEC GetById @IdUsuario = @IdUsuario";
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.Connection = conn;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        result.Object = new Object();

                        DataRow row = dataTable.Rows[0];
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Rol = new ML.Rol();

                        usuario.IdUsuario = int.Parse(row[0].ToString());
                        usuario.UserName = row[1].ToString();
                        usuario.Nombre = row[2].ToString();
                        usuario.ApellidoPaterno = row[3].ToString();
                        usuario.ApellidoMaterno = row[4].ToString();
                        usuario.Email = row[5].ToString();
                        usuario.Password = row[6].ToString();
                        usuario.Sexo = row[7].ToString();
                        usuario.Telefono = row[8].ToString();
                        usuario.Celular = row[9].ToString();
                        usuario.FechaNacimiento = DateTime.Parse(row[10].ToString());
                        usuario.CURP = row[11].ToString();
                        //usuario.Imagen = row[12].ToString();
                        usuario.Rol.IdRol = int.Parse(row[12].ToString());

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro al usuario";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }


        //STORED PROCEDURE
        public static ML.Result AddProcedure(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    //cmd.CommandText = "EXEC UserAdd @UserName = @UserName, @Nombre = @Nombre, @ApellidoPaterno = @ApellidoPaterno, @ApellidoMaterno = @ApellidoMaterno, @Email = @Email, @Password = @Password, @Sexo = @Sexo, @Telefono = @Telefono, @Celular = @Celular, @FechaNacimiento = @FechaNacimiento, @CURP = @CURP,  @IdRol = @IdRol";
                    cmd.CommandText = "UsuarioAdd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@CURP", usuario.CURP);
                    //cmd.Parameters.AddWithValue("@Imagen", usuario.Imagen);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un Problema al insertar";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result UpdateProcedure(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    //cmd.CommandText = "EXEC UserUpdate @UserName = @UserName, @Nombre = @Nombre, @ApellidoPaterno = @ApellidoPaterno, @ApellidoMaterno = @ApellidoMaterno, @Email = @Email, @Password = @Password, @Sexo = @Sexo, @Telefono = @Telefono, @Celular = @Celular, @FechaNacimiento = @FechaNacimiento, @CURP = @CURP, @IdRol = @IdRol, @IdUsuario = @IdUsuario";
                    cmd.CommandText = "UsuarioUpdate";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Password", usuario.Password);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@CURP", usuario.CURP);
                    //cmd.Parameters.AddWithValue("@Imagen", usuario.Imagen);
                    cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un Problema al Actualizar";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result DeleteProcedure(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    //cmd.CommandText = "EXEC UserDelete @IdUsuario = @IdUsuario";
                    cmd.CommandText = "UsuarioDelete";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un problema al Eliminar";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result GetAllProcedure()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "EXEC UserGetAll";
                    cmd.CommandText = "UsuarioGetAll";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in table.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Rol = new ML.Rol();

                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.UserName = row[1].ToString();
                            usuario.Nombre = row[2].ToString();
                            usuario.ApellidoPaterno = row[3].ToString();
                            usuario.ApellidoMaterno = row[4].ToString();
                            usuario.Email = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.Sexo = row[7].ToString();
                            usuario.Telefono = row[8].ToString();
                            usuario.Celular = row[9].ToString();
                            usuario.FechaNacimiento = DateTime.Parse(row[10].ToString());
                            usuario.CURP = row[11].ToString();
                            //usuario.Imagen = row[12].ToString();
                            usuario.Rol.Nombre = row[12].ToString();
                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result GetByIdProcedure(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "EXEC UserGetById @IdUsuario = @IdUsuario";
                    cmd.CommandText = "UsuarioGetById";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.Connection = conn;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        result.Object = new Object();
                        DataRow row = table.Rows[0];

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Rol = new ML.Rol();

                        usuario.IdUsuario = int.Parse(row[0].ToString());
                        usuario.UserName = row[1].ToString();
                        usuario.Nombre = row[2].ToString();
                        usuario.ApellidoPaterno = row[3].ToString();
                        usuario.ApellidoMaterno = row[4].ToString();
                        usuario.Email = row[5].ToString();
                        usuario.Password = row[6].ToString();
                        usuario.Sexo = row[7].ToString();
                        usuario.Telefono = row[8].ToString();
                        usuario.Celular = row[9].ToString();
                        usuario.FechaNacimiento = DateTime.Parse(row[10].ToString());
                        usuario.CURP = row[11].ToString();
                        //usuario.Imagen = row[12].ToString();
                        usuario.Rol.IdRol = int.Parse(row[12].ToString());
                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro al usuario";
                    }
                }

            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }


        //ENTITY FRAMEWORK
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    ObjectParameter output = new ObjectParameter("IdUsuario", typeof(int));
                    var resultQuery = context.UsuarioAdd(
                        usuario.UserName,
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno,
                        usuario.Email,
                        usuario.Password,
                        usuario.Sexo,
                        usuario.Telefono,
                        usuario.Celular,
                        usuario.FechaNacimiento,
                        usuario.CURP,
                        usuario.Imagen,
                        true,
                        usuario.Rol.IdRol,
                        output
                        );

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                        result.Object = Convert.ToInt32(output.Value);
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo añadir el registro de usuario";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var resultQuery = context.UsuarioUpdate(
                        usuario.UserName,
                        usuario.Nombre,
                        usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno,
                        usuario.Email,
                        usuario.Password,
                        usuario.Sexo,
                        usuario.Telefono,
                        usuario.Celular,
                        usuario.FechaNacimiento,
                        usuario.CURP,
                        usuario.Imagen,
                        usuario.Status,
                        usuario.Rol.IdRol,
                        usuario.IdUsuario);

                    if (resultQuery > 0)
                    {
                        result.Correct = true;
                        result.Object = Convert.ToInt32(usuario.IdUsuario);
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un Problema al actualizar";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var resultQuery = context.UsuarioDelete(IdUsuario);

                    if (resultQuery > 0)
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
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var usuarios = context.UsuarioGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)
                    {
                        foreach (var obj in usuarios)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Rol = new ML.Rol();
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.UserName = obj.UserName;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = (obj.ApellidoMaterno != null) ? obj.ApellidoMaterno : "";
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Password;
                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = (obj.Celular != null) ? obj.Celular : "";
                            usuario.FechaNacimiento = obj.FechaNacimiento.Value;
                            usuario.CURP = (obj.CURP != null) ? obj.CURP : "";
                            usuario.Imagen = obj.Imagen;
                            //usuario.Status = (obj.Status.Value) ? false : true;
                            usuario.Status = obj.Status.Value;
                            usuario.Rol.Nombre = obj.Rol;
                            usuario.Rol.IdRol = (obj.IdRol != null) ? int.Parse(obj.IdRol.Value.ToString()) : int.Parse("0");

                            usuario.Direccion.Calle = obj.Calle;
                            usuario.Direccion.NumeroInterior = obj.NumeroInterior;
                            usuario.Direccion.NumeroExterior = obj.NumeroExterior;
                            usuario.Direccion.Colonia.Nombre = obj.Colonia;
                            usuario.Direccion.Colonia.CodigoPostal = obj.CodigoPostal;
                            usuario.Direccion.Colonia.Municipio.Nombre = obj.Municipio;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = obj.Estado;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.Pais;

                            //usuario.Direccion.Calle = (obj.Calle != null) ? obj.Calle : "";
                            //usuario.Direccion.IdDireccion = (obj.IdDireccion != null) ? int.Parse(obj.IdDireccion.Value.ToString()) : int.Parse("0");

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Lista Vacia";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
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
                    var objUsuario = context.UsuarioGetById(IdUsuario).SingleOrDefault();
                    //var objDireccion = context.DireccionGetByIdUsuario(IdUsuario).SingleOrDefault();

                    result.Objects = new List<object>();
                    if (objUsuario != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Rol = new ML.Rol();
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.Email = objUsuario.Email;
                        usuario.Password = objUsuario.Password;
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento.Value;
                        usuario.CURP = objUsuario.CURP;
                        usuario.Imagen = objUsuario.Imagen;
                        usuario.Status = objUsuario.Status.Value;
                        usuario.Rol.IdRol = objUsuario.IdRol.Value;

                        usuario.Direccion.Calle = objUsuario.Calle;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;

                        usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia;
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Lista Vacia";
                    }
                }

            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        //LINQ
        public static ML.Result AddLQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.Sexo = usuario.Sexo;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.FechaNacimiento = usuario.FechaNacimiento;
                    usuarioDL.CURP = usuario.CURP;
                    usuarioDL.Imagen = usuario.Imagen;
                    usuarioDL.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioDL);
                    context.SaveChanges();
                    result.Correct = true;
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result UpdateLQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var query = (from usuarioLQ in context.Usuarios
                                 where usuarioLQ.IdUsuario == usuario.IdUsuario
                                 select usuarioLQ).SingleOrDefault();

                    if (query != null)
                    {
                        query.UserName = usuario.UserName;
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.Email = usuario.Email;
                        query.Password = usuario.Password;
                        query.Sexo = usuario.Sexo;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.FechaNacimiento = usuario.FechaNacimiento;
                        query.CURP = usuario.CURP;
                        query.Imagen = usuario.Imagen;
                        query.IdRol = usuario.Rol.IdRol;

                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un problema al Actualizar";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result DeleteLQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var query = (from usuarioLQ in context.Usuarios
                                 where usuarioLQ.IdUsuario == IdUsuario
                                 select usuarioLQ).First();

                    context.Usuarios.Remove(query);
                    context.SaveChanges();
                    result.Correct = true;
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result GetAllLQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var query = (from usuarioLQ in context.Usuarios
                                 join rol in context.Rols on usuarioLQ.IdRol equals rol.IdRol
                                 select new
                                 {
                                     usuarioLQ,
                                     rolName = rol.Nombre
                                 });
                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.Rol = new ML.Rol();

                            usuario.IdUsuario = obj.usuarioLQ.IdUsuario;
                            usuario.UserName = obj.usuarioLQ.UserName;
                            usuario.Nombre = obj.usuarioLQ.Nombre;
                            usuario.ApellidoPaterno = obj.usuarioLQ.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.usuarioLQ.ApellidoMaterno;
                            usuario.Email = obj.usuarioLQ.Email;
                            usuario.Password = obj.usuarioLQ.Password;
                            usuario.Sexo = obj.usuarioLQ.Sexo;
                            usuario.Telefono = obj.usuarioLQ.Telefono;
                            usuario.Celular = obj.usuarioLQ.Celular;
                            usuario.FechaNacimiento = obj.usuarioLQ.FechaNacimiento.Value;
                            usuario.CURP = obj.usuarioLQ.CURP;
                            usuario.Imagen = obj.usuarioLQ.Imagen;
                            usuario.Rol.Nombre = obj.rolName;
                            //usuario.Rol.IdRol = (obj.IdRol != null) ? int.Parse(obj.IdRol.Value.ToString()) : int.Parse("0");

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Lista Vacia";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

        public static ML.Result GetByIdLQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.RGeronimoProgramacionNCapasEntities context = new DL_EF.RGeronimoProgramacionNCapasEntities())
                {
                    var query = (from usuarioLQ in context.Usuarios
                                 where usuarioLQ.IdUsuario == IdUsuario
                                 select usuarioLQ).Single();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Rol = new ML.Rol();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.UserName = query.UserName;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.FechaNacimiento = query.FechaNacimiento.Value;
                        usuario.CURP = query.CURP;
                        usuario.Imagen = query.Imagen;
                        usuario.Rol.IdRol = query.IdRol.Value;

                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el usuario";
                    }
                }

            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }
            return result;
        }

    }
}
