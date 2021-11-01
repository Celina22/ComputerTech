using ComputerTech.DataAccessLayer;
using ComputerTech.Entities;
using System.Collections.Generic;

namespace ComputerTech.BusinessLayer
{
    class ContactoService
    {
        private ContactoDao oContactoDao;
        public ContactoService()
        {
            oContactoDao = new ContactoDao();
        }

        public Contacto recuperarContacto(string idContacto)
        {
            return oContactoDao.GetContacto(idContacto);
        }
        public IList<Contacto> recuperarTodos()
        {
            return oContactoDao.GetAll();
        }

        public void crearContacto(Contacto contacto)
        {
            oContactoDao.crearContacto(contacto);
        }
        public void actualizarContacto(Contacto contacto)
        {
            oContactoDao.actualizarContacto(contacto);
        }
        public void eliminarContacto(Contacto contacto)
        {
            oContactoDao.eliminarContacto(contacto);
        }

        public IList<Contacto> recuperarContactoConsulta(string nombre, string apellido, string email, string telefono)
        {
            return oContactoDao.recuperarContactoConsulta(nombre, apellido, email, telefono);
        }
    }
}
