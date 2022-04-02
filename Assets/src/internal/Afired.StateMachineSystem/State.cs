using UnityEngine;

namespace Afired.StateMachineSystem {
    
    public class State : MonoBehaviour {
        
        public virtual void OnStateEnter() { }
        public virtual void OnStateUpdate() { }
        public virtual void OnStateExit() { }
        
    }
    
}
