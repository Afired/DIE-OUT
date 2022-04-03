using System;
using UnityEngine;

namespace Afired.StateMachineSystem {
    
    public abstract class Transition<InState, OutState> : MonoBehaviour, ITransition where InState : State where OutState : State {
        
        protected abstract bool ShouldTransition(InState inState, OutState outState);

        bool ITransition.ShouldTransition(State inState, State outState) {
            return ShouldTransition(inState as InState, outState as OutState);
        }
        
        public Type GetInState() {
            return typeof(InState);
        }
        
        public Type GetOutState() {
            return typeof(OutState);
        }
        
    }
    
}
