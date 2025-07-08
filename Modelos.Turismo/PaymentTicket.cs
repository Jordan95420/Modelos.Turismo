using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.Modelos
{
    public class PaymentTicket
    {
        [Key] public int Id { get; set; }  // Relación con el pago
        public int PaymentId { get; set; }  // Relación con el pago
        public Payment? Payment { get; set; }

        public int TouristTicketId { get; set; }  // Relación con el boleto
        public TouristTicket? Ticket { get; set; }
    }
}
