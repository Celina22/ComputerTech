using ComputerTech.DataAccessLayer;
using ComputerTech.Entities;
using System.Collections.Generic;


namespace ComputerTech.BusinessLayer
{
    class DetalleFacturaService
    {
        private DetalleFacturaDao oDetalleFacturaDao = new DetalleFacturaDao();

        public IList<DetalleFactura> recuperarTodos(string idFactura)
        {
            return oDetalleFacturaDao.GetAll(idFactura);
        }
    }

}
