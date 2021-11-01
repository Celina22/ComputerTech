using ComputerTech.DataAccessLayer;
using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComputerTech.BusinessLayer
{
    class ProyectoService
    {
        private ProyectoDao oProyectoDao;
        public ProyectoService()
        {
            oProyectoDao = new ProyectoDao();
        }

        public IList<Proyecto> recuperarTodos()
        {
            return oProyectoDao.GetAll();
        }
        public Proyecto recuperarProyecto(string idProyecto)
        {
            return oProyectoDao.GetProyecto(idProyecto);
        }

        public void crearProyecto(Proyecto proyecto)
        {
            oProyectoDao.crearProyecto(proyecto);
        }
        public void actualizarProyecto(Proyecto proyecto)
        {
            oProyectoDao.actualizarProyecto(proyecto);
        }
        public void eliminarProyecto(Proyecto proyecto)
        {
            oProyectoDao.eliminarProyecto(proyecto);
        }

        public DataTable recuperarProyectos(string descripcion, string producto, string responsable, string alcance, string version, DateTime fechaDesde, DateTime fechaHasta)
        {
            return oProyectoDao.recuperarProyectos(descripcion, producto, responsable, alcance, version, fechaDesde, fechaHasta);
        }

        public DataTable recuperarProyectosPorResponsables(DateTime desde, DateTime hasta)
        {
            return oProyectoDao.recuperarProyectosPorResponsables(desde, hasta);
        }

        public DataTable recuperarProyectosFacturadosEstadistica(DateTime desde, DateTime hasta)
        {
            return oProyectoDao.recuperarProyectosFacturadosEstadistica(desde, hasta);
        }

        public IList<Proyecto> recuperarProyectosFiltro(string producto, string descripcion, string version, string alcance, string responsable)
        {
            return oProyectoDao.recuperarProyectosFiltro(producto, descripcion, version, alcance, responsable);
        }
    }
}
