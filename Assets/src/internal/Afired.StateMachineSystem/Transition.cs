using System;

namespace Afired.StateMachineSystem {
    
    public abstract class Transition<InState, OutState> : TransitionBase where InState : State where OutState : State {
        
        public override Type GetInState() {
            return typeof(InState);
        }
        
        public override Type GetOutState() {
            return typeof(OutState);
        }
        
    }
    
}
