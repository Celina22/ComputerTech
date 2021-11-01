using System;

namespace ComputerTech.Entities
{
    class Cliente
    {
        private int id_cliente;
        private long cuit;
        private string razon_social;
        private string calle;
        private int numero;
        private DateTime fecha_alta;
        private Barrio barrio;
        private Contacto contacto;

        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public long Cuit { get => cuit; set => cuit = value; }
        public string Razon_social { get => razon_social; set => razon_social = value; }
        public string Calle { get => calle; set => calle = value; }
        public int Numero { get => numero; set => numero = value; }
        public DateTime Fecha_alta { get => fecha_alta; set => fecha_alta = value; }
        internal Barrio Barrio { get => barrio; set => barrio = value; }
        internal Contacto Contacto { get => contacto; set => contacto = value; }

        public override string ToString()
        {
            return Razon_social;
        }
    }
}
