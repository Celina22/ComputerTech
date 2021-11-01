using ComputerTech.DataAccessLayer;
using ComputerTech.Entities;
using System.Collections.Generic;

namespace ComputerTech.BusinessLayer
{
    public class UsuarioService
    {
        private UsuarioDao oUsuarioDao;
        public UsuarioService()
        {
            oUsuarioDao = new UsuarioDao();
        }
        public IList<Usuario> recuperarTodos()
        {
            return oUsuarioDao.GetAll();
        }

        public Usuario ValidarUsuario(string usuario, string password)
        {
            Usuario usr = oUsuarioDao.GetUser(usuario);

            if (usr != null)
            {
                if (usr.Password != null && usr.Password.Equals(password))
                {
                    return usr;
                }
            }
            return null;
        }

        public Usuario recuperarUsuario(string nombreUsuario)
        {
            return oUsuarioDao.GetUser(nombreUsuario);
        }

        public Usuario recuperarUsuarioID(string idUsuario)
        {
            return oUsuarioDao.GetUserID(idUsuario);
        }

        public void eliminarUsuario(Usuario usuario)
        {
            oUsuarioDao.eliminarUsuario(usuario);
        }

        public void crearUsuario(Usuario usuario)
        {
            oUsuarioDao.crearUsuario(usuario);
        }

        public void actualizarUsuario(Usuario usuario)
        {
            oUsuarioDao.actualizarUsuario(usuario);
        }

        public IList<Usuario> recuperarUsuarioConsulta(string usuario, string mail, string estado, int cboPerfilSeleccion)
        {
            return oUsuarioDao.recuperarUsuarioConsulta(usuario, mail, estado, cboPerfilSeleccion);
        }
    }
}
