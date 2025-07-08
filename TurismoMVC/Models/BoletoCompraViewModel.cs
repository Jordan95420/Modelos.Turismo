namespace TurismoMVC.Models
{
    public class BoletoCompraViewModel
    {
        public List<BoletoSimpleViewModel> Boletos { get; set; }
    }

    public class BoletoSimpleViewModel
    {
        public int TouristRouteId { get; set; }
        public int CategoryTicketId { get; set; }
        public int SeatCategoryId { get; set; }
        public int UserClientId { get; set; }
        public int Cantidad { get; set; }
    }
}