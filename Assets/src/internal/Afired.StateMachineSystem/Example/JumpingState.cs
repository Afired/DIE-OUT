using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class JumpingState : MonoBehaviour, IState {
        
        public void OnStateEnter() { Debug.Log("Entered Jumping State"); }
        
        public void OnStateUpdate() { }
        
        public void OnStateExit() { Debug.Log("Exited Jumping State"); }
        
    }
    
}
