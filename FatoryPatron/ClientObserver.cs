

namespace PatronDiseño
{
    // Interfaz del Observer
    public interface IObserver
    {
        void Update(string message);
    }

    // Observer concreto: Cliente
    public class ClientObserver : IObserver
    {
        public string ClientName { get; }
        public string LastNotification { get; private set; }

        public ClientObserver(string clientName)
        {
            ClientName = clientName;
        }

        public void Update(string message)
        {
            LastNotification = $"Estimado {ClientName}: {message}";
            // Aquí podrías enviar un email, SMS, etc.
            // Por ahora solo se guarda el mensaje.
        }
    }

    // Sujeto (Subject): Reserva
    public class Reservation
    {
        private readonly List<IObserver> _observers = new();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }

        // Método para simular la reserva y notificar
        public void ReserveSeat(string seatInfo)
        {
            // Aquí iría la lógica real de reserva
            Notify($"Su asiento {seatInfo} ha sido reservado correctamente.");
        }

        // Método para notificar disponibilidad
        public void NotifyAvailability(string seatInfo)
        {
            Notify($"El asiento {seatInfo} está disponible para su reserva.");
        }
    }
}