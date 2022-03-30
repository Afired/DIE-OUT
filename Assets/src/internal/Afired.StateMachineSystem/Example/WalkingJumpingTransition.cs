using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class WalkingJumpingTransition : MonoBehaviour, ITransition<WalkingState, JumpingState> {
        
        public bool TestCondition() {
            Debug.Log("Testing");
            return Input.GetKeyDown(KeyCode.Space);
        }
        
    }
    
}
