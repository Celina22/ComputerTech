using ComputerTech.DataAccessLayer;
using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComputerTech.BusinessLayer
{
    class ProductoService
    {
        private ProductoDao oProductoDao = new ProductoDao();

        public IList<Producto> recuperarTodos()
        {
            return oProductoDao.GetAll();
        }

        public Producto recuperarProducto(string idProducto)
        {
            return oProductoDao.GetProducto(idProducto);
        }

        public void crearProducto(Producto oProducto)
        {
            oProductoDao.crearProducto(oProducto);
        }
        public void actualizarProducto(Producto oProducto)
        {
            oProductoDao.actualizarProducto(oProducto);
        }
        public void eliminarProducto(Producto oProducto)
        {
            oProductoDao.eliminarProducto(oProducto);
        }

        public DataTable recuperarProductos(DateTime fechaDesde, DateTime fechaHasta, string nombre)
        {
            return oProductoDao.recuperarProductos(fechaDesde, fechaHasta, nombre);
        }

        public DataTable recuperarProductosEstadisticas(DateTime fechaDesde, DateTime fechaHasta)
        {
            return oProductoDao.recuperarProductosEstadisticas(fechaDesde, fechaHasta);
        }

        public DataTable recuperarProcutosEstadisticasImporte(DateTime fechaDesde, DateTime fechaHasta)
        {
            return oProductoDao.recuperarProductosEstadisticasImporte(fechaDesde, fechaHasta);
        }

        internal IList<Producto> recuperarProductoNombre(string nomProducto)
        {
            return oProductoDao.recuperarProductoNombre(nomProducto);
        }
    }
}
