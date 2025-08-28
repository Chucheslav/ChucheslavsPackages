using System;
using System.IO;
using UnityEngine;

namespace Tools.Runtime
{
[Serializable]
public class ScriptableObjectSaveLoader<T> where T : ScriptableObject
{
    public string defaultSaveFileName;
    
    private string PathToFile(string fileName) => Path.Combine(Application.persistentDataPath, fileName?? defaultSaveFileName);

    public  void SaveToFile(T scriptableObject, string fileName = null)
    {
        File.WriteAllText(PathToFile(fileName), JsonUtility.ToJson(scriptableObject));
    }

    public bool TryLoadFromFile(out T result, string fileName = null)
    {
        result = null;
        if (!File.Exists(PathToFile(fileName))) return false;
        try
        {
            JsonUtility.FromJsonOverwrite(File.ReadAllText(PathToFile(fileName)), result);
        }
        catch (Exception e)
        {
            Debug.Log($"Failed to load scriptable object from file: {e.Message}");
            return false;
        }

        return true;
}
}
}