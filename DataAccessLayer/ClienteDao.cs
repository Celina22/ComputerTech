using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComputerTech.DataAccessLayer
{
    class ClienteDao
    {
        BarrioDao oBarrioDao = new BarrioDao();
        ContactoDao oContactoDao = new ContactoDao();
        public IList<Cliente> GetAll()
        {
            List<Cliente> listadoClientes = new List<Cliente>();

            var SQLquery = "SELECT * FROM Clientes WHERE borrado=0";
            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);

            foreach (DataRow row in tabla.Rows)
                listadoClientes.Add(MappingCliente(row));

            return listadoClientes;
        }

        public IList<Cliente> recuperarClientesFiltro(string cuit, string razonSocial, string contacto, string barrio, string calle,
            string numero, DateTime fechaAlta)
        {
            List<Cliente> listadoClientes = new List<Cliente>();

            var SQLquery = "SELECT c.id_cliente, c.cuit, c.razon_social, c.calle, c.numero, CONVERT(varchar,c.fecha_alta,103) as fecha_alta, c.id_barrio, c.id_contacto " +
                           "FROM Clientes c LEFT JOIN Barrios b ON (c.id_barrio = b.id_barrio) LEFT JOIN Contactos co ON (co.id_contacto = c.id_contacto)" +
                           "WHERE c.fecha_alta > CONVERT(datetime,'" + fechaAlta.ToString("dd/MM/yyyy") + "',103) " +
                                            "AND c.borrado=0";
            if (cuit.Length > 0)
                SQLquery += " AND c.cuit LIKE '%" + cuit + "%'";
            if (razonSocial.Length > 0)
                SQLquery += " AND c.razon_social LIKE '%" + razonSocial + "%'";
            if (contacto != "-1")
                SQLquery += " AND c.id_contacto = " + contacto;
            if (barrio != "-1")
                SQLquery += " AND c.id_barrio = " + barrio;
            if (calle.Length > 0)
                SQLquery += " AND c.calle LIKE '%" + calle + "%'";
            if (numero.Length > 0)
                SQLquery += " AND c.numero LIKE '%" + numero + "%'";


            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);

            foreach (DataRow row in tabla.Rows)
                listadoClientes.Add(MappingCliente(row));

            return listadoClientes;
        }

        public DataTable recuperarCLientes()
        {
            var SQLquery = "SELECT * FROM Clientes WHERE borrado=0";
            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);
            return tabla;
        }

        public DataTable recuperarCLientes(DateTime fechaDesde, DateTime fechaHasta)
        {
            var SQLquery = "SELECT c.id_cliente, c.cuit, c.razon_social, c.calle, c.numero, CONVERT(varchar,c.fecha_alta,103) as fecha_alta, b.nombre as id_barrio, CONCAT(co.nombre,' ' ,co.apellido) as id_contacto " +
                           "FROM Clientes c LEFT JOIN Barrios b ON (c.id_barrio = b.id_barrio) LEFT JOIN Contactos co ON (co.id_contacto = c.id_contacto)" +
                           "WHERE c.fecha_alta BETWEEN CONVERT(datetime,'" + fechaDesde.ToString("dd/MM/yyyy") + "',103) " +
                                            "AND  CONVERT(datetime,'" + fechaHasta.ToString("dd/MM/yyyy") + "',103) " +
                                            "AND c.borrado=0 ";

            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);
            return tabla;
        }

        public DataTable recuperar5ClientesMasFacturados(DateTime fechaDesde, DateTime fechaHasta)
        {
            var SQLquery = "SELECT TOP(5) C.razon_social as id_cliente, COUNT(F.id_factura) as id_factura" +
                "           FROM Facturas F JOIN Clientes C ON F.id_cliente = C.id_cliente " +
                "           WHERE C.fecha_alta BETWEEN  CONVERT(datetime, '" + fechaDesde.ToString("dd/MM/yyyy") + "', 103) " +
                "                                       AND CONVERT(datetime,'" + fechaHasta.ToString("dd/MM/yyyy") + "',103) " +
                                  "AND C.borrado = 0 " +
                "           GROUP BY C.id_cliente, C.razon_social " +
                "           ORDER BY 2 DESC";

            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);
            return tabla;
        }

        public DataTable recuperarCLientes(DateTime fechaDesde, DateTime FechaHasta, string barrio)
        {
            var SQLquery = "SELECT c.id_cliente, c.cuit, c.razon_social, c.calle, c.numero, CONVERT(varchar,c.fecha_alta,103) as fecha_alta, b.nombre as id_barrio, CONCAT(co.nombre,' ' ,co.apellido) as id_contacto " +
                           "FROM Clientes c LEFT JOIN Barrios b ON (c.id_barrio = b.id_barrio) LEFT JOIN Contactos co ON (co.id_contacto = c.id_contacto)" +
                           "WHERE c.fecha_alta BETWEEN CONVERT(datetime,'" + fechaDesde.ToString("dd/MM/yyyy") + "',103) " +
                                            "AND  CONVERT(datetime,'" + FechaHasta.ToString("dd/MM/yyyy") + "',103) " +
                                            "AND c.borrado=0 ";

            if (barrio != "-1")
                SQLquery += "AND c.id_barrio = " + barrio;

            DataTable tabla = DataManager.GetInstance().ConsultaSQL(SQLquery);
            return tabla;
        }

        public Cliente GetCliente(string idCliente)
        {
            Cliente clienteObtenido;

            string consulta = "SELECT * FROM Clientes WHERE borrado=0 and id_cliente=" + idCliente;
            DataTable tabla = DataManager.GetInstance().ConsultaSQL(consulta);

            if (tabla.Rows.Count > 0)
            {
                clienteObtenido = MappingCliente(tabla.Rows[0]);
                return clienteObtenido;
            }
            return null;
        }

        public void actualizarCliente(Cliente cliente)
        {
            string SQLUpdate = "UPDATE Clientes SET cuit=" + cliente.Cuit + ", " +
                                                     "razon_social='" + cliente.Razon_social + "', " +
                                                     "calle='" + cliente.Calle + "', " +
                                                     "numero=" + cliente.Numero + ", " +
                                                     "fecha_alta=CONVERT(date,'" + cliente.Fecha_alta.ToShortDateString() + "',103), " +
                                                     "id_barrio=" + cliente.Barrio.Id_barrio + ", " +
                                                     "id_contacto=" + cliente.Contacto.Id_contacto + " " +
                                                     "WHERE id_cliente=" + cliente.Id_cliente;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);
        }
        public void eliminarCliente(Cliente cliente)
        {
            string SQLUpdate = "UPDATE Clientes SET borrado=1 WHERE id_cliente=" + cliente.Id_cliente;

            DataManager.GetInstance().EjecutarSQL(SQLUpdate);
        }
        //Revisar cómo se registra la fecha en la base de datos.
        public void crearCliente(Cliente cliente)
        {
            string SQLInsert = string.Concat("INSERT INTO Clientes(cuit, razon_social, borrado, calle, numero, fecha_alta, id_barrio, id_contacto) VALUES(",
                                                cliente.Cuit, ",'",
                                                cliente.Razon_social, "',",
                                                0, ",'",
                                                cliente.Calle, "',",
                                                cliente.Numero, ",CONVERT(date,'",
                                                cliente.Fecha_alta.ToShortDateString(), "',103),",
                                                cliente.Barrio.Id_barrio, ",",
                                                cliente.Contacto.Id_contacto, ")");

            DataManager.GetInstance().EjecutarSQL(SQLInsert);
        }
        private Cliente MappingCliente(DataRow row)
        {
            Cliente oCliente = new Cliente
            {
                Id_cliente = Convert.ToInt32(row["id_cliente"].ToString()),
                Cuit = Convert.ToInt64(row["cuit"].ToString()),
                Razon_social = row["razon_social"].ToString(),
                Calle = row["calle"].ToString(),
                Numero = Convert.ToInt32(row["numero"].ToString()),
                Fecha_alta = Convert.ToDateTime(row["fecha_alta"].ToString()),
                Barrio = oBarrioDao.GetBarrio(row["id_barrio"].ToString()),
                Contacto = oContactoDao.GetContacto(row["id_contacto"].ToString())
            };

            return oCliente;
        }
    }
}
