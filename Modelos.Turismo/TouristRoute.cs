using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.Modelos
{
    public class TouristRoute
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }  // Ej: "Ibarra-Salinas"
        public DateTime DepartureSchedule { get; set; }
        public double BasePrice { get; set; }  // Precio base del boleto
        public List<TouristTicket>? Tickets { get; set; }  // Relación con boletos
    }
}
