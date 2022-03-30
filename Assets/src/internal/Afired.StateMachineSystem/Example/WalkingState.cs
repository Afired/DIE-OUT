using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class WalkingState : MonoBehaviour, IState {
        
        public void OnStateEnter() { Debug.Log("Entered Walking State"); }
        
        public void OnStateUpdate() { }
        
        public void OnStateExit() { Debug.Log("Exited Walking State"); }
        
    }
    
}
