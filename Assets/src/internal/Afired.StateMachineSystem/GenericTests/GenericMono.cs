using System;
using UnityEngine;

namespace Afired.StateMachineSystem.GenericTests {
    
    public class GenericMono : MonoBehaviour {

        [SerializeReference] private int _test;
        [SerializeField] private GenericContainer<int> _genericContainer;
        
        [Serializable]
        public class GenericContainer<T> {
            [SerializeField] private T _generic;
        }
        
    }
    
}
