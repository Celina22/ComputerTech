namespace ComputerTech.Entities
{
    class DetalleFactura
    {
        private int id_detalle_factura;
        //private int id_factura;
        private int numero_orden;
        private int cantidad;
        private Producto producto;
        private Proyecto proyecto;
        private double precio;

        public int Id_detalle_factura { get => id_detalle_factura; set => id_detalle_factura = value; }
        public int Numero_orden { get => numero_orden; set => numero_orden = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        //public int Id_factura { get => id_factura; set => id_factura = value; }
        public Producto Producto { get => producto; set => producto = value; }
        public Proyecto Proyecto { get => proyecto; set => proyecto = value; }
    }
}
