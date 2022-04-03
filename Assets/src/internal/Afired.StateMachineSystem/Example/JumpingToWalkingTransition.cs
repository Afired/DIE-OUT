using DieOut.GameModes.Interactions;

namespace Afired.StateMachineSystem.Example {
    
    public class JumpingToWalkingTransition : Transition<JumpingState, WalkingState> {
        
        private Movable _movable;
        
        private void Awake() {
            _movable = GetComponent<Movable>();
        }
        
        public override bool TestCondition() {
            return _movable.IsGrounded;
        }
        
    }
    
}
