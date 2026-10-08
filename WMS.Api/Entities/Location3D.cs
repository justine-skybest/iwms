namespace WMS.Api.Entities
{
    public class Location3D
    {
        public int Id { get; set; }

        // Three.js World Coordinates (in units/meters)
        public float PositionX { get; set; }
        public float PositionY { get; set; } // Elevation / height off floor
        public float PositionZ { get; set; }

        // Rotation around Y-axis (heading/yaw in radians or degrees)
        public float RotationY { get; set; }

        // Bounding box dimensions for 3D rendering
        public float Width { get; set; }  // X dimension
        public float Height { get; set; } // Y dimension
        public float Depth { get; set; }  // Z dimension
    }
}
