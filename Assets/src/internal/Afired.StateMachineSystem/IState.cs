namespace Afired.StateMachineSystem {
    
    public interface IState<in T> where T : IStateMachine {
        
        internal void OnStateEnter(T stateMachine);
        internal void OnStateUpdate(T stateMachine);
        internal void OnStateExit(T stateMachine);
        
    }
    
}
