namespace ComputerTech.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public Perfil Perfil { get; set; }

        public override string ToString()
        {
            return NombreUsuario;
        }
    }
}
