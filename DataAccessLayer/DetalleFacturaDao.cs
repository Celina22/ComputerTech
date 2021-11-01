using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;
namespace ComputerTech.DataAccessLayer
{
    class DetalleFacturaDao
    {
        ProductoDao oProducto = new ProductoDao();
        ProyectoDao oProyecto = new ProyectoDao();
        public IList<DetalleFactura> GetAll()
        {
            List<DetalleFactura> listadoDetalleFactura = new List<DetalleFactura>();

            var strSql = " SELECT id_detalle_factura, numero_orden, id_producto, id_proyecto, precio, cantidad" +
                         " FROM FacturasDetalle WHERE borrado=0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoDetalleFactura.Add(MappingDetalleFactura(row));
            }

            return listadoDetalleFactura;
        }

        public IList<DetalleFactura> GetAll(string idFactura)
        {
            List<DetalleFactura> listadoDetalleFactura = new List<DetalleFactura>();

            var strSql = " SELECT id_detalle_factura, numero_orden, id_producto, id_proyecto, precio, cantidad" +
                         " FROM FacturasDetalle WHERE borrado=0 AND id_factura = " + idFactura;

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoDetalleFactura.Add(MappingDetalleFactura(row));
            }

            return listadoDetalleFactura;
        }

        private DetalleFactura MappingDetalleFactura(DataRow row)
        {
            DetalleFactura oDetalleFactura;
            if (!DBNull.Value.Equals(row["id_producto"]))
            {
                oDetalleFactura = new DetalleFactura
                {
                    Id_detalle_factura = Convert.ToInt32(row["id_detalle_factura"].ToString()),
                    Numero_orden = Convert.ToInt32(row["numero_orden"].ToString()),
                    Producto = oProducto.GetProducto(row["id_producto"].ToString()),
                    //Proyecto = oProyecto.GetProyecto(row["id_cliente"].ToString()),
                    Precio = Convert.ToDouble(row["precio"].ToString()),
                    Cantidad = Convert.ToInt32(row["cantidad"].ToString())
                };
            }
            else
            {
                oDetalleFactura = new DetalleFactura
                {
                    Id_detalle_factura = Convert.ToInt32(row["id_detalle_factura"].ToString()),
                    Numero_orden = Convert.ToInt32(row["numero_orden"].ToString()),
                    //Producto = oProducto.GetProducto(row["id_cliente"].ToString()),
                    Proyecto = oProyecto.GetProyecto(row["id_proyecto"].ToString()),
                    Precio = Convert.ToDouble(row["precio"].ToString()),
                    Cantidad = Convert.ToInt32(row["cantidad"].ToString())
                };
            }

            return oDetalleFactura;
        }

        public void insertarDetalles(IList<DetalleFactura> detalles)
        {
            string id_factura = DataManager.GetInstance().ConsultaSQLScalar("SELECT @@IDENTITY").ToString();
            foreach (DetalleFactura detalle in detalles)
            {
                string SQLInject;
                if (detalle.Producto == null)
                {
                    SQLInject = " INSERT INTO FacturasDetalle(id_factura, numero_orden, id_producto, id_proyecto, precio,cantidad, borrado) " +
                                        "VALUES (" + id_factura + ", " + detalle.Numero_orden + ", "
                                          + "NULL" + "," + detalle.Proyecto.Id_proyecto + "," + detalle.Precio + "," + detalle.Cantidad + ", 0) ";
                }
                else
                {
                    SQLInject = " INSERT INTO FacturasDetalle(id_factura, numero_orden, id_producto, id_proyecto, precio,cantidad, borrado) " +
                                        "VALUES (" + id_factura + ", " + detalle.Numero_orden + ", "
                                          + detalle.Producto.Id_producto + "," + "NULL" + "," + detalle.Precio + "," + detalle.Cantidad + ", 0) ";
                }

                DataManager.GetInstance().EjecutarSQL(SQLInject);
            }
        }
    }
}
