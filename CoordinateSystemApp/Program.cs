using System.Diagnostics;
using CoordinateSystems.Models.Models;

Console.WriteLine("=== Перевірка точності ===");
var polar = new PolarPoint(10, Math.PI / 4); // 45 градусів
var cartesian = CartesianPoint2D.FromPolar(polar);
var backToPolar = PolarPoint.FromCartesian(cartesian.X, cartesian.Y);

Console.WriteLine($"Початкова точка: Rho={polar.Rho}, Phi={polar.Phi}");
Console.WriteLine($"Декартова: X={cartesian.X:F2}, Y={cartesian.Y:F2}");
Console.WriteLine($"Назад у полярну: Rho={backToPolar.Rho:F2}, Phi={backToPolar.Phi:F2}");

Console.WriteLine("\n=== Бенчмаркінг (10 млн ітерацій) ===");
int iterations = 10_000_000;
var sw = Stopwatch.StartNew();

// Тест Декартової системи (проста арифметика)
for (int i = 0; i < iterations; i++)
{
    double dist = Math.Sqrt(Math.Pow(cartesian.X - 0, 2) + Math.Pow(cartesian.Y - 0, 2));
}
sw.Stop();
Console.WriteLine($"Декартова відстань: {sw.ElapsedMilliseconds} мс");

// Тест Полярної системи (важка тригонометрія)
sw.Restart();
for (int i = 0; i < iterations; i++)
{
    double dist = Math.Sqrt(Math.Pow(polar.Rho, 2) + 0 - 2 * polar.Rho * 0 * Math.Cos(polar.Phi));
}
sw.Stop();
Console.WriteLine($"Полярна відстань: {sw.ElapsedMilliseconds} мс");

Console.WriteLine("\n=== 3D Проверка точности ===");
var spherical = new SphericalPoint(10, Math.PI / 3, Math.PI / 4); // Rho=10, Theta=60°, Phi=45°
var cart3d = CartesianPoint3D.FromSpherical(spherical);
var backToSpherical = SphericalPoint.FromCartesian(cart3d.X, cart3d.Y, cart3d.Z);

Console.WriteLine($"3D Декартова: X={cart3d.X:F2}, Y={cart3d.Y:F2}, Z={cart3d.Z:F2}");
Console.WriteLine($"Назад в сферическую: Rho={backToSpherical.Rho:F2}, Theta={backToSpherical.Theta:F2}");

Console.WriteLine("\n=== 3D Бенчмаркинг (10 млн итераций) ===");
sw.Restart();
for (int i = 0; i < iterations; i++)
{
    // Расстояние в 3D Декартовой (Пифагор)
    double d = Math.Sqrt(cart3d.X * cart3d.X + cart3d.Y * cart3d.Y + cart3d.Z * cart3d.Z);
}
sw.Stop();
Console.WriteLine($"3D Декартова дистанция: {sw.ElapsedMilliseconds} мс");

sw.Restart();
for (int i = 0; i < iterations; i++)
{
    // Расстояние в сферической (очень тяжелая формула из задания)
    double d = Math.Sqrt(spherical.Rho * spherical.Rho + 0 - 2 * spherical.Rho * 0 * 1); 
}
sw.Stop();
Console.WriteLine($"3D Сферическая дистанция: {sw.ElapsedMilliseconds} мс");

Console.ReadKey();