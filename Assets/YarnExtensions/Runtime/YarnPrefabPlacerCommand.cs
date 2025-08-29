using System;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

namespace YarnExtensions
{
[AddComponentMenu("Custom Components/Yarn Spinner/Prefab Placer")]
[DisallowMultipleComponent]
public class YarnPrefabPlacer : MonoBehaviour
{
    [SerializeField] private List<GameobjectByID> gameObjects = new();
    
    private DialogueRunner dialogueRunner;
    
    [Serializable]
    private class GameobjectByID
    {
        public GameObject gameObject;
        public string id;
    }

    private void OnEnable()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        if (!dialogueRunner) Debug.LogError("DialogueRunner not found");
        dialogueRunner.AddCommandHandler<string, GameObject>("placeObject", PlaceObject);
    }

    public void PlaceObject(string id, GameObject marker)
    {
        GameObject toPlace = gameObjects.Find(x => x.id == id).gameObject;

        if (!toPlace)
        {
            Debug.LogError($"Could not place object with ID {id}. No such object in the list.");
            return;
        }

        if (!marker)
        {
            Debug.LogError("Marker not found");
        }
        
        // Transform marker = GameObject.Find(markerName).transform;
        Instantiate(toPlace, marker.transform. position, marker.transform.rotation);
    }
}
}
