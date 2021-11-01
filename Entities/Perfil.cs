namespace ComputerTech.Entities
{
    public class Perfil
    {
        public int Id_Perfil { get; set; }
        public string Nombre { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
