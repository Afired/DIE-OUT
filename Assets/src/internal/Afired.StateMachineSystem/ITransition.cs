using System;

namespace Afired.StateMachineSystem {
    
    public interface ITransition<TStateMachine> where TStateMachine : IStateMachine {
        
        internal abstract bool ShouldTransition(IState<TStateMachine> inState, IState<TStateMachine> outState, TStateMachine stateMachine);
        public abstract Type GetInState();
        public abstract Type GetOutState();
        
    }
    
}
