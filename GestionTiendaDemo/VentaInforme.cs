namespace GestionTiendaDemo
{
    public class VentaInforme
    {
        public string Categoria { get; set; } = "";
        public string Producto { get; set; } = "";
        public string Cliente { get; set; } = "";
        public DateTime FechaVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
    }
}
