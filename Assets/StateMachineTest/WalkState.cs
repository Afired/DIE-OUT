using Afired.Utils.StateMachine;
using UnityEngine;

namespace StateMachineTest {
    
    public class WalkState : State {
        
        protected override void OnStateEnter() {
            Debug.Log("Entered Move State");
        }
        
        protected override void OnStateUpdate() {
        }
        
        protected override void OnStateExit() {
            Debug.Log("Exit Move State");
        }
        
    }
    
}