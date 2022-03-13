using UnityEditor;
using UnityEngine;

namespace DieOut.Editor {
    
    public static class EditorSerialization {
        
        public static T LoadScriptableObject<T>() where T : ScriptableObject {
            // get all GUIDs of type T
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T)); // use typeof(T) instead of nameof(T) to prevent duplicate naming

            // handle exceptions
            if(guids.Length == 0) {
                Debug.LogWarning($"No {typeof(T).Name} Asset found!");
                return null;
            }
            if(guids.Length > 1)
                Debug.LogWarning($"Multiple {typeof(T).Name} assets found, but expected to find only one! Returned first found asset! This can lead to unexpected behaviour! Make sure there is only one asset of type {typeof(T).Name} in the asset browser!");

            // get path from first GUID in guids
            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            // load asset at path
            T asset = AssetDatabase.LoadAssetAtPath<T>(path);
            return asset;
        }
        
        public static T[] LoadScriptableObjects<T>() where T : ScriptableObject {
            // get all GUIDs of type T
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(T)); // use typeof(T) instead of nameof(T) to prevent duplicate naming
            
            // get paths from GUIDs
            string[] paths = new string[guids.Length];
            for(int i = 0; i < guids.Length; i++) {
                paths[i] = AssetDatabase.GUIDToAssetPath(guids[i]);
            }
            
            // load assets at paths
            T[] assets = new T[paths.Length];
            for(int i = 0; i < paths.Length; i++) {
                assets[i] = AssetDatabase.LoadAssetAtPath<T>(paths[i]);
            }
            
            return assets;
        }
        
    }
    
}
