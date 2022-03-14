using UnityEngine;

namespace Afired.Utils.Triggers {
    
    public delegate void OnTriggerEnter(Collider other);
    public delegate void OnTriggerStay(Collider other);
    public delegate void OnTriggerExit(Collider other);
    
    public class TriggerHook : MonoBehaviour {
        
        public event OnTriggerEnter OnTriggerEnterCallback;
        public event OnTriggerStay OnTriggerStayCallback;
        public event OnTriggerExit OnTriggerExitCallback;
        
        private void OnTriggerEnter(Collider other) {
            OnTriggerEnterCallback?.Invoke(other);
        }
        
        private void OnTriggerStay(Collider other) {
            OnTriggerStayCallback?.Invoke(other);
        }
        
        private void OnTriggerExit(Collider other) {
            OnTriggerExitCallback?.Invoke(other);
        }
        
    }
    
}
