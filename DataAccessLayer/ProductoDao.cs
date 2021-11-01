using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComputerTech.DataAccessLayer
{
    class ProductoDao
    {
        public IList<Producto> GetAll()
        {
            List<Producto> listadoProductos = new List<Producto>();
            var strSql = "SELECT id_producto, nombre from Productos where borrado=0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoProductos.Add(MappingProducto(row));
            }

            return listadoProductos;
        }

        internal void actualizarProducto(Producto producto)
        {
            string SQLUpdate = "UPDATE productos set nombre = '" + producto.Nombre + "'" +
                                                     " WHERE id_producto= " + producto.Id_producto;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);

        }

        public void eliminarProducto(Producto producto)
        {
            string SQLUpdate = "UPDATE productos set borrado = 1 WHERE id_producto = " + producto.Id_producto;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);
        }

        public IList<Producto> recuperarProductoNombre(string nomProducto)
        {
            List<Producto> listadoProducto = new List<Producto>();

            var strSql = " SELECT id_producto, nombre" +
                         " FROM productos WHERE borrado = 0 AND nombre LIKE '%" + nomProducto + "%'";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoProducto.Add(MappingProducto(row));
            }

            return listadoProducto;
        }

        public DataTable recuperarProductosEstadisticasImporte(DateTime fechaDesde, DateTime fechaHasta)
        {
            string consultaSQL = "SELECT p.nombre as id_producto, sum(cantidad * precio) as cantidad " +
            "FROM Productos p, FacturasDetalle fd " +
            "WHERE p.id_producto = fd.id_producto " +
            "AND fd.id_producto is not null " +
            "AND p.fecha_alta BETWEEN CONVERT(datetime,'" + fechaDesde.ToString("dd/MM/yyyy") + "',103) " +
                                            "AND  CONVERT(datetime,'" + fechaHasta.ToString("dd/MM/yyyy") + "',103) " +
            "GROUP BY p.nombre";

            return DataManager.GetInstance().ConsultaSQL(consultaSQL);
        }

        public DataTable recuperarProductosEstadisticas(DateTime fechaDesde, DateTime fechaHasta)
        {
            string consultaSQL = "SELECT p.nombre as id_producto, sum(cantidad) as cantidad " +
            "FROM Productos p, FacturasDetalle fd " +
            "WHERE p.id_producto = fd.id_producto " +
            "AND fd.id_producto is not null " +
            "AND p.fecha_alta BETWEEN CONVERT(datetime,'" + fechaDesde.ToString("dd/MM/yyyy") + "',103) " +
                                            "AND  CONVERT(datetime,'" + fechaHasta.ToString("dd/MM/yyyy") + "',103) " +
            "GROUP BY p.nombre ";

            return DataManager.GetInstance().ConsultaSQL(consultaSQL);
        }

        public void crearProducto(Producto producto)
        {
            string SQLInsert = " INSERT INTO Productos(nombre, borrado) " +
                               "VALUES ('" + producto.Nombre + "', 0) ";



            DataManager.GetInstance().EjecutarSQL(SQLInsert);
        }

        public Producto GetProducto(string idProducto)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String consultaSql = string.Concat(" SELECT id_producto, nombre ",
                                                "   FROM Productos",
                                                "  WHERE borrado=0 and id_producto =  '", idProducto, "'");

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingProducto(resultado.Rows[0]);
            }

            return null;
        }

        private Producto MappingProducto(DataRow row)
        {
            Producto oProducto = new Producto
            {
                Id_producto = Convert.ToInt32(row["id_producto"].ToString()),
                Nombre = row["nombre"].ToString()
            };

            return oProducto;
        }

        public DataTable recuperarProductos(DateTime fechaDesde, DateTime FechaHasta, string nombre)
        {
            var SQLquery = "SELECT * FROM Productos WHERE fecha_alta BETWEEN CONVERT(datetime,'" + fechaDesde.ToString("dd/MM/yyyy") + "',103) " +
                                                                 "AND  CONVERT(datetime,'" + FechaHasta.ToString("dd/MM/yyyy") + "',103) " +
                                              " AND borrado=0 ";
            if (nombre != "-1")
                SQLquery += "AND nombre LIKE '%" + nombre + "%'";

            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);
            return tabla;
        }
    }
}
