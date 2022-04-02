namespace Afired.StateMachineSystem {
    
    public interface ITransition<T1> where T1 : IState {
        
        public bool TestCondition();
        
    }
    
}
