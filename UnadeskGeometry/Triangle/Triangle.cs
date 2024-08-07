namespace UnadeskGeometry.Triangle;

public class Triangle
{
    public double A { get; }

    public double B { get; }
    
    public double C { get; }
    
    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
        
        if (IsTriangleImpossible())
        {
            throw new ImpossibleTriangleException(a,b,c);
        }
    }

    private bool IsTriangleImpossible()
    {
        var sides = new List<double>(3) { A,B,C };
        sides.Sort();
        return sides[0] + sides[1] <= sides[2];
    }
    
    public TriangleType GetTriangleType()
    {
        var cosA = TriangleMath.GetCos(A,B,C);
        var angleA = MeasurementConverter.GetDegrees(Math.Acos(cosA));
        
        var cosB = TriangleMath.GetCos(A, C, B);
        var angleB = MeasurementConverter.GetDegrees(Math.Acos(cosB));
        
        var cosC = TriangleMath.GetCos(C, B, A);
        var angleC = MeasurementConverter.GetDegrees(Math.Acos(cosC));

        var angles = new List<double>(3) { angleA, angleB, angleC };
        angles.Sort();

        var edge = angles[2] - 90;
        
        if (Math.Abs(edge) <= Settings.Accuracy)
        {
            return TriangleType.RightAngle;
        }

        return edge > 0 ? TriangleType.ObtuseAngle : TriangleType.AcuteAngle;
    }
}
