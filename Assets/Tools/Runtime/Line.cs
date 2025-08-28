using UnityEngine;

namespace Tools
{
//y = 
public class Line3D
{
    public Vector3 Direction { get; private set; }
    public Vector3 AnchorPoint { get; private set; }

    public Line3D(Vector3 anchorPoint, Vector3 anotherPoint)
    {
        Direction = anotherPoint - anchorPoint;
        AnchorPoint = anchorPoint;
    }

    public float DistanceToPoint(Vector3 point)
    {
        Vector3 anchorToPoint = point - AnchorPoint;
        float dotProduct = Vector3.Dot(anchorToPoint, Direction);
        return Vector3.Distance(point, AnchorPoint + Direction * dotProduct);
    }

    public bool PointIsCloseLine(Vector3 point, float maxDistance) => DistanceToPoint(point) <= maxDistance;
}
}
