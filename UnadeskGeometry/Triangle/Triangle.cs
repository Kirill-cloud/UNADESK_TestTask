using UnadeskGeometry.Triangle.Extensions;

namespace UnadeskGeometry.Triangle;

public class Triangle
{
    public double A { get; set; }

    public double B { get; set; }
    
    public double C { get; set; }
    
    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
        var sides = this.GetSortedSides();
        if (a + b <= c)
        {
            throw new ImpossibleTriangleException(a,b,c);
        }
    }
    
    private double[] GetSortedSides()
    {
        var sides = new List<double>(3) { A,B,C };
        sides.Sort();
        return sides.ToArray();
    }
    
    public TriangleType GetType()
    {
        var sides = GetSortedSides();
        
        var cosA = TriangleExtensions.GetCos(sides[0], sides[1], sides[2]);
        var angleA = GetDegrees(Math.Acos(cosA));
        
        var cosB = GetCos(sides[0], sides[2], sides[1]);
        var angleB = GetDegrees(Math.Acos(cosB));
        
        var cosC = GetCos(sides[1], sides[2], sides[0]);
        var angleC = GetDegrees(Math.Acos(cosC));

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
