using System;
using UnityEngine;

namespace Afired.StateMachineSystem {
    
    public abstract class TransitionBase : MonoBehaviour {
        
        public abstract bool TestCondition();
        public abstract Type GetInState();
        public abstract Type GetOutState();

    }
    
}
