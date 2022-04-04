using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class WalkingToJumpingTransition : Transition<WalkingState, JumpingState, CharacterStateMachine> {
        
        protected override bool ShouldTransition(WalkingState inState, JumpingState outState, CharacterStateMachine characterStateMachine) {
            return characterStateMachine.Parameter.JumpInput;
        }
        
    }
    
}
