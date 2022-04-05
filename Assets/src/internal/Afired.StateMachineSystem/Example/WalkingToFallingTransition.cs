namespace Afired.StateMachineSystem.Example {
    
    public class WalkingToFallingTransition : Transition<WalkingState, FallingState, CharacterStateMachine> {
        
        protected override bool ShouldTransition(WalkingState inState, FallingState outState, CharacterStateMachine stateMachine) {
            return !stateMachine.Parameter.IsGrounded;
        }
        
    }
    
}