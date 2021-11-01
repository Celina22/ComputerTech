using ComputerTech.DataAccessLayer;
using ComputerTech.Entities;
using System;
using System.Data;

namespace ComputerTech.BusinessLayer
{
    class FacturaService
    {
        FacturaDao oFacturaDao = new FacturaDao();

        public string CrearFactura(Factura oFactura)
        {
            return oFacturaDao.CrearFactura(oFactura);
        }

        public Factura GetFactura(string numeroFactura)
        {
            return oFacturaDao.getFactura(numeroFactura);
        }

        public DataTable recuperarFacturas(DateTime fechaDesde, DateTime fechaHasta, string cliente, string monto)
        {
            return oFacturaDao.recuperarFacturas(fechaDesde, fechaHasta, cliente, monto);
        }

        public DataTable recuperarTodas(DateTime fechaDesde, DateTime fechaHasta)
        {
            return oFacturaDao.recuperarTodas(fechaDesde, fechaHasta);
        }

        public DataTable recuperarTodasPorMes(DateTime fechaDesde, DateTime fechaHasta)
        {
            return oFacturaDao.recuperarTodasPorMes(fechaDesde, fechaHasta);
        }

        public DataTable recuperarTodasTotal(DateTime fechaDesde, DateTime fechaHasta)
        {
            return oFacturaDao.recuperarTodasTotal(fechaDesde, fechaHasta);
        }
    }
}
