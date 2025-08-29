using System.Linq;
using UnityEngine;
using Yarn.Unity;

namespace YarnExtensions
{
public static class YarnFunctions
{
    [YarnFunction("objectExists")]
    public static bool ObjectExists(string objectName) => GameObject.FindObjectsOfType<GameObject>(true).FirstOrDefault(g => g.name == objectName);

    [YarnFunction("objectIsEnabled")]
    public static bool ObjectIsEnabled(string objectName) => GameObject.Find(objectName);
    
}
}
