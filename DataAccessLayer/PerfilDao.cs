using ComputerTech.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ComputerTech.DataAccessLayer
{
    class PerfilDao
    {
        public IList<Perfil> GetAll()
        {
            List<Perfil> listadoPerfiles = new List<Perfil>();

            var strSql = "SELECT id_perfil, nombre FROM Perfiles WHERE borrado=0";

            var resultadoConsulta = DataManager.GetInstance().ConsultaSQL(strSql);

            foreach (DataRow row in resultadoConsulta.Rows)
            {
                listadoPerfiles.Add(MappingPerfil(row));
            }

            return listadoPerfiles;
        }

        private Perfil MappingPerfil(DataRow row)
        {
            Perfil oPerfil = new Perfil()
            {
                Id_Perfil = Convert.ToInt32(row["id_perfil"].ToString()),
                Nombre = row["nombre"].ToString(),
            };

            return oPerfil;
        }

        public Perfil GetPerfil(string idPerfil)
        {
            //Construimos la consulta sql para buscar el usuario en la base de datos.
            String consultaSql = string.Concat(" SELECT id_perfil, nombre ",
                                                "   FROM Perfiles",
                                                "  WHERE borrado=0 and id_perfil =  '", idPerfil, "'");

            //Usando el método GetDBHelper obtenemos la instancia unica de DBHelper (Patrón Singleton) y ejecutamos el método ConsultaSQL()
            var resultado = DataManager.GetInstance().ConsultaSQL(consultaSql);

            // Validamos que el resultado tenga al menos una fila.
            if (resultado.Rows.Count > 0)
            {
                return MappingPerfil(resultado.Rows[0]);
            }

            return null;
        }
    }
}

