using System.Linq;
using UnityEngine;
using Yarn.Unity;

public static class YarnCommands
{
    [YarnCommand("mainCameraToMarker")]
    public static void MainCameraToTransform(string transformName)
    {
        Transform target = GameObject.Find(transformName).GetComponent<Transform>(); 
        Camera.main.transform.SetPositionAndRotation(target.transform.position, target.transform.rotation);
    }

    [YarnCommand("enableObject")]
    public static void EnableObject(string objectName)
    {
        GameObject toEnable = GameObject.FindObjectsOfType<GameObject>(true).FirstOrDefault(g => g.name == objectName);
        if (!toEnable)
        {
            Debug.LogError($"no object named {objectName} found");
            return;
        }
        toEnable.gameObject.SetActive(true);
    }
    
    [YarnCommand("disableObject")]
    public static void DisableObject(GameObject objectName)
    {
        if (!objectName)
        {
            Debug.LogError("Couldn't find object");
            return;
        }
        
        objectName.SetActive(false);
    }
}