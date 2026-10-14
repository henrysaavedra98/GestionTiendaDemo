namespace GestionTiendaDemo
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; } = "";
        public string Descripcion { get; set; } = "";

        public string Resumen()
        {
            return Nombre + ": " + Descripcion;
        }
    }
}
