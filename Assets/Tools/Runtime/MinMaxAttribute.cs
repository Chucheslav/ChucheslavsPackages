using UnityEngine;
/// <summary>
/// mark Vector2 field with this to display double slider in the editor
/// </summary>
public class MinMaxAttribute: PropertyAttribute
{
    public readonly float Min;
    public readonly float Max;

    public MinMaxAttribute(float min, float max)
    {
        Min = min;
        if (max < min) max = min;
        Max = max;
    }
}