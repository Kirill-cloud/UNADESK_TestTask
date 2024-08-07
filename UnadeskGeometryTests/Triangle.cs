using UnadeskGeometry.Triangle;
using UnadeskGeometry.Triangle.Extensions;

namespace UnadeskGeometryTests;

public class Tests
{
    [Test]
    public void RightAngle()
    {
        var triangle = new Triangle(3, 4, 5);
        var type = triangle.GetTriangleType();
        Assert.That(type, Is.EqualTo(TriangleType.RightAngle));
    }
    
    [Test]
    public void AcuteAngle()
    {
        var triangle = new Triangle(3, 3, 3);
        var type = triangle.GetTriangleType();
        Assert.That(type, Is.EqualTo(TriangleType.AcuteAngle));
    }
    
    [Test]
    public void ObtuseAngle()
    {
        var triangle = new Triangle(3, 3, 5);
        var type = triangle.GetTriangleType();
        Assert.That(type, Is.EqualTo(TriangleType.ObtuseAngle));
    }
    
    [Test]
    public void ImpossibleTriangle()
    {
        Assert.Throws<ImpossibleTriangleException>(() => { _ = new Triangle(3, 3, 10); });
    }
}