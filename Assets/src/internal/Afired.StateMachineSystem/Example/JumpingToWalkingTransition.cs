using DieOut.GameModes.Interactions;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    public class JumpingToWalkingTransition : Transition<JumpingState, WalkingState> {
        
        [SerializeField] private Movable _movable;
        
        public override bool TestCondition() {
            return _movable.IsGrounded;
        }
        
    }
    
}
