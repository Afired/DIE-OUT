using DieOut.GameModes.Interactions;
using UnityEngine;

namespace Afired.StateMachineSystem.Example {
    
    [RequireComponent(typeof(Movable))]
    public class JumpingToWalkingTransition : Transition<JumpingState, WalkingState> {

        [SerializeField] private float _minJumpTime = 0.2f;
        private Movable _movable;
        
        private void Awake() {
            _movable = GetComponent<Movable>();
        }
        
        protected override bool ShouldTransition(JumpingState inState, WalkingState outState) {
            return inState.TimeInJump > _minJumpTime && _movable.IsGrounded;
        }
        
    }
    
}
