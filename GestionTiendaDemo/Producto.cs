namespace GestionTiendaDemo
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; } = "";
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
        public int CategoriaID { get; set; }

        public string Descripcion()
        {
            string estado = Disponible ? "Disponible" : "Agotado";
            return Nombre + " | C$ " + Precio + " | " + estado;
        }
    }
}
