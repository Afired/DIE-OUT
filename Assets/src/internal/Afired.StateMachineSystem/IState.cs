namespace Afired.StateMachineSystem {
    
    public interface IState {
        
        public void OnStateEnter();
        public void OnStateUpdate();
        public void OnStateExit();
        
    }
    
}
