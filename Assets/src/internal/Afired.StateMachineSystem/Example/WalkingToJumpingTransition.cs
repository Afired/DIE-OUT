using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class WalkingToJumpingTransition : Transition<WalkingState, JumpingState> {

        [SerializeField] private CharacterStateMachine _csm;
        
        protected override bool ShouldTransition(WalkingState inState, JumpingState outState) {
            return _csm.Parameter.JumpInput;
        }
        
    }
    
}
