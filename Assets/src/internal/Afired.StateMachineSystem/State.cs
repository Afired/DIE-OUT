using UnityEngine;

namespace Afired.StateMachineSystem {
    
    public abstract class State<T> : MonoBehaviour, IState<T> where T : IStateMachine/*, new()*/ {
        
        void IState<T>.OnStateEnter(T stateMachine) => OnStateEnter(stateMachine);
        void IState<T>.OnStateUpdate(T stateMachine) => OnStateUpdate(stateMachine);
        void IState<T>.OnStateExit(T stateMachine) => OnStateExit(stateMachine);
        
        protected virtual void OnStateEnter(T stateMachine) { }
        protected virtual void OnStateUpdate(T stateMachine) { }
        protected virtual void OnStateExit(T stateMachine) { }
        
    }
    
}
