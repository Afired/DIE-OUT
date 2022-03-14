using UnityEngine;

namespace Afired.Utils.Triggers {
    
    public class TriggerTest : Trigger {

        [SerializeField] private string _test;
        
        protected override void OnTriggerEnterCallback(Collider other) {
            Debug.Log("Trigger Enter");
        }
        
        protected override void OnTriggerExitCallback(Collider other) {
            Debug.Log("Trigger Exit");
        }
        
    }
    
}
