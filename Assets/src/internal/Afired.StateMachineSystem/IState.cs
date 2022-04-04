namespace Afired.StateMachineSystem {
    
    public interface IState<in TStateMachine> where TStateMachine : IStateMachine, new() {
        
        internal void OnStateEnter(TStateMachine stateMachine);
        internal void OnStateUpdate(TStateMachine stateMachine);
        internal void OnStateExit(TStateMachine stateMachine);
        
    }
    
}
