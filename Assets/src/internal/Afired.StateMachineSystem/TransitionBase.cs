using System;

namespace Afired.StateMachineSystem {
    
    public interface ITransition {
        
        public abstract bool TestCondition();
        public abstract Type GetInState();
        public abstract Type GetOutState();

    }
    
}
