namespace MetrologyDemo.Models
{
    // Represents a 3D coordinate point captured from a Coordinate Measuring Machine (CMM)
    public class MeasurementPoint
    {
        // Gets or sets the X-axis coordinate in millimeters
        public double X { get; set; }

        // Gets or sets the Y-axis coordinate in millimeters
        public double Y { get; set; }

        // Gets or sets the Z-axis coordinate in millimeters
        public double Z { get; set; }
    }
}