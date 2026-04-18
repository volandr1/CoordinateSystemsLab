namespace CoordinateSystems.Models.Models;

// Імутабельна структура для полярних координат
public readonly struct PolarPoint
{
    public double Rho { get; } // Радіус
    public double Phi { get; } // Кут у радіанах

    public PolarPoint(double rho, double phi)
    {
        Rho = rho;
        Phi = phi;
    }

    // Фабричний метод для створення з декартових координат
    public static PolarPoint FromCartesian(double x, double y)
    {
        return new PolarPoint(
            Math.Sqrt(x * x + y * y),
            Math.Atan2(y, x)
        );
    }
}