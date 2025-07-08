using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.Modelos
{
    public class SeatCategory
    {
        [Key] public int Id { get; set; }
        public string Type { get; set; }// "Económico", "Preferencial"
        public double Price { get; set; }

        // (Opcional) Relación inversas
        public List<TouristTicket>? Tickets { get; set; }
    }
}
