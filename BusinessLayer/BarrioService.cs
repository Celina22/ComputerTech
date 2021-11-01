using ComputerTech.DataAccessLayer;
using ComputerTech.Entities;
using System.Collections.Generic;

namespace ComputerTech.BusinessLayer
{
    class BarrioService
    {
        private BarrioDao oBarrioDao;
        public BarrioService()
        {
            oBarrioDao = new BarrioDao();
        }

        public IList<Barrio> recuperarTodos()
        {
            return oBarrioDao.GetAll();
        }

        public Barrio recuperarBarrio(string idBarrio)
        {
            return oBarrioDao.GetBarrio(idBarrio);
        }

        public void crearBarrio(Barrio barrio)
        {
            oBarrioDao.crearBarrio(barrio);
        }

        public void actualizarBarrio(Barrio barrio)
        {
            oBarrioDao.actualizarBarrio(barrio);
        }

        public void eliminarBarrio(Barrio barrio)
        {
            oBarrioDao.eliminarBarrio(barrio);
        }

        public IList<Barrio> recuperarBarrioNombre(string barrio)
        {
            return oBarrioDao.recuperarBarrioNombre(barrio);
        }
    }
}
