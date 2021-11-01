using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;


namespace ComputerTech.DataAccessLayer
{
    class BarrioDao
    {

        UsuarioDao oUsuario = new UsuarioDao();

        public IList<Barrio> GetAll()
        {
            List<Barrio> listadoBugs = new List<Barrio>();

            var strSql = " SELECT id_barrio, nombre" +
                         " FROM Barrios Where borrado = 0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBugs.Add(MappingBug(row));
            }

            return listadoBugs;
        }

        public Barrio GetBarrio(string idBarrio)
        {
            //Construimos la consulta sql para buscar el barrio en la base de datos.
            String consultaSql = string.Concat(" SELECT id_barrio, nombre ",
                                                " FROM Barrios " +
                                                " WHERE borrado=0 and id_barrio =  ", idBarrio);

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingBug(resultado.Rows[0]);
            }

            return null;
        }

        private Barrio MappingBug(DataRow row)
        {
            Barrio oBarrio = new Barrio
            {
                Id_barrio = Convert.ToInt32(row["id_barrio"].ToString()),
                Nombre = row["nombre"].ToString(),
            };

            return oBarrio;
        }

        public void crearBarrio(Barrio barrio)
        {
            string SQLInsert = " INSERT INTO Barrios (nombre, borrado) " +
                               "VALUES ('" + barrio.Nombre + "', 0)";



            DataManager.GetInstance().EjecutarSQL(SQLInsert);
        }

        public void actualizarBarrio(Barrio barrio)
        {
            string SQLUpdate = "UPDATE barrios set nombre= '" + barrio.Nombre + "'" +
                                "WHERE id_barrio = " + barrio.Id_barrio;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);
        }

        public void eliminarBarrio(Barrio barrio)
        {
            string SQLUpdate = "UPDATE barrios set borrado = 1 WHERE id_barrio = " + barrio.Id_barrio;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);
        }

        public IList<Barrio> recuperarBarrioNombre(string barrio)
        {
            List<Barrio> listadoBugs = new List<Barrio>();

            var strSql = " SELECT id_barrio, nombre" +
                         " FROM Barrios WHERE borrado = 0 AND nombre LIKE '%" + barrio + "%'";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBugs.Add(MappingBug(row));
            }

            return listadoBugs;
        }
    }
}
