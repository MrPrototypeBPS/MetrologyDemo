namespace MetrologyDemo.Models
{
    /// <summary>
    /// Represents a single 3D spatial coordinate captured by the Coordinate Measuring Machine (CMM).
    /// </summary>
    /// <remarks>
    /// Designed as a standard class for this WPF DataGrid demo. 
    /// In a high-performance 3D rendering scenario processing millions of points, 
    /// this would be optimized to a readonly record struct to minimize GC pressure.
    /// </remarks>
    public class MeasurementPoint
    {
        /// <summary>Gets or sets the X-axis coordinate in millimeters (mm).</summary>
        public double X { get; set; }

        /// <summary>Gets or sets the Y-axis coordinate in millimeters (mm).</summary>
        public double Y { get; set; }

        /// <summary>Gets or sets the Z-axis coordinate in millimeters (mm).</summary>
        public double Z { get; set; }
    }
}