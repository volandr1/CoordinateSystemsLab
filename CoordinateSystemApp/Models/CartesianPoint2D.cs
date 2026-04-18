namespace CoordinateSystems.Models.Models;

public readonly struct CartesianPoint2D
{
    public double X { get; }
    public double Y { get; }

    public CartesianPoint2D(double x, double y)
    {
        X = x;
        Y = y;
    }
    
    public static CartesianPoint2D FromPolar(PolarPoint polar)
    {
        return new CartesianPoint2D(
            polar.Rho * Math.Cos(polar.Phi),
            polar.Rho * Math.Sin(polar.Phi)
        );
    }
}

