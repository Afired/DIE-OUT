using DieOut.GameModes.Interactions;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    [RequireComponent(typeof(JumpingState))]
    public class JumpingToWalkingTransition : Transition<JumpingState, WalkingState> {
        
        private Movable _movable;
        private JumpingState _jumpingState;
        
        private void Awake() {
            _movable = GetComponent<Movable>();
            _jumpingState = GetComponent<JumpingState>();
        }
        
        public override bool TestCondition() {
            return _jumpingState.TimeInJump > 0.1f && _movable.IsGrounded;
        }
        
    }
    
}
