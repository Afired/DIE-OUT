using System;
using UnityEngine;

namespace Afired.StateMachineSystem {
    
    public abstract class Transition<TInState, TOutState, TStateMachine> : MonoBehaviour, ITransition<TStateMachine> where TInState : IState<TStateMachine> where TOutState : IState<TStateMachine> where TStateMachine : IStateMachine, new() {
        
        protected abstract bool ShouldTransition(TInState inState, TOutState outState, TStateMachine stateMachine);
        
        bool ITransition<TStateMachine>.ShouldTransition(IState<TStateMachine> inState, IState<TStateMachine> outState, TStateMachine stateMachine) {
            return ShouldTransition((TInState) inState, (TOutState) outState, stateMachine);
        }
        
        public Type GetInState() {
            return typeof(TInState);
        }
        
        public Type GetOutState() {
            return typeof(TOutState);
        }
        
    }
    
}
