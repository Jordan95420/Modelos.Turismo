using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.Modelos
{
    public class TouristTicket
    {
        [Key] public int Id { get; set; }
        public int TouristRouteId { get; set; }
        public int CategoryTicketId { get; set; }
        public int SeatCategoryId { get; set; }
        public int UserClientId { get; set; }
        public double FinallyPrice { get; set; } // Precio final boleto
        public DateTime PurchaseDate { get; set; }// Fecha compra boleto
        public UserClient? Client { get; set; }
        public SeatCategory? Seat { get; set; }
        public CategoryTicket? Category { get; set; }
        public TouristRoute? Route { get; set; }
    }
}
