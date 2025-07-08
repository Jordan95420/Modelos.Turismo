
namespace PatronDiseño
{
    // Interfaz del producto (Ticket)
    public interface ITicket
    {
        int TouristRouteId { get; }
        int CategoryTicketId { get; }
        int SeatCategoryId { get; }
        int UserClientId { get; }
        double FinallyPrice { get; }
        DateTime PurchaseDate { get; }
    }

    // Implementación concreta del producto (Ticket)
    public class Ticket : ITicket
    {
        public int TouristRouteId { get; set; }
        public int CategoryTicketId { get; set; }
        public int SeatCategoryId { get; set; }
        public int UserClientId { get; set; }
        public double FinallyPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

    // Fábrica abstracta
    public abstract class TicketFactory
    {
        public abstract ITicket CreateTicket(
            int routeId,
            int categoryId,
            int seatId,
            int userClientId,
            double price
        );
    }

    // Fábrica concreta
    public class TicketFactoryGeneral : TicketFactory
    {
        public override ITicket CreateTicket(
            int routeId,
            int categoryId,
            int seatId,
            int userClientId,
            double price
        )
        {
            return new Ticket
            {
                TouristRouteId = routeId,
                CategoryTicketId = categoryId,
                SeatCategoryId = seatId,
                UserClientId = userClientId,
                FinallyPrice = price,
                PurchaseDate = DateTime.UtcNow
            };
        }
    }
}