using System;

namespace Afired.StateMachineSystem {
    
    public interface ITransition {
        
        internal abstract bool ShouldTransition(State inState, State outState);
        public abstract Type GetInState();
        public abstract Type GetOutState();

    }
    
}
