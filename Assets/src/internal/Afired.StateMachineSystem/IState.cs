using System;

namespace Afired.StateMachineSystem {
    
    public interface IState {
        
        public void OnStateEnter();
        public void OnStateUpdate();
        public void OnStateExit();
        
        public bool TryToTransition(out Type type);
        
    }
    
}
