namespace UnadeskGeometry.Triangle.Extensions;

public static class TriangleExtensions
{
    public static double GetDegrees(double radians) => (180 / Math.PI) * radians;
    
    public static double GetCos(double a, double b, double c) => (a * a + b * b - c * c) / (2 * a * b);
}