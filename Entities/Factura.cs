using System;
using System.Collections.Generic;

namespace ComputerTech.Entities
{
    public class Factura
    {
        private int id_factura;
        private string numero_factura;
        private Cliente cliente;
        private DateTime fecha;
        private Usuario usuario_creador;
        private float total;
        private IList<DetalleFactura> detalles = new List<DetalleFactura>();

        public int Id_factura { get => id_factura; set => id_factura = value; }
        public string Numero_factura { get => numero_factura; set => numero_factura = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Usuario Usuario_creador { get => usuario_creador; set => usuario_creador = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public IList<DetalleFactura> Detalles { get => detalles; set => detalles = value; }
        public float Total { get => total; set => total = value; }
    }
}
