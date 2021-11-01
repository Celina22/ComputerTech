namespace ComputerTech.Entities
{
    class Barrio
    {
        private int id_barrio;
        private string nombre;

        public int Id_barrio { get => id_barrio; set => id_barrio = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public override string ToString()
        {
            return Nombre;
        }
    }

}
