using System;
using UnityEngine;

namespace Afired.Utils.Triggers {
    
    [Serializable]
    public class TriggerData {
        
        [SerializeField] public ColliderType ColliderType = ColliderType.Box;
        [SerializeField] public Vector3 Center = Vector3.zero;
        [SerializeField] public Vector3 Size = Vector3.one;
        [SerializeField] public float Radius = 0.5f;
        [SerializeField] public float Height = 1f;
        [SerializeField] public Axis Direction = Axis.Y;
        #if UNITY_EDITOR
        [SerializeField] public bool ColliderTypeIsDirty;
        [SerializeField] public bool ColliderValuesAreDirty;
        #endif
        
    }
    
}
