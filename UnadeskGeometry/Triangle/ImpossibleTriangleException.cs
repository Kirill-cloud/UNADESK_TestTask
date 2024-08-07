namespace UnadeskGeometry.Triangle;

public class ImpossibleTriangleException(double a, double b, double c) : Exception
{
    public override string Message => $"Triangle with sides {a} {b} {c} cannot be created";
}