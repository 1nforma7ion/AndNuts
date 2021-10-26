using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Conectar base de datos
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using CapaEntidades.Cache;
using System.Data;
using System.IO;

namespace CapaDatos
{
    public class D_Usuarios
    {
        SqlConnection conexion = new SqlConnection("server=PC-FACU; database=AndNuts; integrated security=true");


        //LOGIN USUARIO
        public bool Login(string User, String Pass)
        {
            SqlCommand cmd = new SqlCommand("select Usuarios.Id_User, Usuarios.Nombre_User, Usuarios.Apellido_User, Usuarios.Email_User, Usuarios.Telefono_User, Usuarios.Foto_User, Usuarios.UserName, Usuarios.Contraseña_User, Roles.Permiso from Usuarios inner join Roles on Usuarios.Id_Rol_User = Roles.Id_Rol where UserName = @User AND Contraseña_User = @Pass", conexion);
            cmd.CommandType = CommandType.Text;
            conexion.Open();

            cmd.Parameters.AddWithValue("@User", User);
            cmd.Parameters.AddWithValue("@Pass", Pass);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserLoginCache.Id_User = reader.GetInt32(0);
                    UserLoginCache.Nombre_User = reader.GetString(1);
                    UserLoginCache.Apellido_User = reader.GetString(2);
                    UserLoginCache.Email_User = reader.GetString(3);
                    UserLoginCache.Telefono_User = reader.GetString(4);
                    UserLoginCache.Foto_User = (byte[])reader["Foto_User"];
                    UserLoginCache.UserName = reader.GetString(6);
                    UserLoginCache.Contraseña_User = reader.GetString(7);
                    UserLoginCache.Permiso = reader.GetString(8);

                    
                }

                return true;
            }
            else
            {
                return false;
            }

            conexion.Close();
        }

        //LISTAR USUARIOS
        public DataTable ListarUsuarios()
        {
            DataTable tabla = new DataTable();
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_ListUser", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);

            LeerFilas.Close();
            conexion.Close();

            return tabla;
        }

        //INSERTAR USUARIO
        public void InsertarUsuario(E_Usuarios usuarios)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre_User", usuarios.Nombre_User1);
            cmd.Parameters.AddWithValue("@Apellido_User", usuarios.Apellido_User1);
            cmd.Parameters.AddWithValue("@Email_User", usuarios.Email_User1);
            cmd.Parameters.AddWithValue("@Telefono_User", usuarios.Telefono_User1);
            cmd.Parameters.AddWithValue("@Foto_User", usuarios.Foto_User1);
            cmd.Parameters.AddWithValue("@UserName", usuarios.UserName1);
            cmd.Parameters.AddWithValue("@Contraseña_User", usuarios.Contraseña_User1);
            cmd.Parameters.AddWithValue("@Id_Rol_User", usuarios.Id_Rol_User1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //LLENAR COMBOBOX ROLES
        public DataTable ListarRoles()
        {
            DataTable tabla = new DataTable();
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("select Id_Rol, Permiso from Roles Order by Id_Rol asc", conexion);
            cmd.CommandType = CommandType.Text;
            conexion.Open();
            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.Close();
            return tabla;
        }

        //CBX USUARIOS
        public DataTable CbxTrabajadores()
        {
            DataTable tabla = new DataTable();
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("select Id_User, (Nombre_User + ' ' + Apellido_User) as Trabajador from Usuarios Order by Id_User asc", conexion);
            cmd.CommandType = CommandType.Text;
            conexion.Open();
            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.Close();
            return tabla;
        }

        //EDITAR USUARIO
        public void EditarUsuario(E_Usuarios usuarios)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Id_User", usuarios.Id_User1);
            cmd.Parameters.AddWithValue("@Nombre_User", usuarios.Nombre_User1);
            cmd.Parameters.AddWithValue("@Apellido_User", usuarios.Apellido_User1);
            cmd.Parameters.AddWithValue("@Email_User", usuarios.Email_User1);
            cmd.Parameters.AddWithValue("@Telefono_User", usuarios.Telefono_User1);
            cmd.Parameters.AddWithValue("@Foto_User", usuarios.Foto_User1);
            cmd.Parameters.AddWithValue("@UserName", usuarios.UserName1);
            cmd.Parameters.AddWithValue("@Contraseña_User", usuarios.Contraseña_User1);
            cmd.Parameters.AddWithValue("@Id_Rol_User", usuarios.Id_Rol_User1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        //RECUPERAR CONTRASEÑA
        public string RecuperarPass(string userRequesting)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("select * from Usuarios where UserName = @User or Email_User = @Email ", conexion);
            cmd.CommandType = CommandType.Text;
            conexion.Open();
            cmd.Parameters.AddWithValue("@User", userRequesting);
            cmd.Parameters.AddWithValue("@Email", userRequesting);

            LeerFilas = cmd.ExecuteReader();

            if (LeerFilas.Read() == true)
            {
                string UserName = LeerFilas.GetString(1) + ", " + LeerFilas.GetString(2);
                string UserMail = LeerFilas.GetString(3);
                string AccountPass = LeerFilas.GetString(7);

                var mailService = new MailServices.SystemSupportMail();
                mailService.sendMail(
                  subject: "SYSTEM: Solicitud De recuperacion de contraseña",
                  body: "Hola, " + UserName + "\nHa solicitado recuperar su contraseña.\n" +
                  "su contraseña actual es: " + AccountPass +
                  "\nSin embargo, le pedimos que cambie su contraseña inmediatamente una vez que ingrese al sistema..",
                  recipientMail: new List<string> { UserMail }
                  );

                return "Hola, " + UserName + "\nHa solicitado recuperar su contraseña.\n" +
                  "\n Le llegara un Email con la contraseña actual";
            }

            else
            {
                E_Usuarios ObjEntidad = new E_Usuarios();
                return "Disculpe, no tiene una cuenta con este nombre de usuario o Email";
            }
        }
    }
}
