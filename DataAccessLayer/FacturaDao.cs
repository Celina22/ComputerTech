using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComputerTech.DataAccessLayer
{
    class FacturaDao
    {
        ClienteDao oCliente = new ClienteDao();
        UsuarioDao oUsuario = new UsuarioDao();
        DetalleFacturaDao oDetalleFacturaDao = new DetalleFacturaDao();
        public IList<Factura> GetAll()
        {
            List<Factura> listadoFactura = new List<Factura>();

            var strSql = " SELECT id_factura, numero_factura, id_cliente, fecha, id_usuario_creador, total" +
                         " FROM Facturas WHERE borrado=0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoFactura.Add(MappingFactura(row));
            }

            return listadoFactura;
        }

        private Factura MappingFactura(DataRow row)
        {
            Factura oFactura = new Factura
            {
                Id_factura = Convert.ToInt32(row["id_factura"].ToString()),
                Detalles = oDetalleFacturaDao.GetAll(row["id_factura"].ToString()),
                Numero_factura = row["numero_factura"].ToString(),
                Cliente = oCliente.GetCliente(row["id_cliente"].ToString()),
                Fecha = Convert.ToDateTime(row["fecha"].ToString()),
                Usuario_creador = oUsuario.GetUserId(row["id_usuario_creador"].ToString()),
                Total = Convert.ToSingle(row["total"].ToString())
            };

            return oFactura;
        }

        public string insertarFactura(Factura oFactura)
        {
            string SQLinsert = "INSERT INTO Facturas(numero_factura, id_cliente, fecha, id_usuario_creador,total, borrado) " +
                               "VALUES ('" + 0 + "', " + oFactura.Cliente.Id_cliente + ", Convert(date,'"
                                            + oFactura.Fecha.ToShortDateString() + "',103) ," + oFactura.Usuario_creador.IdUsuario + "," +
                                            oFactura.Total + ", 0) ";
            DataManager.GetInstance().EjecutarSQL(SQLinsert);
            int identity = Convert.ToInt32(DataManager.GetInstance().ConsultaSQLScalar("SELECT @@IDENTITY"));
            string numeroFactura = "001-" + (identity).ToString().PadLeft(6, '0');
            DataManager.GetInstance().EjecutarSQL("UPDATE Facturas SET numero_factura='" + numeroFactura + "' WHERE id_factura=" + identity);
            return numeroFactura;
        }

        public string CrearFactura(Factura oFactura)
        {
            string idFactura;
            try
            {
                DataManager.GetInstance().BeginTransaction();
                idFactura = insertarFactura(oFactura);
                oDetalleFacturaDao.insertarDetalles(oFactura.Detalles);
                DataManager.GetInstance().Commit();
            }
            catch (Exception ex)
            {
                DataManager.GetInstance().Rollback();
                idFactura = "";
                throw ex;
            }
            finally
            {
                DataManager.GetInstance().Close();
            }
            return idFactura;
        }

        public Factura getFactura(string numeroFactura)
        {
            String consultaSql = string.Concat(" SELECT id_factura, numero_factura, id_cliente, fecha, id_usuario_creador, total",
                                                "   FROM Facturas",
                                                "  WHERE borrado=0 and numero_factura = '", numeroFactura, "'");

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingFactura(resultado.Rows[0]);
            }

            return null;
        }

        public DataTable recuperarFacturas(DateTime fechaDesde, DateTime FechaHasta, string cliente, string monto)
        {
            var SQLquery = "SELECT F.id_factura,F.numero_factura, C.razon_social AS id_cliente,F.fecha,U.usuario AS id_usuario_creador,F.total, F.borrado" +
                " FROM Facturas F " +
                "JOIN Clientes C ON (F.id_cliente = C.id_cliente) " +
                "JOIN Usuarios U ON (F.id_usuario_creador = U.id_usuario) " +
                "WHERE F.fecha BETWEEN CONVERT(datetime,'" + fechaDesde.ToString("dd/MM/yyyy") + "',103) " +
                                                                      "AND  CONVERT(datetime,'" + FechaHasta.ToString("dd/MM/yyyy") + "',103) " +
                                                                     " AND F.borrado=0 ";

            if (cliente != "-1")
                SQLquery += "AND F.id_cliente = " + cliente;
            if (monto != "-1")
                SQLquery += " AND F.total >= " + monto;

            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);
            return tabla;
        }

        public DataTable recuperarTodas(DateTime fechaDesde, DateTime fechaHasta)
        {
            //var SQLquery = "SELECT * FROM facturas WHERE borrado=0";

            var SQLquery = "SELECT F.id_factura,F.numero_factura, C.razon_social AS id_cliente,F.fecha,U.usuario AS id_usuario_creador,F.total, F.borrado" +
                " FROM Facturas F " +
                "JOIN Clientes C ON (F.id_cliente = C.id_cliente) " +
                "JOIN Usuarios U ON (F.id_usuario_creador = U.id_usuario) " +
                "WHERE F.borrado=0 AND F.fecha BETWEEN CONVERT(datetime,'" + fechaDesde.ToString("dd/MM/yyyy") + "',103) " +
                                            "AND  CONVERT(datetime,'" + fechaHasta.ToString("dd/MM/yyyy") + "',103) ";

            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);
            return tabla;
        }

        public DataTable recuperarTodasPorMes(DateTime fechaDesde, DateTime fechaHasta)
        {

            var SQLquery = "SELECT MONTH(F.fecha) AS fecha FROM facturas F WHERE YEAR(F.fecha) = YEAR(GETDATE()) AND F.fecha BETWEEN CONVERT(datetime,'" + fechaDesde.ToString("dd/MM/yyyy") + "',103) " +
                                            "AND  CONVERT(datetime,'" + fechaHasta.ToString("dd/MM/yyyy") + "',103) AND F.borrado=0";
            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);
            return tabla;
        }

        public DataTable recuperarTodasTotal(DateTime fechaDesde, DateTime fechaHasta)
        {
            //var SQLquery = "SELECT * FROM facturas WHERE borrado=0";

            var SQLquery = "SELECT SUM(F.total) AS total, MONTH(F.fecha) AS fecha FROM facturas F WHERE F.fecha BETWEEN CONVERT(datetime,'" + fechaDesde.ToString("dd/MM/yyyy") + "',103) " +
                                            "AND  CONVERT(datetime,'" + fechaHasta.ToString("dd/MM/yyyy") + "',103) AND F.borrado=0 " +
                                                "GROUP BY MONTH(F.fecha)";
            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);
            return tabla;
        }
    }
}
