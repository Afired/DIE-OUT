using System;
using UnityEngine;

namespace Afired.Utils.Prefabs {
    
    [Serializable]
    public class Prefab {
        
        [SerializeField] private GameObject _prefab;
        
        public GameObject Instantiate() {
            if(_prefab == null)
                throw new Exception($"Prefab has not been assigned!");
            GameObject instance = GameObject.Instantiate(_prefab);
            return instance;
        }
        
        public GameObject Instantiate(Vector3 position, Quaternion rotation) {
            if(_prefab == null)
                throw new Exception($"Prefab has not been assigned!");
            GameObject instance = GameObject.Instantiate(_prefab, position, rotation);
            return instance;
        }
        
        public GameObject Instantiate(Transform parent) {
            if(_prefab == null)
                throw new Exception($"Prefab has not been assigned!");
            GameObject instance = GameObject.Instantiate(_prefab, parent);
            return instance;
        }
        
        public GameObject Instantiate(Transform parent, bool worldPositionStays) {
            if(_prefab == null)
                throw new Exception($"Prefab has not been assigned!");
            GameObject instance = GameObject.Instantiate(_prefab, parent, worldPositionStays);
            return instance;
        }
        
        public GameObject Instantiate(Vector3 position, Quaternion rotation, Transform parent) {
            if(_prefab == null)
                throw new Exception($"Prefab has not been assigned!");
            GameObject instance = GameObject.Instantiate(_prefab, position, rotation, parent);
            return instance;
        }
        
    }
    
}
