using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class WalkingToJumpingTransition : Transition<WalkingState, JumpingState> {

        [SerializeField] private CharacterStateMachine _csm;
        
        public override bool TestCondition() {
            return _csm.Parameter.JumpInput;
        }
        
    }
    
}
