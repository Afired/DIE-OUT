using System;
using UnityEngine;

namespace Afired.StateMachineSystem {
    
    public abstract class Transition<InState, OutState> : MonoBehaviour, ITransition where InState : State where OutState : State {
        
        public abstract bool TestCondition();
        
        public Type GetInState() {
            return typeof(InState);
        }
        
        public Type GetOutState() {
            return typeof(OutState);
        }
        
    }
    
}
