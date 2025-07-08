

namespace PatronDiseño
{
    // Interfaz de la estrategia
    public interface IPriceCalculation
    {
        double CalculatePrice(double baseRoutePrice, double seatPrice, double categoryPrice);
    }

    // Estrategia para Adulto
    public class AdultPriceCalculation : IPriceCalculation
    {
        public double CalculatePrice(double baseRoutePrice, double seatPrice, double categoryPrice)
        {
            // Precio normal: suma de todos los componentes
            return baseRoutePrice + seatPrice + categoryPrice;
        }
    }

    // Estrategia para Niño
    public class ChildPriceCalculation : IPriceCalculation
    {
        public double CalculatePrice(double baseRoutePrice, double seatPrice, double categoryPrice)
        {
            // Por ejemplo, 50% de descuento sobre el precio base
            double total = baseRoutePrice + seatPrice + categoryPrice;
            return total * 0.5;
        }
    }

    // Estrategia para Tercera Edad
    public class SeniorPriceCalculation : IPriceCalculation
    {
        public double CalculatePrice(double baseRoutePrice, double seatPrice, double categoryPrice)
        {
            // Por ejemplo, 30% de descuento sobre el precio base
            double total = baseRoutePrice + seatPrice + categoryPrice;
            return total * 0.7;
        }
    }

    // Ejemplo de uso
    public class PriceCalculatorContext
    {
        private IPriceCalculation _strategy;

        public PriceCalculatorContext(IPriceCalculation strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IPriceCalculation strategy)
        {
            _strategy = strategy;
        }

        public double Calculate(double baseRoutePrice, double seatPrice, double categoryPrice)
        {
            return _strategy.CalculatePrice(baseRoutePrice, seatPrice, categoryPrice);
        }
    }
}