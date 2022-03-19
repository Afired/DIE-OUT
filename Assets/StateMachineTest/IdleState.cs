using Afired.Utils.StateMachine;
using UnityEngine;

namespace StateMachineTest {
    
    public class IdleState : State {
        
        protected override void OnStateEnter() {
            Debug.Log("Entered Idle State");
        }
        
        protected override void OnStateUpdate() {
        
        }
        
        protected override void OnStateExit() {
            Debug.Log("Exit Idle State");
        }
        
    }
    
}