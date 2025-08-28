using UnityEngine;

namespace Tools
{
public static class IntFloatExtensions
{
    public static bool RollChance(this int percent) => Random.Range(0, 100) < percent;
    public static bool RollChance(this float percent) => Random.Range(0, 100) < percent;
    public static int RoundToInt(this float value) => Mathf.RoundToInt(value);
    
    public static string ConvertToHex(this float value) => Mathf.RoundToInt( Mathf.Clamp01(value) * 255f).ToString("x2");

    public static string ConvertToHex(this int value) => Mathf.Clamp(value, 0, 255).ToString("x2");
    
    public static bool IsBetween(this float toCheck, float one, float two) => 
        toCheck <= Mathf.Max(one, two) && toCheck >= Mathf.Min(one, two);
    public static bool IsBetween(this int toCheck, int one, int two) => 
        toCheck <= Mathf.Max(one, two) && toCheck >= Mathf.Min(one, two);
    public static bool IsBetween(this int toCheck, float one, float two) => 
        toCheck <= Mathf.Max(one, two) && toCheck >= Mathf.Min(one, two);
    
    public static bool IsBetweenExclusive(this float toCheck, float one, float two) => 
        toCheck < Mathf.Max(one, two) && toCheck > Mathf.Min(one, two);
    public static bool IsBetweenExclusive(this int toCheck, int one, int two) => 
        toCheck < Mathf.Max(one, two) && toCheck > Mathf.Min(one, two);
    public static bool IsBetweenExclusive(this int toCheck, float one, float two) => 
        toCheck < Mathf.Max(one, two) && toCheck > Mathf.Min(one, two);
    
    public static float RandomizeSign(this float f) => f * (UnityEngine.Random.Range(0, 1) * 2 - 1);
    
    public static float Remap(this float value, float fromMin, float fromMax, float toMin, float toMax) => 
        (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    
    public static float Remap(this int value, float fromMin, float fromMax, float toMin, float toMax) =>
        Remap((float) value, fromMin, fromMax, toMin, toMax);
        

    public static int AsSign(this bool value, bool plusIsPositive = true) => value ^ plusIsPositive ? -1 : 1;
}
}