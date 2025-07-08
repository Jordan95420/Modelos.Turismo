using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.Modelos
{
    public class PaymentViewModel
    {
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }  // Tarjeta de crédito o PayPal
        public string CardNumber { get; set; }     // Número de tarjeta (solo para el pago con tarjeta)
    }
}
