namespace UnadeskGeometry;

public static class MeasurementConverter
{
    public static double GetDegrees(double radians) => (180 / Math.PI) * radians;
}