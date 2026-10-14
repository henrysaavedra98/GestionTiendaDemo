namespace GestionTiendaDemo
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string FormaPago { get; set; } = "";
        public bool ClienteFrecuente { get; set; }
        public string Sexo { get; set; } = "";

        public string Saludar()
        {
            return "Bienvenido/a " + Nombre + ". Forma de pago: " + FormaPago;
        }

        public decimal CalcularDescuento()
        {
            decimal descuento = 0;
            if (ClienteFrecuente) descuento += 10;
            if (FormaPago == "Contado") descuento += 5;
            return descuento;
        }
    }
}
