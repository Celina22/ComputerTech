namespace ComputerTech.Entities
{
    class Contacto
    {
        private int id_contacto;
        private string nombre;
        private string apellido;
        private string email;
        private long telefono;

        public int Id_contacto { get => id_contacto; set => id_contacto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Email { get => email; set => email = value; }
        public long Telefono { get => telefono; set => telefono = value; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
