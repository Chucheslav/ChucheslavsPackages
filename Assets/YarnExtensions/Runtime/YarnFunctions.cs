using System.Linq;
using UnityEngine;
using Yarn.Unity;

namespace YarnExtensions
{
public static class YarnFunctions
{
    [YarnFunction("objectExists")]
    public static bool ObjectExists(string objectName) => GameObject.FindObjectsByType(typeof(GameObject), FindObjectsInactive.Include, FindObjectsSortMode.None).FirstOrDefault(g => g.name == objectName);

    [YarnFunction("objectIsEnabled")]
    public static bool ObjectIsEnabled(string objectName) => GameObject.Find(objectName);
    
}
}
