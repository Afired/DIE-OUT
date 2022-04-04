using UnityEngine;

namespace Afired.StateMachineSystem {
    
    public abstract class State<TStateMachine> : MonoBehaviour, IState<TStateMachine> where TStateMachine : IStateMachine, new() {
        
        void IState<TStateMachine>.OnStateEnter(TStateMachine stateMachine) => OnStateEnter(stateMachine);
        void IState<TStateMachine>.OnStateUpdate(TStateMachine stateMachine) => OnStateUpdate(stateMachine);
        void IState<TStateMachine>.OnStateExit(TStateMachine stateMachine) => OnStateExit(stateMachine);
        
        protected virtual void OnStateEnter(TStateMachine stateMachine) { }
        protected virtual void OnStateUpdate(TStateMachine stateMachine) { }
        protected virtual void OnStateExit(TStateMachine stateMachine) { }
        
    }
    
}
