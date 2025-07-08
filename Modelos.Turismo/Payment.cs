using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.Modelos
{
    public class Payment
    {
        [Key] public int Id { get; set; }
        public int UserClientId { get; set; }  // Relación con el cliente
        public double Amount { get; set; }  // Monto total del pago
        public string PaymentMethod { get; set; }  // Método de pago (Ej. "Tarjeta de Crédito")
        public DateTime PaymentDate { get; set; }  // Fecha del pago
        public string PaymentStatus { get; set; }  // Estado del pago (Ej. "Completado", "Pendiente")
        public string TransactionId { get; set; }  // ID de la transacción (si aplica)

        // Relación con el cliente (puedes acceder a los datos del cliente)
        public UserClient? Client { get; set; }

        // Relación con los boletos (un pago puede tener muchos boletos)
        public List<TouristTicket>? Tickets { get; set; }
    }
}
