using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class JumpingState : State {
        
        public override void OnStateEnter() { Debug.Log("Entered Jumping State"); }
        
        public override void OnStateUpdate() { }
        
        public override void OnStateExit() { Debug.Log("Exited Jumping State"); }
        
    }
    
}
