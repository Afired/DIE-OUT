using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace Afired.StateMachineSystem {
    
    public class State : SerializedMonoBehaviour, IState {
        
        [OdinSerialize] public Transition<IState>[] _transitions;
        [OdinSerialize] private ITransition<IState> _someTransition;

        public virtual void OnStateEnter() { }
        public virtual void OnStateUpdate() { }
        public virtual void OnStateExit() { }
        
        public bool TryToTransition(out Type type) {
            foreach(Transition<IState> transition in _transitions) {
                if(transition.TestCondition()) {
                    type = transition.GetState();
                    return true;
                }
            }
            type = null;
            return false;
        }
        
    }
    
}
