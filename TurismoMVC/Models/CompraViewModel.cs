using Turismo.Modelos;

namespace TurismoMVC.Models
{
    public class CompraViewModel
    {
        public int CompraId { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaCompra { get; set; }
        public List<TouristTicket> Boletos { get; set; }
    }
}
