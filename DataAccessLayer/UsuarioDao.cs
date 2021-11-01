using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComputerTech.DataAccessLayer
{
    public class UsuarioDao
    {
        PerfilDao oPerfil = new PerfilDao();
        public IList<Usuario> GetAll()
        {
            List<Usuario> listadoUsuarios = new List<Usuario>();

            var strSql = "SELECT id_usuario, id_perfil, usuario, email, estado, password FROM Usuarios WHERE borrado=0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoUsuarios.Add(MappingUsuario(row));
            }

            return listadoUsuarios;
        }

        public Usuario GetUser(string pUsuario)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String consultaSql = string.Concat("SELECT id_usuario, usuario, email, estado, password, id_perfil ",
                                                "FROM Usuarios ",
                                                "WHERE borrado=0 and usuario =  '", pUsuario, "'");

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingUsuario(resultado.Rows[0]);
            }

            return null;
        }

        internal Usuario GetUserID(string idUsuario)
        {
            String consultaSql = string.Concat("SELECT id_usuario, usuario, email, estado, password, id_perfil ",
                                                "FROM Usuarios ",
                                                "WHERE borrado=0 and id_usuario = " + idUsuario);

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingUsuario(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Usuario> recuperarUsuarioConsulta(string usuario, string mail, string estado, int cboPerfilSeleccion)
        {
            List<Usuario> listadoUsuario = new List<Usuario>();

            var strSql = "SELECT id_usuario, id_perfil, usuario, email, estado, password" +
                        " from Usuarios where borrado = 0 AND usuario like '%" + usuario + "%' AND email like '%" + mail + "%' " +
                        "AND estado like '%" + estado + "%'";

            if (cboPerfilSeleccion != -1)
                strSql += " AND id_perfil = " + cboPerfilSeleccion;

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoUsuario.Add(MappingUsuario(row));
            }

            return listadoUsuario;
        }

        public Usuario GetUserId(string idUsuario)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String consultaSql = string.Concat("SELECT id_usuario, usuario, email, estado, password, id_perfil ",
                                                "   FROM Usuarios ",
                                                "  WHERE borrado=0 and id_usuario =  '", idUsuario, "'");

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingUsuario(resultado.Rows[0]);
            }

            return null;
        }

        private Usuario MappingUsuario(DataRow row)
        {
            Usuario oUsuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(row["id_usuario"].ToString()),
                NombreUsuario = row["usuario"].ToString(),
                Email = row["email"].ToString(),
                Estado = row["estado"].ToString(),
                Password = row.Table.Columns.Contains("password") ? row["password"].ToString() : null,
                Perfil = oPerfil.GetPerfil(row["id_perfil"].ToString())
            };

            return oUsuario;
        }

        public void eliminarUsuario(Usuario usuario)
        {
            string SQLUpdate = "UPDATE Usuarios SET borrado = 1 WHERE id_usuario = " + usuario.IdUsuario;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);
        }

        public void crearUsuario(Usuario usuario)
        {
            string SQLInsert = " INSERT INTO Usuarios(id_perfil, usuario, password, email, estado, borrado) " +
                               "VALUES (" + usuario.Perfil.Id_Perfil + ", '" + usuario.NombreUsuario + "', '"
                                            + usuario.Password + "','" + usuario.Email + "','" + usuario.Estado + "', 0) ";

            DataManager.GetInstance().EjecutarSQL(SQLInsert);
        }

        public void actualizarUsuario(Usuario usuario)
        {
            string SQLUpdate = "UPDATE Usuarios SET id_perfil= " + usuario.Perfil.Id_Perfil + ", " +
                                                     "usuario= '" + usuario.NombreUsuario + "', " +
                                                     "password= '" + usuario.Password + "', " +
                                                     "email= '" + usuario.Email + "', " +
                                                     "estado= '" + usuario.Estado + "'" +
                                                     " WHERE id_usuario= " + usuario.IdUsuario;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);
        }
    }

}
