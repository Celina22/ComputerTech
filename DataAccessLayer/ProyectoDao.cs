using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComputerTech.DataAccessLayer
{
    class ProyectoDao
    {
        ProductoDao oProducto = new ProductoDao();
        UsuarioDao oUsuario = new UsuarioDao();

        public IList<Proyecto> GetAll()
        {
            List<Proyecto> listadoBugs = new List<Proyecto>();

            var strSql = " SELECT p.id_proyecto, p.id_producto, p.descripcion, p.version, p.alcance, u.usuario " +
                         " FROM Proyectos p JOIN usuarios u ON p.id_responsable = u.id_usuario WHERE p.borrado=0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoBugs.Add(MappingProyecto(row));
            }

            return listadoBugs;
        }

        public Proyecto GetProyecto(string idProyecto)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String consultaSql = string.Concat(" SELECT p.id_proyecto, p.id_producto, p.descripcion, p.version, p.alcance, u.usuario ",
                                                " FROM Proyectos p JOIN usuarios u ON p.id_responsable = u.id_usuario" +
                                                " WHERE p.borrado=0 and p.id_proyecto =  '", idProyecto, "'");

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingProyecto(resultado.Rows[0]);
            }

            return null;
        }

        public IList<Proyecto> recuperarProyectosFiltro(string producto, string descripcion, string version, string alcance, string responsable)
        {
            List<Proyecto> listadoProyectos = new List<Proyecto>();

            var SQLquery = "SELECT p.id_proyecto, p.id_producto, p.descripcion, p.version, p.alcance, u.usuario" +
                            " FROM Proyectos p JOIN usuarios u ON p.id_responsable = u.id_usuario" +
                            " WHERE p.borrado=0";

            if (descripcion != "")
                SQLquery += " AND p.descripcion LIKE '%" + descripcion + "%'";
            if (producto != "-1")
                SQLquery += " AND p.id_producto=" + producto;
            if (responsable != "-1")
                SQLquery += " AND p.id_responsable=" + responsable;
            if (alcance != "")
                SQLquery += " AND p.alcance LIKE '%" + alcance + "%'";
            if (version != "")
                SQLquery += " AND p.version LIKE '%" + version + "%'";

            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);

            foreach (DataRow row in tabla.Rows)
                listadoProyectos.Add(MappingProyecto(row));

            return listadoProyectos;
        }

        public DataTable recuperarProyectosPorResponsables(DateTime desde, DateTime hasta)
        {
            string consultaSQL = "SELECT u.usuario as id_responsable, p.id_proyecto " +
                                 "FROM proyectos p JOIN usuarios u on (p.id_responsable = u.id_usuario) " +
                                 "WHERE p.borrado = 0 " +
                                 "AND p.fecha_alta BETWEEN CONVERT(datetime,'" + desde.ToString("dd/MM/yyyy") + "',103) " +
                                                     "AND  CONVERT(datetime,'" + hasta.ToString("dd/MM/yyyy") + "',103) ";

            return DataManager.GetInstance().ConsultaSQL(consultaSQL);
        }

        public DataTable recuperarProyectos(string descripcion, string producto, string responsable, string alcance, string version, DateTime fechaDesde, DateTime fechaHasta)
        {
            var SQLquery = "SELECT id_proyecto, pr.nombre \"id_producto\", descripcion, version, alcance, u.usuario \"id_responsable\" " +
                            "FROM Proyectos p   JOIN Usuarios u ON p.id_responsable = u.id_usuario " +
                            "                   JOIN Productos pr ON p.id_producto = pr.id_producto " +
                            "WHERE p.fecha_alta BETWEEN CONVERT(datetime,'" + fechaDesde.ToString("dd/MM/yyyy") + "',103) " +
                                                                 "AND  CONVERT(datetime,'" + fechaHasta.ToString("dd/MM/yyyy") + "',103) AND p.borrado=0";

            if (descripcion != "")
                SQLquery += " AND p.descripcion='" + descripcion + "'";
            if (producto != "-1")
                SQLquery += " AND p.id_producto=" + producto;
            if (responsable != "-1")
                SQLquery += " AND p.id_responsable=" + responsable;
            if (alcance != "")
                SQLquery += " AND p.alcance='" + alcance + "'";
            if (version != "")
                SQLquery += " AND p.version='" + version + "'";

            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);
            return tabla;
        }

        private Proyecto MappingProyecto(DataRow row)
        {
            Proyecto oProyecto = new Proyecto
            {
                Id_proyecto = Convert.ToInt32(row["id_proyecto"].ToString()),
                Descripcion = row["descripcion"].ToString(),
                Version = row["version"].ToString(),
                Alcance = row["alcance"].ToString(),
                Responsable = oUsuario.GetUser(row["usuario"].ToString()),
                Producto = oProducto.GetProducto(row["id_producto"].ToString())
            };

            return oProyecto;
        }

        public void crearProyecto(Proyecto proyecto)
        {
            string SQLInsert = " INSERT INTO Proyectos(id_producto, descripcion, version, alcance, id_responsable, borrado) " +
                               "VALUES (" + proyecto.Producto.Id_producto + ", '" + proyecto.Descripcion + "', '"
                                            + proyecto.Version + "','" + proyecto.Alcance + "'," + proyecto.Responsable.IdUsuario + ", 0) ";



            DataManager.GetInstance().EjecutarSQL(SQLInsert);
        }

        public void actualizarProyecto(Proyecto proyecto)
        {
            string SQLUpdate = "UPDATE proyectos set id_producto= " + proyecto.Producto.Id_producto + ", " +
                                                     "descripcion= '" + proyecto.Descripcion + "', " +
                                                     "version= '" + proyecto.Version + "', " +
                                                     "alcance= '" + proyecto.Alcance + "', " +
                                                     "id_responsable= " + proyecto.Responsable.IdUsuario +
                                                     " WHERE id_proyecto= " + proyecto.Id_proyecto;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);
        }

        public void eliminarProyecto(Proyecto proyecto)
        {
            string SQLUpdate = "UPDATE proyectos set borrado = 1 WHERE id_proyecto = " + proyecto.Id_proyecto;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);
        }

        public DataTable recuperarProyectosFacturadosEstadistica(DateTime desde, DateTime hasta)
        {
            string consultaSQL = "SELECT p.descripcion as id_proyecto, (f.cantidad * f.precio) as cantidad, u.usuario as id_producto  " +
                                 "FROM facturasDetalle f JOIN proyectos p on (f.id_proyecto = p.id_proyecto) " +
                                                        "JOIN usuarios u on (p.id_responsable = u.id_usuario) " +
                                                        "JOIN facturas fa on (fa.id_factura = f.id_factura) " +
                                 "WHERE f.borrado = 0 " +
                                 "AND fa.fecha BETWEEN CONVERT(datetime,'" + desde.ToString("dd/MM/yyyy") + "',103) " +
                                                 "AND  CONVERT(datetime,'" + hasta.ToString("dd/MM/yyyy") + "',103) ";

            return DataManager.GetInstance().ConsultaSQL(consultaSQL);
        }
    }
}
