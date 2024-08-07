namespace UnadeskGeometry.Triangle;

public static class TriangleMath
{
    public static double GetCos(double a, double b, double c) => (a * a + b * b - c * c) / (2 * a * b);
}