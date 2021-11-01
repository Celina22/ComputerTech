using ComputerTech.DataAccessLayer;
using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComputerTech.BusinessLayer
{
    class ClienteService
    {
        private ClienteDao oClienteDao;
        public ClienteService()
        {
            oClienteDao = new ClienteDao();
        }

        public Cliente recuperarCliente(string idCliente)
        {
            return oClienteDao.GetCliente(idCliente);
        }
        public IList<Cliente> recuperarTodos()
        {
            return oClienteDao.GetAll();
        }

        public void crearCliente(Cliente cliente)
        {
            oClienteDao.crearCliente(cliente);
        }
        public void actualizarCliente(Cliente cliente)
        {
            oClienteDao.actualizarCliente(cliente);
        }
        public void eliminarCliente(Cliente cliente)
        {
            oClienteDao.eliminarCliente(cliente);
        }

        public DataTable recuperarClientes()
        {
            return oClienteDao.recuperarCLientes();
        }

        public DataTable recuperar5ClientesMasFacturados(DateTime fechaDesde, DateTime fechaHasta)
        {
            return oClienteDao.recuperar5ClientesMasFacturados(fechaDesde, fechaHasta);
        }

        public DataTable recuperarClientes(DateTime fechaDesde, DateTime fechaHasta, string barrio)
        {
            return oClienteDao.recuperarCLientes(fechaDesde, fechaHasta, barrio);
        }

        public DataTable recuperarClientes(DateTime fechaDesde, DateTime fechaHasta)
        {
            return oClienteDao.recuperarCLientes(fechaDesde, fechaHasta);
        }

        public IList<Cliente> recuperarClientesFiltro(string cuit, string razonSocial, string contacto, string barrio, string calle,
            string numero, DateTime fechaAlta)
        {
            return oClienteDao.recuperarClientesFiltro(cuit, razonSocial, contacto, barrio, calle, numero, fechaAlta);
        }
    }
}
