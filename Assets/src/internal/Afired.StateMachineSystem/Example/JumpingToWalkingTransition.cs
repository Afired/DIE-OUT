using DieOut.GameModes.Interactions;

namespace Afired.StateMachineSystem.Example {
    
    public class JumpingToWalkingTransition : Transition<JumpingState, WalkingState> {
        
        private Movable _movable;
        
        private void Awake() {
            _movable = GetComponent<Movable>();
        }
        
        protected override bool ShouldTransition(JumpingState inState, WalkingState outState) {
            return inState.TimeInJump > 0.2f && _movable.IsGrounded;
        }
        
    }
    
}
