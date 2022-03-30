using System;

namespace Afired.StateMachineSystem {
    
    public readonly struct RuntimeTransition {
        
        public readonly Func<bool> Condition;
        public readonly IState NextState;
        
        internal RuntimeTransition(Func<bool> condition, IState nextState) {
            Condition = condition ?? throw new ArgumentNullException();
            NextState = nextState ?? throw new ArgumentNullException();
        }
        
    }
    
}
