namespace CoordinateSystems.Models.Models;

public readonly struct CartesianPoint3D
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public CartesianPoint3D(double x, double y, double z) => (X, Y, Z) = (x, y, z);

    // Фабричный метод из сферических координат
    public static CartesianPoint3D FromSpherical(SphericalPoint s)
    {
        return new CartesianPoint3D(
            s.Rho * Math.Sin(s.Theta) * Math.Cos(s.Phi),
            s.Rho * Math.Sin(s.Theta) * Math.Sin(s.Phi),
            s.Rho * Math.Cos(s.Theta)
        );
    }
}