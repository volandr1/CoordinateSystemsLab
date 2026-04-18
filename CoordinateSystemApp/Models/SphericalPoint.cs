namespace CoordinateSystems.Models.Models;

public readonly struct SphericalPoint
{
    public double Rho { get; }   // Радиальное расстояние
    public double Theta { get; } // Зенитный угол (от оси Z)
    public double Phi { get; }   // Азимутальный угол (от оси X)

    public SphericalPoint(double rho, double theta, double phi)
    {
        Rho = rho;
        Theta = theta;
        Phi = phi;
    }

    public static SphericalPoint FromCartesian(double x, double y, double z)
    {
        double rho = Math.Sqrt(x * x + y * y + z * z);
        double theta = Math.Acos(z / rho);
        double phi = Math.Atan2(y, x);
        return new SphericalPoint(rho, theta, phi);
    }
}