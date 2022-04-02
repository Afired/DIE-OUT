using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class WalkingState : State {
        
        public override void OnStateEnter() { Debug.Log("Entered Walking State"); }
        
        public override void OnStateUpdate() { }
        
        public override void OnStateExit() { Debug.Log("Exited Walking State"); }
        
    }
    
}
