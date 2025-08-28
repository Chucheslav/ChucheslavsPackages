using System;
using System.Runtime.Serialization;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace Tools
{
    [Serializable]
    public class SceneField : ISerializationCallbackReceiver
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset scene;

        private SceneAsset GetSAFromPath() =>
            string.IsNullOrEmpty(path) ? null : AssetDatabase.LoadAssetAtPath<SceneAsset>(path);

        private string GetPathFromSA() =>
            scene ? AssetDatabase.GetAssetPath(scene) : string.Empty ;

        private void OnDeserialize()
        {
            EditorApplication.update -= OnDeserialize;
            if (scene) return;
            if (string.IsNullOrEmpty(path)) return;
            scene = GetSAFromPath();
            if (!scene) path = string.Empty;
            if (!Application.isPlaying) EditorSceneManager.MarkAllScenesDirty(); //todo: magic spell
        }

#endif
    
        [SerializeField][HideInInspector] private string path = string.Empty;

        public string Path
        {
            get
            {
#if UNITY_EDITOR
                return GetPathFromSA();
#else
            return path;
#endif
            }
            set //just in case
            {
                path = value;
            
#if UNITY_EDITOR
                scene = GetSAFromPath();
#endif
            }
        }
    
        public static implicit operator string(SceneField reference) => reference.Path;

        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            path = GetPathFromSA();
#endif
        }

        public void OnAfterDeserialize()
        {
#if UNITY_EDITOR
            EditorApplication.update += OnDeserialize; //because cant access database during rebuilding
#endif
        }
    }
}
