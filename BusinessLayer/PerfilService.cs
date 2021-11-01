using ComputerTech.DataAccessLayer;
using ComputerTech.Entities;
using System.Collections.Generic;

namespace ComputerTech.BusinessLayer
{
    class PerfilService
    {
        private PerfilDao oPerfilDao;

        public PerfilService()
        {
            oPerfilDao = new PerfilDao();
        }

        public IList<Perfil> recuperarTodos()
        {
            return oPerfilDao.GetAll();
        }
        public Perfil recuperarPerfil(string idPerfil)
        {
            return oPerfilDao.GetPerfil(idPerfil);
        }
    }
}
