namespace Afired.StateMachineSystem.Example {
    
    public class FallingToWalkingTransition : Transition<FallingState, WalkingState, CharacterStateMachine> {
        
        protected override bool ShouldTransition(FallingState inState, WalkingState outState, CharacterStateMachine stateMachine) {
            return stateMachine.Parameter.IsGrounded;
        }
        
    }
    
}
