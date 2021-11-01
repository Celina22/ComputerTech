using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComputerTech.DataAccessLayer
{
    class ContactoDao
    {
        public IList<Contacto> GetAll()
        {
            List<Contacto> listadoContactos = new List<Contacto>();

            var SQLquery = "SELECT * FROM Contactos WHERE borrado=0";
            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);

            foreach (DataRow row in tabla.Rows)
                listadoContactos.Add(MappingContacto(row));

            return listadoContactos;
        }

        public Contacto GetContacto(string idContacto)
        {
            Contacto contactoObtenido;

            string consulta = "SELECT * FROM Contactos WHERE borrado=0 and id_contacto=" + idContacto;
            DataTable tabla = DataManager.GetInstance().ConsultaSQL(consulta);

            if (tabla.Rows.Count > 0)
            {
                contactoObtenido = MappingContacto(tabla.Rows[0]);
                return contactoObtenido;
            }
            return null;
        }
        public void actualizarContacto(Contacto contacto)
        {
            string SQLUpdate = "UPDATE Contactos SET nombre='" + contacto.Nombre + "', " +
                                                     "apellido='" + contacto.Apellido + "', " +
                                                     "email='" + contacto.Email + "', " +
                                                     "telefono=" + contacto.Telefono + " " +
                                                     "WHERE id_contacto=" + contacto.Id_contacto;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);

        }

        public List<Contacto> recuperarContactoConsulta(string nombre, string apellido, string email, string telefono)
        {
            List<Contacto> listadoContacto = new List<Contacto>();

            var strSql = "SELECT id_contacto, nombre, apellido, email, telefono" +
                        " from contactos where borrado = 0 AND nombre like '%" + nombre + "%' AND apellido like '%" + apellido + "%' " +
                        "AND email like '%" + email + "%' AND telefono like '%" + telefono + "%'";


            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoContacto.Add(MappingContacto(row));
            }

            return listadoContacto;
        }

        public void eliminarContacto(Contacto contacto)
        {
            string SQLUpdate = "UPDATE Contactos SET borrado=1 WHERE id_contacto=" + contacto.Id_contacto;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);
        }
        public void crearContacto(Contacto contacto)
        {
            string SQLInsert = string.Concat("INSERT INTO Contactos(nombre, apellido, email, telefono, borrado) VALUES('",
                                                contacto.Nombre, "','",
                                                contacto.Apellido, "','",
                                                contacto.Email, "',",
                                                contacto.Telefono, ",",
                                                0, ")");

            DataManager.GetInstance().EjecutarSQL(SQLInsert);
        }
        private Contacto MappingContacto(DataRow row)
        {
            Contacto oProyecto = new Contacto
            {
                Id_contacto = Convert.ToInt32(row["id_contacto"].ToString()),
                Nombre = row["nombre"].ToString(),
                Apellido = row["apellido"].ToString(),
                Email = row["email"].ToString(),
                Telefono = Convert.ToInt64(row["telefono"].ToString())
            };

            return oProyecto;
        }
    }
}
