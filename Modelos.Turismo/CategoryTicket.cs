using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.Modelos
{
    public class CategoryTicket
    {
        [Key] public int Id { get; set; }
        public string Type { get; set; }  // Ej: "Niño", "Adulto", "Tercera Edad"
        public double Price { get; set; }  // Descuento según la categoría
        public List<TouristTicket>? Tickets { get; set; }
    }
}
